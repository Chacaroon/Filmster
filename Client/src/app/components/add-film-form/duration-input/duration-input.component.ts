import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-duration-input',
	templateUrl: './duration-input.component.html',
	styleUrls: ['./duration-input.component.scss']
})
export class DurationInputComponent implements OnInit {

	@Input('control') control: AbstractControl;

	constructor() {
	}

	ngOnInit() {

	}

}
