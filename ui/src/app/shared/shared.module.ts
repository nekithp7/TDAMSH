import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { CheckboxComponent } from './custom-inputs/checkbox/checkbox.component';
import { HttpModule } from '@angular/http';

@NgModule({
	imports: [
		HttpModule,
		FormsModule,
		CommonModule
	],
	declarations: [
		CheckboxComponent
	],
	providers: [
	],
	exports: [
		FormsModule,
		CheckboxComponent,
		HttpModule,
		CommonModule
	]
})
export class SharedModule {
}
