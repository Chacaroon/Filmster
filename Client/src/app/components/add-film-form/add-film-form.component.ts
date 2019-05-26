import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
	selector: 'app-add-film-form',
	templateUrl: './add-film-form.component.html',
	styleUrls: ['./add-film-form.component.scss']
})
export class AddFilmFormComponent implements OnInit {

	filmForm = this.fb.group({
		title: ['', Validators.required],
		year: ['', [Validators.min(1895), Validators.max(new Date().getUTCFullYear())]],
		description: [''],
		rating: [0],
		uri: [''],
		duration: ['00:00:00'],
		genreIds: this.fb.array([])
	});

	constructor(private fb: FormBuilder) {
	}

	ngOnInit() {
		console.log(this.filmForm);
	}

	onSubmitForm() {
		console.log(this.filmForm.controls);
	}

	getFilterControls(filter: string): AbstractControl[] {
		return (this.filmForm.get(filter) as FormArray).controls;
	}
}
