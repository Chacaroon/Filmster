import { Component, OnInit } from '@angular/core';
import { FilmsService } from '../../services/films/films.service';
import { Film } from '../../models/films/film';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-films',
	templateUrl: './films.component.html',
	styleUrls: ['./films.component.scss']
})
export class FilmsComponent implements OnInit {

	public films: Film[];
	openedFilm: Film;

	constructor(private modalService: NgbModal,
				private filmService: FilmsService) {}

	open(content, film) {
		this.openedFilm = film;
		this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title', size: 'lg'});
	}

	ngOnInit() {
		this.filmService.updateFilmsList();

		this.filmService.filmsObservable.subscribe(value => this.films = value);
	}


}
