import { TestBed, ComponentFixture } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { } from 'jasmine';

import { SharedModule } from './../../shared/shared.module';

import { LoginComponent } from './../login/login.component';
import { UserRoutingModule } from './../user.routing.module';
import { AuthPageComponent } from './auth-page.component';

describe('AUTH_PAGE::COMPONENT', () => {
	let component: AuthPageComponent;
	let fixture: ComponentFixture<AuthPageComponent>;

	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [SharedModule, RouterTestingModule],
			providers: [],
			declarations: [AuthPageComponent, LoginComponent],
		});
		fixture = TestBed.createComponent(AuthPageComponent);
		component = fixture.componentInstance;
	});

	it('Component should be defined', () => {
		expect(component).toBeDefined();
	});
});
