import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FiltersService } from '../../../services/filters/filters.service';
import { Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, filter, switchMap } from 'rxjs/operators';
import { BaseFilter } from '../../../models/filters/base-filter';

@Component({
	selector: 'app-filter-input',
	templateUrl: './filter-input.component.html',
	styleUrls: ['./filter-input.component.scss']
})
export class FilterInputComponent implements OnInit {

	@Input('control') control: FormControl;
	@Input('filterType') filter: string;
	@Input('placeholder') placeholder: string;

	constructor(private filtersService: FiltersService) {
	}

	ngOnInit() {
	}

	search = (text: Observable<string>) => text.pipe(
		debounceTime(500),
		distinctUntilChanged(),
		filter(query => query.length > 2 || query.length === 0),
		switchMap(query =>
			query.length === 0
				? of([])
				: this.filtersService.searchFilters(this.filter, query))

	);

	formatter = (e: BaseFilter) => e.name;
}
