import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

	setToken(token: string): void {
		localStorage.setItem('token', token);
	}

	getToken(): string {
		return localStorage.getItem('token') || '';
	}
}
