import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Role } from './registration/registration.component';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  private url = 'https://localhost:7209/Authorization/GetAllRoles';

  constructor(private http: HttpClient) { }

  getRoles() {
    return this.http.get<Role[]>(this.url)
  }
}
