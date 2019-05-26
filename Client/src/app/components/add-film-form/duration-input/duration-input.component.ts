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
		this.control.setValidators(control1 => {
			const val: NgbTimeStruct = control1.value;

			if (val == null)
				return null;

			if ([+val.hour, +val.minute, +val.second].every(e => e === 0))
				return {durationTooSmall: true};

			return null;
		});
	}

}
