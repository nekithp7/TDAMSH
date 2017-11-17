import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { CheckboxComponent } from './custom-inputs/checkbox/checkbox.component';

@NgModule({
	imports: [
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
		CheckboxComponent
	]
})
export class SharedModule {
}
