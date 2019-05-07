import {Component, OnInit} from '@angular/core';
import {TokenService} from '../../services/token/token.service';
import {UserService} from '../../services/user/user.service';
import {AuthService} from '../../services/auth/auth.service';
import {NavigationEnd, Router} from '@angular/router';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

	public isLoggedOn: boolean;

	constructor(private tokenService: TokenService
		, private userService: UserService
		, private authService: AuthService
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
	}

}
