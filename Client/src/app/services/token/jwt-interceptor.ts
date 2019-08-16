import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenService } from './token.service';
import { iif, Observable, of, throwError } from 'rxjs';
import { AuthService } from '../auth/auth.service';
import { catchError, map, mergeMap, switchMap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

	constructor(private tokenService: TokenService
		, private authService: AuthService) {
	}

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		const request$ = of(1)
			.pipe(mergeMap(() => {
				const requestWithToken =  this.addTokenToRequest(request);
				return next.handle(requestWithToken);
			}));

		const refreshToken$ = this.tokenService.refreshToken()
			.pipe(
				mergeMap(() => request$),
				catchError(err => {
					this.authService.logout();
					return throwError(err);
				})
			);

		return request$.pipe(
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
