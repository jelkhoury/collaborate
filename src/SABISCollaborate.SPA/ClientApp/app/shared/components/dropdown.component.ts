import { Component, Input, Output } from '@angular/core';
import { IMultiSelectOption } from 'angular-2-dropdown-multiselect';

@Component({
    selector: 'sc-dropdown',
    templateUrl: './dropdown.component.html'
})

export class DropdownComponent {
    @Input() allOptions: number[];
    @Input() selection: IMultiSelectOption[];
}

export class DropdownOption implements IMultiSelectOption {
    id: any;
    name: string;
    isLabel?: boolean;
    parentId?: any;
    params?: any;
}