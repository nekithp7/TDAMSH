import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';

import { User } from '../index';
import { AppState } from '../../app.reducer';
import { UserActions } from '../user.actions';
import { LoginModel } from './login.component.model';
import { LoginService } from './login.service';

@Component({
	selector: 'tdamsh-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent {
	public userCredentials: LoginModel = {
		email: '',
		password: '',
		isPaswordVisible: false
	};

	constructor(private loginService: LoginService) { }

	private onSingIn(): void {
		this.loginService.login(this.userCredentials.email, this.userCredentials.password)
			.subscribe((userToken: string) => {
				// TODO do smth
			});
	}
}
