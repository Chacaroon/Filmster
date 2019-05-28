import { AbstractControl, ValidatorFn } from '@angular/forms';
import { BaseFilter } from '../models/filters/base-filter';

export function filterValidator(): ValidatorFn {
	return (control: AbstractControl): { [key: string]: any } | null => {
		const value = control.value as BaseFilter;

		if (value !== null && value.id)
			return null;

		return {'filterRequired': {valid: false}};
	};
}
