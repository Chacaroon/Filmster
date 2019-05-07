import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {SignInModel} from '../../models/sign-in-model';
import {RegisterModel} from '../../models/register-model';
import {TokenService} from '../token/token.service';
import {AuthorizationSuccess} from '../../models/authorization-success';
import {UserService} from '../user/user.service';
import {Router} from '@angular/router';

@Injectable({
	providedIn: 'root'
})
export class AuthService {

	private apiUrl = environment.apiUrl;

	constructor(private http: HttpClient
		, private tokenService: TokenService
		, private userService: UserService
		, private router: Router) {
	}

	public signIn(model: SignInModel) {
		this.http.post<AuthorizationSuccess>(`${this.apiUrl}/Auth/SignIn`, model)
			.subscribe((res) => {
				this.tokenService.Token = res.accessToken;
				this.userService.User = res.userName;
				this.router.navigate(['films']);
			});
	}

	public register(model: RegisterModel) {
		this.http.post<AuthorizationSuccess>(`${this.apiUrl}/Auth/Register`, model)
			.subscribe(res => {
				this.tokenService.Token = res.accessToken;
				this.userService.User = res.userName;
				this.router.navigate(['films']);
			});
	}

	public logout() {
		this.tokenService.Token = null;
		this.userService.User = null;
		this.router.navigate(['']);
	}
}
