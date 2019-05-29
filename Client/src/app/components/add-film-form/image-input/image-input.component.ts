import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
	selector: 'app-image-input',
	templateUrl: './image-input.component.html',
	styleUrls: ['./image-input.component.scss']
})
export class ImageInputComponent implements OnInit {

	@Input() control: AbstractControl;

	constructor() {
	}

	ngOnInit() {
	}

	readImage(event) {
		const reader = new FileReader();

		reader.onloadend = () => this.control.patchValue(reader.result);
		reader.onerror = () => console.error('err');

		reader.readAsDataURL(event.srcElement.files[0]);
	}
}
