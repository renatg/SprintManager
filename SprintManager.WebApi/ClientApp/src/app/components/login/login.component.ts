import { Component, OnInit } from '@angular/core';
import { Credentials } from "../../models/auth/credentials.model";
import { AuthorizationService } from "../../services/authorization.service";
import { Router } from "@angular/router";
import { MessageService } from '../../services/message.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    providers: [ MessageService ]
})
export class LoginComponent implements OnInit {
    credential: Credentials;
    errorMessage: string = "";

    constructor(private authorizationService: AuthorizationService, private router: Router,
                private messageService: MessageService) {
        this.credential = new Credentials();
    }

    ngOnInit() {}

    loginUser() {
        this.authorizationService.login(this.credential).subscribe(res => {
            if (res) {
                this.router.navigate(['/']);
            }
            else {
                this.errorMessage = this.authorizationService.ErrorMessage;
                if (this.errorMessage) {
                    this.messageService.showError(this.errorMessage);
                }
            }
        });
    }

    signUp() {
        this.router.navigate(['signup']);
    }
}
