import { Component, Input, Output, EventEmitter } from '@angular/core';
import { IMultiSelectOption } from 'angular-2-dropdown-multiselect';

@Component({
    selector: 'sc-dropdown',
    templateUrl: './dropdown.component.html'
})

export class DropdownComponent {
    @Input() allOptions: number[];
    @Input() selection: IMultiSelectOption[];
    @Output() selectionChange = new EventEmitter();

    onChange($event): void {
        this.selection = $event;
        this.selectionChange.emit(this.selection);
    }
}

export class DropdownOption implements IMultiSelectOption {
    id: any;
    name: string;
    isLabel?: boolean;
    parentId?: any;
    params?: any;
}