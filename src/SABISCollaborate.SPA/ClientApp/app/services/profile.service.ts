import { Inject, Injectable } from '@angular/core';
import { Gender, MaritalStatus } from '../shared/models';

@Injectable()
export class ProfileService {

    constructor( @Inject('ORIGIN_URL') private originUrl: string) {

    }

    getProfilePictureUrl(pictureId: string): string {
        var pictureUrl = '/img/user-avatar.jpg';

        if (pictureId) {
            pictureUrl = this.originUrl + '/api/management/profile/picture?fileId=' + pictureId;
        }

        return pictureUrl;
    }
}