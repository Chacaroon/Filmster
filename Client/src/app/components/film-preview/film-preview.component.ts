import {Component, Input, OnInit} from '@angular/core';
import {Film} from '../../models/film';

@Component({
	selector: 'app-film-preview',
	templateUrl: './film-preview.component.html',
	styleUrls: ['./film-preview.component.scss']
})
export class FilmPreviewComponent implements OnInit {

	@Input() film: Film;

	constructor() {
	}

	ngOnInit() {
	}

}
