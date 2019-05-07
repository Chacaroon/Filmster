import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {Film} from '../../models/film';
import {FilmsResponse} from '../../models/films-response';

@Injectable({
	providedIn: 'root'
})
export class FilmsService {

	constructor(private http: HttpClient) {
	}

	public getFilms(): Observable<FilmsResponse> {
		return this.http.get<FilmsResponse>(`${environment.apiUrl}/Films`);
	}

	public getFilm(id): Observable<Film> {
		return this.http.get<Film>(`${environment.apiUrl}/Films/${id}`);
	}
}
