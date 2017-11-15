import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

const userRoutes: Routes = <Routes>[
	{ path: 'auth', redirectTo: '/login' },
	{ path: 'login', component: LoginComponent },
	{ path: 'registration', component: LoginComponent }
];

@NgModule({
	imports: [
		RouterModule.forChild(userRoutes)
	],
	exports: [
		RouterModule
	]
})
export class UserRoutingModule { }

export const userRouterComponents = [LoginComponent];
