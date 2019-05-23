import { Component, OnInit } from '@angular/core';
import { TokenService } from '../../services/token/token.service';
import { UserService } from '../../services/user/user.service';
import { AuthService } from '../../services/auth/auth.service';
import { NavigationEnd, Router } from '@angular/router';
import { observable, timer } from 'rxjs';
import { repeat } from 'rxjs/operators';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	public isLoggedOn: boolean;

	time: string;

	constructor(private tokenService: TokenService
		, protected userService: UserService
		, protected authService: AuthService
		, private router: Router) {
	}

	ngOnInit() {
		this.isLoggedOn = this.tokenService.isLoggedOn;
		this.router.events
			.subscribe((e) => {
				if (e instanceof NavigationEnd) {
					this.isLoggedOn = this.tokenService.isLoggedOn;
				}
			});

		timer(1)
			.pipe(repeat())
			.subscribe(e => {
				const date = new Date();
				this.time = `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;
			});
	}

}
