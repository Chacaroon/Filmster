import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable, Subject, } from 'rxjs';
import { Film } from '../../models/films/film';
import { FilmsResponse } from '../../models/films/films-response';
import { Filters } from '../../models/filters/filters';
import { debounceTime, filter, map, switchAll, tap } from 'rxjs/operators';
import { BaseFilter } from '../../models/filters/base-filter';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
	providedIn: 'root'
})
export class FilmsService {

	public isLoading: boolean;

	private filtersSubject: Subject<Filters>;
	private filmsSubject: Subject<Film[]>;

	constructor(
		private http: HttpClient) {

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
				map(query => {
					this.isLoading = true;

					return query.length > 0
						? this.http.get<FilmsResponse>(`${environment.apiUrl}/Films/Search/${query}`)
						: this.getFilms();
				}),
				switchAll()
			)
			.subscribe((value: FilmsResponse) => {
				this.isLoading = false;

				this.filmsSubject.next(value.films);
				this.filtersSubject.next(value.filters);
			});
	}

	public addFilm(film: any): void {
		film.actorIds = film.actorIds.map((e: BaseFilter) => e.id);
		film.genreIds = film.genreIds.map((e: BaseFilter) => e.id);
		film.directorId = film.directorId.id;

		const {hour, minute, second} = film.duration as NgbTimeStruct;

		film.duration = `${hour}:${minute}:${second}`;

		this.http.post(`${environment.apiUrl}/Films/`, film)
			.subscribe(res => {
					console.log(res);
				},
				err => console.error(err));
	}

	private getFilms(): Observable<FilmsResponse> {
		return this.http.get<FilmsResponse>(`${environment.apiUrl}/Films`);
	}
}
