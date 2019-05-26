import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
	selector: 'app-title-input',
	templateUrl: './title-input.component.html',
	styleUrls: ['./title-input.component.scss']
})
export class TitleInputComponent implements OnInit {

	@Input('control') control: AbstractControl;

	constructor() {
	}

	ngOnInit() {
	}
}

