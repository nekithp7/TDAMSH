import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Store, StoreModule } from '@ngrx/store';
import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { UserModule } from './user';
import appReduser, * as appReducer from './app.reducer';

@NgModule({
	imports: [
		BrowserModule,
		UserModule,
		StoreModule.provideStore(appReducer),
		AppRoutingModule
	],
	declarations: [
		AppComponent
	],
	providers: [
	],
	bootstrap: [AppComponent]
})
export class AppModule {
}
