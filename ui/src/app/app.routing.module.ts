import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/index';

const appRoutes: Routes = <Routes>[
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
