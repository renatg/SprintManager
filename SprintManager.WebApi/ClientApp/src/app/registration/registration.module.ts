import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import {FormsModule} from '@angular/forms';
import {PasswordModule} from 'primeng/password';
import {ButtonModule} from 'primeng/button';
import { RegistrationComponent } from './registration.component';
import {DropdownModule} from 'primeng/dropdown';

@NgModule({
  declarations: [RegistrationComponent],
  imports: [
    CommonModule,
    CardModule,
    InputTextModule,
    FormsModule,
    PasswordModule,
    ButtonModule,
    DropdownModule
  ]
})
export class RegistrationModule { }
