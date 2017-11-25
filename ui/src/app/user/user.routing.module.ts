import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { RegistrationComponent } from './registration/registration.component';

const userRoutes: Routes = <Routes>[
	{
		path: 'auth', component: AuthPageComponent,
		children: [
			{ path: '', redirectTo: 'login', pathMatch: 'full' },
			{ path: 'login', component: LoginComponent },
			{ path: 'registration', component: RegistrationComponent }
		]
	}];
@NgModule({
	imports: [
		RouterModule.forChild(userRoutes)
	],
	exports: [
		RouterModule
	]
})
export class UserRoutingModule { }

export const userRouterComponents = [
	LoginComponent,
	AuthPageComponent,
	RegistrationComponent];
