import { Component, OnInit } from '@angular/core';
import { Filters } from '../../models/filters/filters';
import { FilmsService } from '../../services/films/films.service';
import { filter } from 'rxjs/operators';

@Component({
	selector: 'app-sidebar',
	templateUrl: './sidebar.component.html',
	styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

	filters: Filters;

	constructor(
		private filmsService: FilmsService) {
	}

	ngOnInit() {
		this.filmsService.filtersObservable
			.pipe(filter(() => !this.filters))
			.subscribe(value => this.filters = value);
	}

	selectFilter(filter, value) {
		this.filmsService.addFilter(filter, value);
	}

	removeFilter(filter, value) {
		this.filmsService.removeFilter(filter, value);
	}
}
