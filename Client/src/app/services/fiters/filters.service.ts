import { Injectable } from '@angular/core';
import { FilmsService } from '../films/films.service';
import { Filters } from '../../models/filters/filters';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class FiltersService {

	public filters: Observable<Filters>;

	constructor(private filmsService: FilmsService) {
		this.filters = filmsService.filtersObservable.asObservable();
	}


}
