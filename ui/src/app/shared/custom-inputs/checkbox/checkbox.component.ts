import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import getID from '../../helpers/generate-id';

@Component({
	selector: 'tdamsh-checkbox',
	templateUrl: 'checkbox.component.html',
	styleUrls: ['checkbox.component.scss']
})
export class CheckboxComponent implements OnInit {
	@Input() public checked: boolean = false;
	@Input() public name: string = 'checkbox';
	@Input() public label: string = '';

	@Input() set data(data: boolean) {
		this.value = data;
		this.onValueChanged.emit(this.value);
	}
	get data() {
		return this.value;
	}

	@Output() public onValueChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

	private id: string = '';
	private value: boolean = false;

	public ngOnInit(): void {
		this.id = getID();
	}

	private onStateChanged(): void {
		this.onValueChanged.emit(this.value);
	}
}
