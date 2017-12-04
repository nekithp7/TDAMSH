import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Store, StoreModule } from '@ngrx/store';
import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { UserModule } from './user';
import appReduser, * as appReducer from './app.reducer';
import { Http, XHRBackend, RequestOptions } from '@angular/http';
import { httpFactory } from './core/http.factory';
import { AuthService } from './core/auth.service';
import { SharedModule } from './shared/shared.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { AuthGuard } from './core/canActivate.guard';
import { LoginGuard } from './user/canActivate.guard';

@NgModule({
	imports: [
		SharedModule,
		BrowserModule,
		UserModule,
		DashboardModule,
		StoreModule.provideStore(appReducer),
		AppRoutingModule
	],
	declarations: [
		AppComponent
	],
	providers: [
		{
			provide: Http,
			useFactory: httpFactory,
			deps: [XHRBackend, RequestOptions, AuthService]
		},
		AuthService,
		AuthGuard,
		LoginGuard
	],
	bootstrap: [AppComponent]
})
export class AppModule {
}
