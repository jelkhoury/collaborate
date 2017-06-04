import { Component, Input } from '@angular/core';

@Component({
    selector: 'sc-datepicker',
    templateUrl: './datepicker.component.html'
})

export class DatepickerComponent {
    @Input() selectedDate: Date;
}
