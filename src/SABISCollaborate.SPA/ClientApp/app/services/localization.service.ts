import { Inject, Injectable } from '@angular/core';
import { Gender } from '../shared/shared';

@Injectable()
export class LocalizationService {

    getGenderDisplayName(gender: Gender): string {
        switch (gender) {
            case Gender.Female: {
                return "Female";
            }
            case Gender.Male: {
                return "Male";
            }
            default: {
                return "";
            }
        }
    }
}