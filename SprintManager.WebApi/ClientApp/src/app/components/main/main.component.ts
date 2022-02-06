import { Component, OnInit } from '@angular/core';
import { MenuItem } from "primeng/api";
import {AuthorizationService} from "../../services/authorization.service";
import {Router} from "@angular/router";

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

    items: MenuItem[];
    userName: string;

    constructor(private authorizationService: AuthorizationService, private router: Router) {
        this.userName = this.authorizationService.getUserName();
    }

    ngOnInit(): void {
        this.items = [
            {
                label: 'New Sprint',
                icon: 'pi pi-fw pi-plus',
            },
            {
                label: 'New Task',
                icon: 'pi pi-fw pi-plus',
            }
        ];
    }

    logout() {
        this.authorizationService.logout();
        this.router.navigate(['login']);
    }
}
