import { NgModule } from '@angular/core';
import { SharedModule } from '../shared';
import { DashboardActions } from './dashboard.actions';
import { DashboardRoutingModule, dashboardRouterComponents } from './dashboard.routing.module';

@NgModule({
	imports: [
		SharedModule,
		DashboardRoutingModule
	],
	declarations: [
		dashboardRouterComponents
	],
	providers: [
		DashboardActions
	]
})
export class DashboardModule {
}
