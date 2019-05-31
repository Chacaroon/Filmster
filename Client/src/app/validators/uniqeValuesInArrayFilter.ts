import { FormArray, ValidatorFn } from '@angular/forms';

export function uniqueValidator(): ValidatorFn | null {
	return (control: FormArray) => {

		const res = getUnique(control.value, 'id');

		const ids = [];

		control.controls.forEach(c => {
			if (res.filter(e => e.id === c.value.id).length > 0)
				ids.push(c.value.id);
		});

		if (res.length !== control.value.length)
			return {'duplicate': {ids}};

		return null;
	};
}

function getUnique(arr, comp) {

	return arr
		.map(e => e[comp] || null)
		.map((e, i, final) => final.indexOf(e) === i && i)
		.filter(e => arr[e]).map(e => arr[e]);
}
