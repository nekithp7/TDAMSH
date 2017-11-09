import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { User } from './';

export const USER_ACTIONS = {
	CREATE_USER: 'CREATE_USER',
	DELETE_USER: 'DELETE_USER',
	EDIT_USER: 'EDIT_USER'
};

export class UserActions {

	public createUser(user: User): Action {
		return {
			type: USER_ACTIONS.CREATE_USER,
			payload: user
		};
	}

	public deleteUser(): Action {
		return {
			type: USER_ACTIONS.DELETE_USER,
			payload: null
		};
	}

	public editUser(user: User): Action {
		return {
			type: USER_ACTIONS.EDIT_USER,
			payload: user
		};
	}
}
