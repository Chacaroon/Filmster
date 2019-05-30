import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilmsService } from '../../services/films/films.service';
import { Film } from '../../models/films/film';
import { BaseFilter } from '../../models/filters/base-filter';

@Component({
	selector: 'app-film',
	templateUrl: './film.component.html',
	styleUrls: ['./film.component.scss']
})
export class FilmComponent implements OnInit {

	@Input() film: Film;

	constructor(
		private route: ActivatedRoute,
		private filmsService: FilmsService) {
	}

	ngOnInit() {
		this.getFilm();
	}

	getFilm(): void {
		const id = this.route.snapshot.paramMap.get('id');
		this.filmsService.getFilm(id)
			.subscribe(f => this.film = f);
	}

	mapFiltersToStrings(filters: BaseFilter[]): string[] {
		return filters.map(f => f.name);
	}
}
