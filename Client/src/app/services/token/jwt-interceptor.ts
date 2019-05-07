import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {TokenService} from './token.service';
import {Observable, throwError} from 'rxjs';
import {AuthService} from '../auth/auth.service';
import {catchError, mergeMap, retryWhen, scan, takeWhile} from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

	constructor(private tokenService: TokenService
		, private authService: AuthService) {
	}

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		console.dir('intercept');

		if (this.tokenService.Token) {
			request = request.clone({
				setHeaders: {
					Authorization: `Bearer ${this.tokenService.Token}`
				}
			});
		}

		return next.handle(request)
			.pipe(catchError((err) => {
					if (err.status === 401 && this.tokenService.Token) {
						return this.handle401error(next, request);
					}

					return throwError(err);
				}),
				retryWhen((errors) => errors.pipe(
					scan((errorCount) => {
						return errorCount + 1;
					}, 0)
					, takeWhile((errorCount) => {
						return errorCount < 2;
					})
					)
				)
			);
	}

	private handle401error(next, request): Observable<any> {
		return this.tokenService.refreshToken()
			.pipe(mergeMap(() => {
					request = request.clone({
						setHeaders: {
							Authorization: `Bearer ${this.tokenService.Token}`
						}
					});
					return next.handle(request);
				})
				, catchError(err1 => {
					this.authService.logout();
					return throwError(err1);
				}));
	}
}
