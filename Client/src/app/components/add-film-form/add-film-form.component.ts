import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { filterValidator } from '../../validators/filterValidator';
import { timeValidator } from '../../validators/timeValidator';
import { FilmsService } from '../../services/films/films.service';
import { uniqueValidator } from '../../validators/uniqeValuesInArrayFilter';
import { ActivatedRoute } from '@angular/router';

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
		private filmService: FilmsService,
		private route: ActivatedRoute) {
	}

	ngOnInit() {
		if (!this.route.snapshot.paramMap.has('id')) {
			this.filmForm = this.fb.group({
				title: ['', Validators.required],
				year: ['', [Validators.min(1895), Validators.required]],
				description: [''],
				rating: [0],
				uri: [''],
				duration: [{hour: 0, minute: 0, second: 0}, timeValidator()],
				genreIds: this.fb.array([], uniqueValidator()),
				actorIds: this.fb.array([], uniqueValidator()),
				directorId: ['', filterValidator()]
			});

			this.addFilterInput('genreIds');
			this.addFilterInput('actorIds');
		} else {
			const filmId = this.route.snapshot.paramMap.get('id');
			this.filmService.getFilm(filmId)
				.subscribe(film => {
					this.filmForm = this.fb.group({
						title: [film.title, Validators.required],
						year: [film.year, [Validators.min(1895), Validators.required]],
						description: [film.description],
						rating: [film.rating],
						uri: [film.uri],
						duration: [{hour: film.duration.hour, minute: film.duration.minute, second: film.duration.second}, timeValidator()],
						genreIds: this.fb.array(film.genres, uniqueValidator()),
						actorIds: this.fb.array(film.actors, uniqueValidator()),
						directorId: ['', filterValidator()]
					});
				});
		}
	}

	getFilterControls(filter: string): FormControl[] {
		return (this.filmForm.get(filter) as FormArray).controls as FormControl[];
	}

	addFilterInput(filter: string, state = {id: 0, name: ''}): void {
		(this.filmForm.get(filter) as FormArray).push(
			this.fb.control(state, [filterValidator()])
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

		this.filmForm.disable();
		this.filmService.addFilm(this.filmForm.value)
			.subscribe(() => {
				},
				console.error,
				this.filmForm.enable);
	}

	markFormGroupTouched = (formGroup) => {
		(<any>Object).values(formGroup.controls).forEach(control => {
			control.markAsTouched();

			if (control.controls) {
				this.markFormGroupTouched(control);
			}
		});
	};
}
