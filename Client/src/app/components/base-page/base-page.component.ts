import { Component, OnInit } from '@angular/core';
import { FiltersService } from '../../services/fiters/filters.service';
import { Filters } from '../../models/filters/filters';

@Component({
	selector: 'app-base-page',
	templateUrl: './base-page.component.html',
	styleUrls: ['./base-page.component.scss']
})
export class BasePageComponent implements OnInit {

	filters: Filters;

	constructor(
		private filtersService: FiltersService) {
	}

	ngOnInit() {
		this.filtersService.filters
			.subscribe(value => this.filters = value);
	}

}
