import { Component, OnInit } from '@angular/core';
import { FiltersService } from '../../services/fiters/filters.service';
import { Filters } from '../../models/filters/filters';

@Component({
	selector: 'app-sidebar',
	templateUrl: './sidebar.component.html',
	styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

	filters: Filters;

	constructor(
		private filtersService: FiltersService) {
	}

	ngOnInit() {
		this.filtersService.filters.subscribe(value => this.filters = value);
	}

}
