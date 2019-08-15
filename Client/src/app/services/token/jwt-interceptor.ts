import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenService } from './token.service';
import { iif, Observable, throwError } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { catchError, mergeMap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

	constructor(private tokenService: TokenService
		, private authService: AuthService) {
	}

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		next.handle(request);
		const refreshToken$ = this.tokenService.refreshToken()
			.pipe(
				mergeMap(() => next.handle(this.addTokenToRequest(request))),
				catchError(err => {
					this.authService.logout();
					return throwError(err);
				})
			);

		return next.handle(this.addTokenToRequest(request)).pipe(
			catchError(err => iif(
				() => err.status === 401 && !!this.tokenService.Token,
				refreshToken$,
				throwError(err)
			))
		);
	}

	private addTokenToRequest(request: HttpRequest<any>): HttpRequest<any> {
		return request.clone({
			setHeaders: {
				Authorization: `Bearer ${this.tokenService.Token}`
			}
		});
	}
}
