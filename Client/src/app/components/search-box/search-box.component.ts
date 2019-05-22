import { Component, ElementRef, OnInit } from '@angular/core';
import { fromEvent } from 'rxjs';
import { map } from 'rxjs/operators';
import { FilmsService } from '../../services/films/films.service';

@Component({
	selector: 'app-search-box',
	templateUrl: './search-box.component.html',
	styleUrls: ['./search-box.component.scss']
})
export class SearchBoxComponent implements OnInit {

	constructor(private filmsService: FilmsService,
				private elem: ElementRef) {
	}

	ngOnInit() {
		this.filmsService.search(
			fromEvent(this.elem.nativeElement, 'input')
				.pipe(map((e: any) => e.target.value)));
	}

}
