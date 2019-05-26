import { Injectable } from '@angular/core';
import { FilmsService } from '../films/films.service';
import { Observable, Subject } from 'rxjs';
import { Filters } from '../../models/filters/filters';
import { BaseFilter } from '../../models/filters/base-filter';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { filter, switchAll } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class FiltersService {

	private _filtersSubject: Subject<Filters>;

	constructor(
		private filmsService: FilmsService,
		private http: HttpClient
	) {
		filmsService.filtersObservable.subscribe(f => this._filtersSubject.next(f));
	}

	public get filtersObservable(): Observable<Filters> {
		return this._filtersSubject.asObservable();
	}

	public searchFilters(filterType: string, value: string): Observable<BaseFilter[]>
	{
		return this.http
			.get<BaseFilter[]>(`${environment.apiUrl}/Filters/Search/${filterType}/Like/${value}`);
	}
}
