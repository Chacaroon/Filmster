import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormControl } from '@angular/forms';
import { FiltersService } from '../../../services/filters/filters.service';
import { Observable, of } from 'rxjs';
import { debounceTime, distinct, distinctUntilChanged, filter, map, switchMap, tap } from 'rxjs/operators';
import { BaseFilter } from '../../../models/filters/base-filter';

@Component({
	selector: 'app-filter-input',
	templateUrl: './filter-input.component.html',
	styleUrls: ['./filter-input.component.scss']
})
export class FilterInputComponent implements OnInit {

	@Input() isRemovable: boolean;
	@Input() control: AbstractControl;
	@Input() filter: string;
	@Input() placeholder: string;
	@Output() remove = new EventEmitter();

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
