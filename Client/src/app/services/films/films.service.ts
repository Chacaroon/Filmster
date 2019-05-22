import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable, Subject,  } from 'rxjs';
import { Film } from '../../models/films/film';
import { FilmsResponse } from '../../models/films/films-response';
import { Filters } from '../../models/filters/filters';
import { tap } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class FilmsService {

	public filtersObservable: Subject<Filters>;

	constructor(
		private http: HttpClient) {

		this.filtersObservable = new Subject<Filters>();
	}

	public getFilms(): Observable<FilmsResponse> {

		return this.http.get<FilmsResponse>(`${environment.apiUrl}/Films`)
			.pipe(tap(x => this.filtersObservable.next(x.filters)));
	}

	public getFilm(id): Observable<Film> {
		return this.http.get<Film>(`${environment.apiUrl}/Films/${id}`);
	}
}
