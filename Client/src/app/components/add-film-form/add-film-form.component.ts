import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { filterValidator } from '../../validators/filterValidator';
import { timeValidator } from '../../validators/timeValidator';
import { FilmsService } from '../../services/films/films.service';

@Component({
	selector: 'app-add-film-form',
	templateUrl: './add-film-form.component.html',
	styleUrls: ['./add-film-form.component.scss']
})
export class AddFilmFormComponent implements OnInit {

	filmForm: FormGroup;
	currentRate = 0;

	constructor(
		private fb: FormBuilder,
		private filmService: FilmsService) {
	}

	ngOnInit() {
		this.filmForm = this.fb.group({
			title: ['', Validators.required],
			year: ['', [Validators.min(1895), Validators.required]],
			description: [''],
			rating: [0],
			uri: [''],
			duration: [{hour: 0, minute: 0, second: 0}, timeValidator()],
			genreIds: this.fb.array([]),
			actorIds: this.fb.array([]),
			directorId: ['', filterValidator()]
		});

		this.addFilterInput('genreIds');
		this.addFilterInput('actorIds');
	}

	getFilterControls(filter: string): FormControl[] {
		return (this.filmForm.get(filter) as FormArray).controls as FormControl[];
	}

	addFilterInput(filter: string): void {
		(this.filmForm.get(filter) as FormArray).push(
			this.fb.control({id: 0, name: ''}, [filterValidator()])
		);
	}

	removeInput(filter: string, index: number): void {
		const filters = this.filmForm.get(filter) as FormArray;

		filters.removeAt(index);
	}

	submitForm(): void {

		if (this.filmForm.invalid) {
			this.markFormGroupTouched(this.filmForm);
			return;
		}

		this.filmForm.get('rating').patchValue(this.currentRate);

		this.filmService.addFilm(this.filmForm.value);
	}

	markFormGroupTouched = (formGroup) => {
		(<any>Object).values(formGroup.controls).forEach(control => {
			control.markAsTouched();

			if (control.controls)
				this.markFormGroupTouched(control);
		});
	};
}
