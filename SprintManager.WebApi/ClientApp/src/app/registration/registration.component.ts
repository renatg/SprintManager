import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';

export interface Role {
  name: string,
  id: number
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  login: string;
  password: string;
  email: string;
  roles: Role[];
  selectedRole: Role;

  constructor(private registrationService: RegistrationService) { }

  ngOnInit(): void {
    this.getRoles();
  }

  getRoles() {
    this.registrationService.getRoles().subscribe(roles => this.roles = roles);
  }

}
