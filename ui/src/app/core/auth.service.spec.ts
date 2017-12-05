import { AuthService } from './auth.service';

describe('AUTH::Service', () => {
	let mockAuth: AuthService;
	let token: string;

	beforeEach(() => {
		mockAuth = new AuthService();
		token = 'qweqwe';
		let fakeToken: Function = () => {
			return token || '';
		};
		spyOn(localStorage, 'getItem').and.callFake(fakeToken);
		spyOn(localStorage, 'setItem');

	});

	it('should get token from localStorage', () => {
		expect(mockAuth.getToken()).toBe(token);
		token = '';
		expect(mockAuth.getToken()).toBe('');
		expect(localStorage.getItem).toHaveBeenCalled();
	});

	it('should set token into localStorage', () => {
		mockAuth.setToken(token);
		expect(localStorage.setItem).toHaveBeenCalledWith('token', token);
	});

});
