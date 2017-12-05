import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginGuard } from './canActivate.guard';

const userRoutes: Routes = <Routes>[
	{
		path: 'auth', component: AuthPageComponent, canActivate: [LoginGuard],
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
