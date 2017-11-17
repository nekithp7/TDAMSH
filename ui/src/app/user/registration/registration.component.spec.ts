import { TestBed, ComponentFixture } from '@angular/core/testing';
import { } from 'jasmine';

import { RegistrationComponent } from './registration.component';

describe('AUTH_PAGE::COMPONENT', () => {
	let component: RegistrationComponent;
	let fixture: ComponentFixture<RegistrationComponent>;

	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [],
			providers: [],
			declarations: [RegistrationComponent],
		});
		fixture = TestBed.createComponent(RegistrationComponent);
		component = fixture.componentInstance;
	});

	it('Component should be defined', () => {
		expect(component).toBeDefined();
	});
});
