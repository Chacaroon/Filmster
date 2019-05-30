import { Component, Input, OnInit } from '@angular/core';
import { Film } from '../../models/films/film';

@Component({
	selector: 'app-film-preview',
	templateUrl: './film-preview.component.html',
	styleUrls: ['./film-preview.component.scss']
})
export class FilmPreviewComponent implements OnInit {

	@Input() film: Film;

	hover: boolean;

	constructor() {
	}

	ngOnInit() {
	}

}
