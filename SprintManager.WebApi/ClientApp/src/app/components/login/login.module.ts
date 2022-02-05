import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from "primeng/card";
import { InputTextModule } from "primeng/inputtext";
import { FormsModule } from "@angular/forms";
import { PasswordModule } from "primeng/password";
import { ButtonModule } from "primeng/button";
import { LoginComponent } from "./login.component";

@NgModule({
    declarations: [LoginComponent],
    imports: [
        CommonModule,
        CardModule,
        InputTextModule,
        FormsModule,
        PasswordModule,
        ButtonModule
    ]
})

export class LoginModule { }
