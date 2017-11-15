import { USER_ACTIONS, User } from './';
import { UserActions } from './user.actions';

describe('USER::ACTOINS', () => {
	let userActions = new UserActions();
	let mockUser: User;

	beforeEach(() => {
		mockUser = {
			id: '0',
			email: 'email@example.com',
			name: 'user'
		};
	});

	it('User actions should be defind', () => {
		expect(userActions).toBeDefined();
	});

	it('Actions\' names should be defined', () => {
		expect(USER_ACTIONS.CREATE_USER).toBeDefined();
		expect(USER_ACTIONS.DELETE_USER).toBeDefined();
		expect(USER_ACTIONS.EDIT_USER).toBeDefined();
	});

	it('Should create action on create user', () => {
		expect(userActions.createUser(mockUser)).toEqual({
			type: USER_ACTIONS.CREATE_USER,
			payload: mockUser
		});
	});

	it('Should create action on delete user', () => {
		expect(userActions.deleteUser()).toEqual({
			type: USER_ACTIONS.DELETE_USER,
			payload: null
		});
	});

	it('Should create action on edit user', () => {
		expect(userActions.editUser(mockUser)).toEqual({
			type: USER_ACTIONS.EDIT_USER,
			payload: mockUser
		});
	});
});

