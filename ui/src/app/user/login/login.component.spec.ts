import { Store } from '@ngrx/store';
import { Router } from '@angular/router';
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { } from 'jasmine';

import { LoginComponent } from './login.component';
import { LoginService } from './login.service';
import { AppState } from '../../app.reducer';
import { UserActions } from '../user.actions';
import { SharedModule } from '../../shared/shared.module';

describe('AUTH_PAGE::COMPONENT', () => {
	let component: LoginComponent;
	let fixture: ComponentFixture<LoginComponent>;
	let mockLoginService: LoginService;
	let mockRouter: Router;

	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [SharedModule],
			providers: [
				{
					provide: LoginService,
					useValue: mockLoginService
				},
				{
					provide: Router,
					useValue: mockRouter
				}
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
