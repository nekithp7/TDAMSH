import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/index';
import { AuthGuard } from './core/canActivate.guard';

const appRoutes: Routes = <Routes>[
	// [TODO]: redirect to dashboard || home page; use canActivate guard -> redirect to login page
	{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
	{ path: '**', redirectTo: '/dashboard' }
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
