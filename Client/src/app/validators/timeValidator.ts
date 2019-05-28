import { NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, ValidatorFn } from '@angular/forms';

export function timeValidator(): ValidatorFn | null {
	return (control: FormControl) => {
		const {hour, minute, second} = control.value as NgbTimeStruct;

		if (hour || minute || second)
			return;

		return {'durationTooSmall': {valid: false}};
	};
}
