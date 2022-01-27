import { Component, OnInit } from '@angular/core';
import { Credentials } from "../../models/auth/credentials.model";
import { AuthorizationService } from "../../services/authorization.service";
import { Router } from "@angular/router";
import { MessageService } from 'primeng/api';

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

            this.errorMessage = this.authorizationService.ErrorMessage;
            this.showError(this.errorMessage);
        });
    }

    showError(error: string) {
        console.log(error);
        this.messageService.add({severity:'error', summary: error});
    }
}
