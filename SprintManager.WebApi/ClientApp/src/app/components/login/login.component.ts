import { Component, OnInit } from '@angular/core';
import {Credentials} from "../../models/auth/credentials.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  credential: Credentials;
  constructor() {
    this.credential = new Credentials();
  }

  ngOnInit(): void { }

}
