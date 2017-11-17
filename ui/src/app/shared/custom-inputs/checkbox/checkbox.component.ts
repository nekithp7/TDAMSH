import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import getID from '../../helpers/generate-id';

@Component({
	selector: 'tdamsh-checkbox',
	templateUrl: 'checkbox.component.html',
	styleUrls: ['checkbox.component.scss']
})
export class CheckboxComponent implements OnInit {
	@Input() public name: string = 'checkbox';
	@Input() public label: string = '';

	@Output() public valueChange: EventEmitter<boolean> = new EventEmitter<boolean>();

	@Input('value')
	set model(value: boolean) {
		this.checkBoxValue = value;
		this.valueChange.emit(this.checkBoxValue);
	}

	get model() {
		return this.checkBoxValue;
	}
	private id: string = '';
	private checkBoxValue: boolean = false;

	public ngOnInit(): void {
		this.id = getID();
	}
}
