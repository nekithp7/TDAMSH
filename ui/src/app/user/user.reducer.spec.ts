import { Action } from '@ngrx/store';
import { User } from './user.model';
import reducer from './user.reducer';
import { USER_ACTIONS } from './user.actions';

describe('USER::REDUCER', () => {
	let mockInitialState: User;
	let mockState: User;

	beforeEach(() => {
		mockInitialState = new User();
		mockState = {
			id: '0',
			name: 'user',
			email: 'email@example.com'
		};
	});

	it('should return the initial state', () => {
		expect(reducer(undefined, {} as Action))
			.toEqual(mockInitialState);
	});

	it('should handle user creation', () => {
		expect(
			reducer(mockInitialState, {
				type: USER_ACTIONS.CREATE_USER,
				payload: mockState
			})
		).toEqual(mockState);
	});

	it('should handle user deleting', () => {
		expect(
			reducer(mockInitialState, {
				type: USER_ACTIONS.DELETE_USER,
				payload: null
			})
		).toEqual(null);
	});

	it('should handle user editing', () => {
		expect(
			reducer(mockInitialState, {
				type: USER_ACTIONS.EDIT_USER,
				payload: mockState
			})
		).toEqual(mockState);
	});
});
