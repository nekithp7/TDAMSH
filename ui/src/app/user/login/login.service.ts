import { Injectable } from '@angular/core';
import {
	Http,
	RequestMethod,
	Request
} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../../core/auth.service';

export const LOGIN_ENDPOINT = 'auth/login';

@Injectable()
export class LoginService {

	constructor(private http: Http, private auth: AuthService) { }

	login(email: string, password: string): Observable<string> {
		const body = {
			email: email,
			password: password
		};
		return this.http.post(LOGIN_ENDPOINT, body)
			.map(res => {
				const resp = res.json();
				this.auth.setToken(resp);
				return resp;
			});
	}

}
