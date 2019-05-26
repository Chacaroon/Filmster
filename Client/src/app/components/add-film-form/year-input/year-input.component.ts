import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
	selector: 'app-year-input',
	templateUrl: './year-input.component.html',
	styleUrls: ['./year-input.component.scss']
})
export class YearInputComponent implements OnInit {

	@Input('control') control: AbstractControl;

	constructor() {
	}

	ngOnInit() {
	}

}
