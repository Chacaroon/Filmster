import { Component, OnInit } from '@angular/core';
import { Filters } from '../../models/filters/filters';
import { FilmsService } from '../../services/films/films.service';

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
		this.filmsService.filtersObservable.subscribe(value => this.filters = value);
	}

}
