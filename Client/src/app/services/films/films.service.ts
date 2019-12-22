import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable, Subject, } from 'rxjs';
import { Film } from '../../models/films/film';
import { FilmsResponse } from '../../models/films/films-response';
import { Filters } from '../../models/filters/filters';
import { debounceTime, filter, map, switchAll, tap } from 'rxjs/operators';
import { BaseFilter } from '../../models/filters/base-filter';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root'
})
export class FilmsService {

	public isLoading: boolean;

	private filtersSubject: Subject<Filters>;
	private filmsSubject: Subject<Film[]>;
	private filters = {
		genreIds: [],
		actorIds: [],
		directorIds: [],
		searchString: '',
		page: 1
	};

	constructor(
		private http: HttpClient,
		private router: Router) {

		this.filtersSubject = new Subject<Filters>();
		this.filmsSubject = new Subject<Film[]>();

		this.isLoading = true;
	}

	public get filmsObservable() {
		return this.filmsSubject.asObservable();
	}

	public get filtersObservable() {
		return this.filtersSubject.asObservable();
	}

	public addFilter(filterType: string, value: string) {
		if (typeof this.filters[filterType] === typeof [])
			(this.filters[filterType] as Array<any>).push(value);
		else
			this.filters[filterType] = value;

		this.updateFilmsList();
	}

	public removeFilter(filterType: string, value: string) {
		if (typeof this.filters[filterType] === typeof []) {
			const arr = (this.filters[filterType] as Array<any>);
			const index = arr.indexOf(value);

			if (index > -1)
				arr.splice(index, 1);
		}

		this.updateFilmsList();
	}

	public updateFilmsList(): void {
		this.getFilms()
			.pipe(tap(() => this.isLoading = true))
			.subscribe(value => {
				this.isLoading = false;
				this.filmsSubject.next(value.films);
				this.filtersSubject.next(value.filters);
			});
	}

	public getFilm(id): Observable<Film> {
		return this.http.get<Film>(`${environment.apiUrl}/Films/${id}`);
	}

	public search(eventObservable: Observable<string>): void {
		eventObservable
			.pipe(
				debounceTime(1000),
				filter((value: string) => value.length > 3 || value.length === 0),
				map((value: string) => {
					this.isLoading = true;
					this.filters.searchString = value;
					return this.getFilms();
				}),
				switchAll()
			)
			.subscribe((value: FilmsResponse) => {
				this.isLoading = false;

				this.filmsSubject.next(value.films);
				this.filtersSubject.next(value.filters);
			});
	}

	public addFilm(film: any): Observable<any> {
		film.actorIds = film.actorIds.map((e: BaseFilter) => e.id);
		film.genreIds = film.genreIds.map((e: BaseFilter) => e.id);
		film.directorId = film.directorId.id;

		const {hour, minute, second} = film.duration;

		film.duration = `${hour}:${minute}:${second}`;

		return this.http.post(`${environment.apiUrl}/Films/`, film)
			.pipe(tap((res: { id: number }) => {
					this.router.navigate([`films`]);
				}));
	}

	private getFilms(): Observable<FilmsResponse> {
		// @ts-ignore
		const params = new HttpParams({fromObject: this.filters});
		return this.http.get<FilmsResponse>(`${environment.apiUrl}/Films`, {params});
	}
}
