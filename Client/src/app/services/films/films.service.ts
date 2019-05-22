import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable, Subject, } from 'rxjs';
import { Film } from '../../models/films/film';
import { FilmsResponse } from '../../models/films/films-response';
import { Filters } from '../../models/filters/filters';
import { debounceTime, filter, map, switchAll } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class FilmsService {

	private filtersSubject: Subject<Filters>;
	private filmsSubject: Subject<Film[]>;

	constructor(
		private http: HttpClient) {

		this.filtersSubject = new Subject<Filters>();
		this.filmsSubject = new Subject<Film[]>();
	}

	public get filmsObservable() {
		return this.filmsSubject.asObservable();
	}

	public get filtersObservable() {
		return this.filtersSubject.asObservable();
	}

	public updateFilmsList(): void {
		this.getFilms()
			.subscribe(value => {
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
					return query.length > 0
						? this.http.get<FilmsResponse>(`${environment.apiUrl}/Films/Search/${query}`)
						: this.getFilms();
				}),
				switchAll()
			)
			.subscribe((value: FilmsResponse) => {
				this.filmsSubject.next(value.films);
				this.filtersSubject.next(value.filters);
			});
	}

	private getFilms(): Observable<FilmsResponse> {
		return this.http.get<FilmsResponse>(`${environment.apiUrl}/Films`);
	}
}
