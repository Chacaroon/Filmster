import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../services/auth/auth.service';

@Component({
	selector: 'app-sign-in',
	templateUrl: './sign-in.component.html',
	styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
	signInForm = new FormGroup({
		userName: new FormControl('', [Validators.required]),
		password: new FormControl('', [Validators.required])
	});

	constructor(private authService: AuthService) {
	}

	ngOnInit() {
	}

	onSubmit() {
		if (!this.signInForm.valid) {
			return;
		}

		this.authService.signIn(this.signInForm.value);
	}
}
