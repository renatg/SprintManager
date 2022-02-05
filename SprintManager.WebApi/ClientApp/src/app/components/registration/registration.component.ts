import { Component, OnInit } from '@angular/core';
import { User } from '../../models/auth/user.model';
import { AuthorizationService } from '../../services/authorization.service';
import {Router} from "@angular/router";
import {MessageService} from "../../services/message.service";

export interface IRole {
    name: string,
    id: number
}

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss'],
    providers: [ MessageService ]
})
export class RegistrationComponent implements OnInit {

    user: User;
    roles: IRole[];
    selectedRole: IRole;
    errorMessage: string = "";

    constructor(private registrationService: AuthorizationService, private router: Router, private messageService: MessageService) {
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
        this.registrationService
            .registration(this.user)?.subscribe( res => {
                this.errorMessage = this.registrationService.ErrorMessage;
                if (this.errorMessage != '') {
                    this.messageService.showError(this.registrationService.ErrorMessage);
                }

                this.messageService.showSuccess('Register successful');
                this.router.navigate(['login']);
            }
        );
    }

    cancel() {
        this.router.navigate(['login']);
    }

}
