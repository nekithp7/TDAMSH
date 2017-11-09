
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { User, USER_ACTIONS } from './';

export type UserState = User;

const initialState: User = new User();

export default function (state: User = initialState, action: Action): UserState {
	switch (action.type) {
		case USER_ACTIONS.CREATE_USER: {
			return action.payload;
		}
		case USER_ACTIONS.DELETE_USER: {
			return action.payload;
		}
		case USER_ACTIONS.EDIT_USER: {
			return action.payload;
		}
		default: {
			return state;
		}
	}
}
