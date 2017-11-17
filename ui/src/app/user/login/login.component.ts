import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';

import { User } from '../index';
import { AppState } from '../../app.reducer';
import { UserActions } from '../user.actions';
import { LoginModel } from './login.component.model';

@Component({
	selector: 'tdamsh-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent {
	public userCredentials: LoginModel = {
		email: '',
		password: '',
		isPaswordHidden: true
	};

	private onSingIn(): void {
		// console.log(this.userCredentials);
	}
}
