import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {FilmsService} from '../../services/films/films.service';
import {Film} from '../../models/film';

@Component({
	selector: 'app-film',
	templateUrl: './film.component.html',
	styleUrls: ['./film.component.scss']
})
export class FilmComponent implements OnInit {

	private film: Film;

	constructor(
		private route: ActivatedRoute,
		private filmsService: FilmsService) {
	}

	ngOnInit() {
	}

	getFilm(): void {
		const id = this.route.snapshot.paramMap.get('id');
		this.filmsService.getFilm(id)
			.subscribe(f => this.film = f);
	}

}
