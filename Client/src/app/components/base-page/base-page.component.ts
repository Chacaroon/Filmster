import { Component, OnInit } from '@angular/core';
import { Filters } from '../../models/filters/filters';
import { FilmsService } from '../../services/films/films.service';

@Component({
	selector: 'app-base-page',
	templateUrl: './base-page.component.html',
	styleUrls: ['./base-page.component.scss']
})
export class BasePageComponent implements OnInit {

	filters: Filters;

	constructor(
		private filmsService: FilmsService) {
	}

	ngOnInit() {
		this.filmsService.filtersObservable
			.subscribe(value => this.filters = value);
	}

}
