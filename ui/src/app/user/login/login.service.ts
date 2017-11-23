import { Injectable } from '@angular/core';
import {
	Http,
	RequestMethod,
	Request
} from '@angular/http';
import { Observable } from 'rxjs/Observable';

export const LOGIN_ENDPOINT = 'http://localhost:52048/auth/login';

@Injectable()
export class LoginService {

	constructor(private http: Http) { }

	login(email: string, password: string): Observable<string> {
		const request = new Request({
			method: RequestMethod.Post,
			url: LOGIN_ENDPOINT,
			body: {
				Email: email,
				Password: password
			}
		});
		return this.http.request(request)
			.map(res => {
				return res.json();
			});
	}

}
