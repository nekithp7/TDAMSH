import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/index';

const appRoutes: Routes = <Routes>[
	// [TODO]: redirect to dashboard || home page; use canActivate guard -> redirect to login page
	{ path: '', redirectTo: '/auth', pathMatch: 'full' },
	{ path: '**', redirectTo: '/auth' }
];

@NgModule({
	imports: [
		RouterModule.forRoot(appRoutes)
	],
	exports: [
		RouterModule
	]
})
export class AppRoutingModule {
}
