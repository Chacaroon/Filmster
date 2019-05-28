import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { filterValidator } from '../../validators/filterValidator';

@Component({
	selector: 'app-add-film-form',
	templateUrl: './add-film-form.component.html',
	styleUrls: ['./add-film-form.component.scss']
})
export class AddFilmFormComponent implements OnInit {

	filmForm: FormGroup;

	constructor(private fb: FormBuilder) {
	}

	ngOnInit() {
		this.filmForm = this.fb.group({
			title: ['', Validators.required],
			year: ['', [Validators.min(1895), Validators.max(new Date().getUTCFullYear())]],
			description: [''],
			rating: [0],
			uri: [''],
			duration: [{hour: 0, minute: 0, second: 0}],
			genreIds: this.fb.array([]),
			actorIds: this.fb.array([]),
			directorId: ['']
		});

		this.addFilterInput('genreIds');
		this.addFilterInput('actorIds');
	}

	getFilterControls(filter: string): FormControl[] {
		return (this.filmForm.get(filter) as FormArray).controls as FormControl[];
	}

	addFilterInput(filter: string): void {
		this.getFilterControls(filter).push(
			this.fb.control({id: 0, name: ''}, [Validators.required, filterValidator()])
		);
	}

	removeInput(filter: string, index: number): void {
		const filters = this.filmForm.get(filter) as FormArray;

		filters.removeAt(index);
	}

	submitForm(): void {

		this.filmForm.markAsTouched();

		console.log(this.filmForm.valid);
	}
}
