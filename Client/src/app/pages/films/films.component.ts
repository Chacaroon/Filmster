import { Component, OnInit } from '@angular/core';
import { FilmsService } from '../../services/films/films.service';
import { Film } from '../../models/films/film';

@Component({
	selector: 'app-films',
	templateUrl: './films.component.html',
	styleUrls: ['./films.component.scss']
})
export class FilmsComponent implements OnInit {

	public films: Film[];

	constructor(private filmsService: FilmsService) {
	}

	ngOnInit() {
		this.filmsService.updateFilmsList();

		this.filmsService.filmsObservable.subscribe(value => this.films = value);
	}


}
