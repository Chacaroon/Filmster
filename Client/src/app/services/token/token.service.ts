import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient, HttpEvent} from '@angular/common/http';
import {UserService} from '../user/user.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class TokenService {

	private apiUrl = environment.apiUrl + '/Token';

	constructor(private http: HttpClient
		, private userService: UserService) {
	}

	public get isLoggedOn(): boolean {
		return !!this.Token;
	}

	public get Token(): string {
		return localStorage.getItem('accessToken');
	}

	public set Token(token: string) {
		!!token
			? localStorage.setItem('accessToken', token)
			: localStorage.removeItem('accessToken');
	}

	public refreshToken(): Observable<HttpEvent<any>> {
		return this.http.post<any>(this.apiUrl, {
			token: this.Token,
			userName: this.userService.User
		})
			.pipe(tap(res => {
				this.Token = res.accessToken;
			}));
	}
}
