import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';
import { RegisterModel } from '../../models/auth/register-model';

@Component({
	selector: 'app-register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
	registerForm = new FormGroup({
		userName: new FormControl(),
		password: new FormControl(),
		repeatPassword: new FormControl()
	});

	constructor(private authService: AuthService) {
	}

	ngOnInit() {
	}

	onSubmit() {
		if (!this.registerForm.valid) {
			return;
		}

		const {userName, password, repeatPassword} = this.registerForm.value;

		if (password !== repeatPassword) {
			this.registerForm.controls['repeatPassword'].setErrors({'nomatch': true});
			return;
		}

		this.authService.register(new RegisterModel(userName, password));
	}

}
