import '@ngrx/core/add/operator/select';
import { compose } from '@ngrx/core/compose';
import { combineReducers } from '@ngrx/store';
import userReducer, * as user from './user/user.reducer';

export interface AppState {
	// states
	user: user.UserState;
}

export default compose(combineReducers)({
	// reducers
	user: userReducer
});
