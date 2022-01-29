import { Component, OnInit } from '@angular/core';
import { User } from '../../models/auth/user.model';
import { AuthorizationService } from '../../services/authorization.service';

export interface IRole {
    name: string,
    id: number
}

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

    user: User;
    roles: IRole[];
    selectedRole: IRole;

    constructor(private registrationService: AuthorizationService) {
        this.user = new User();
    }

    ngOnInit(): void {
        this.getRoles();
    }

    getRoles() {
        this.registrationService.getRoles().subscribe(roles => this.roles = roles);
    }

    register() {
        this.user.roleId = this.selectedRole.id;
        this.registrationService.registration(this.user)?.subscribe();
    }

}
