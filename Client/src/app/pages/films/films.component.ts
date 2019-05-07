import {Component, OnInit} from '@angular/core';
import {FilmsService} from '../../services/films/films.service';
import {Film} from '../../models/film';

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
		this.filmsService.getFilms()
			.subscribe((res) => this.films = res.films);
	}


}
