import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, map} from 'rxjs/operators';
import {Observable } from "rxjs";
import {BaseService} from "./base.service";
import { IRole } from '../registration/registration.component';
import {IUserDto, User } from '../models/auth/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService extends BaseService {
  private url = '/api/Authorization/';
  private static headers: HttpHeaders = new HttpHeaders({
    'X-Requested-With': 'XMLHttpRequest'
  });

  constructor(private http: HttpClient) {
    super();
  }

  getRoles() {
    return this.http.get<IRole[]>(this.url+'GetAllRoles');
  }

  registration(user: User) : Observable<User> | null {
    return this.http
      .post<IUserDto>(this.url + 'registration', user, {headers: AuthorizationService.headers})
      .pipe(
        map(z => {
          return User.fromDto(z)
        }),
        catchError(this.handleError));
  }

  checkLoginUnique(login: string) : Observable<boolean> {
    return this.http.get<boolean>(this.url + 'checkLoginUnique', {params: {login: login}});
  }
}
