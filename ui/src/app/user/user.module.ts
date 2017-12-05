import { NgModule } from '@angular/core';
import { SharedModule } from '../shared';
import { UserActions } from './user.actions';
import { userRouterComponents, UserRoutingModule } from './user.routing.module';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login/login.service';

@NgModule({
	imports: [
		SharedModule,
		UserRoutingModule
	],
	declarations: [
		userRouterComponents
	],
	providers: [
		UserActions,
		LoginService
	]
})
export class UserModule {
}
