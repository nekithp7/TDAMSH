import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from '../core/canActivate.guard';

const dashboardRoutes: Routes = <Routes>[
	{ path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] }];

@NgModule({
	imports: [
		RouterModule.forChild(dashboardRoutes)
	],
	exports: [
		RouterModule
	]
})

export class DashboardRoutingModule { }

export const dashboardRouterComponents = [DashboardComponent];
