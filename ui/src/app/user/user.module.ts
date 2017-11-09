import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../shared';
import { UserActions } from './user.actions';

@NgModule({
	imports: [
		SharedModule
	],
	declarations: [
		LoginComponent
	],
	providers: [
		UserActions

	]
})
export class UserModule {
}
