import { Store } from '@ngrx/store';
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { } from 'jasmine';

import { LoginComponent } from './login.component';
import { AppState } from '../../app.reducer';
import { UserActions } from '../user.actions';
import { SharedModule } from '../../shared/shared.module';

describe('AUTH_PAGE::COMPONENT', () => {
	let component: LoginComponent;
	let fixture: ComponentFixture<LoginComponent>;
	// let mockStore: Store<AppState>;
	// let mockActions: UserActions;

	beforeEach(() => {
		// mockStore = {
		// 	subscribe: null
		// } as Store<AppState>;
		// spyOn(mockStore, 'subscribe');

		TestBed.configureTestingModule({
			imports: [SharedModule],
			providers: [
			// 	{
			// 	provide: Store,
			// 	useValue: mockStore
			// },
			// {
			// 	provide: UserActions,
			// 	useValue: mockActions
			// }
		],
			declarations: [LoginComponent],
		});
		fixture = TestBed.createComponent(LoginComponent);
		component = fixture.componentInstance;
	});

	it('Component should be defined', () => {
		expect(component).toBeDefined();
	});
});
