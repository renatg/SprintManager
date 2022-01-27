import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {catchError, map, tap} from 'rxjs/operators';
import {Observable, of} from "rxjs";
import {BaseService} from "./base.service";
import { IRole } from '../registration/registration.component';
import {IUserDto, User } from '../models/auth/user.model';
import {Credentials} from "../models/auth/credentials.model";
import {JwtHelperService} from "@auth0/angular-jwt";
import {JwtModel} from "../models/auth/jwt.model";

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService extends BaseService {
    private url = '/api/Authorization/';
    private static headers: HttpHeaders = new HttpHeaders({
        'X-Requested-With': 'XMLHttpRequest'
    });

    public ErrorMessage = "";

    constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
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

    public isAuthenticated(): boolean {
        const token = localStorage.getItem('jwt');

        return (token != null) && !this.jwtHelper.isTokenExpired(token);
    }

    login(credentials: Credentials): Observable<boolean> {

        return this.http
            .post<JwtModel>(this.url + 'login', credentials)
            .pipe(
                tap(res => {
                    this.loginUser(res);
                }),
            map(res => {
                return true;
            }),
            catchError((err, caught) => {
                this.ErrorMessage = err.error.errorText;
                this.handleError(err);
                return of(false);
                })
            )
    }

    loginUser(jwt: JwtModel) {
        const token = jwt.jwt;
        localStorage.setItem("jwt", token);
    }
}
