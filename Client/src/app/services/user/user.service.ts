import {Injectable} from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class UserService {

	constructor() {
	}

	public get User(): string {
		return localStorage.getItem('userName');
	}

	public set User(userName: string) {
		!!userName
			? localStorage.setItem('userName', userName)
			: localStorage.removeItem('userName');
	}
}
