import { Component, Output, Input, EventEmitter, SimpleChanges, OnChanges } from '@angular/core';
import { LocalizationService } from '../../services/localization.service';
import { Gender } from '../shared';

@Component({
    selector: 'gender',
    templateUrl: './gender.component.html',
    providers: [LocalizationService]
})

export class GenderComponent implements OnChanges {
    private _localizationService: LocalizationService;

    @Input() selectedGender: Gender;
    @Output() change = new EventEmitter();

    public genderDisplayName: string;

    constructor(localizationService: LocalizationService) {
        this._localizationService = localizationService;
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.genderDisplayName = this._localizationService.getGenderDisplayName(this.selectedGender);
    }

    onSelect(gender: Gender) {
        this.selectedGender = gender;
        this.genderDisplayName = this._localizationService.getGenderDisplayName(gender);

        this.change.emit({ newValue: this.selectedGender });
    }
}