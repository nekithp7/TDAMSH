import { Component, Input } from '@angular/core';
import { User } from '../index';
import { Store } from '@ngrx/store';
import { AppState } from '../../app.reducer';
import { UserActions } from '../user.actions';

@Component({
	selector: 'tdamsh-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent {
	public user = new User();

	constructor(private store: Store<AppState>,
		private usrerAction: UserActions) {
		this.store.subscribe((data) => {
			// STORE DATA
		});

	}

	public onAction(): void {
		this.store.dispatch(this.usrerAction.createUser(this.user));
	}
}
