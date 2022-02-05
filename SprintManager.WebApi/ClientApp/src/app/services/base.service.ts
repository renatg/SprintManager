import { Injectable } from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {throwError} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class BaseService {

    constructor() { }

    protected handleError(error: HttpErrorResponse) {
        if (error.status === 0) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('An error occurred:', error.error);
        //this.messageService.showError(error.error);
    } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong.
        console.error(
            `Backend returned code ${error.status}, body was: `, error.error);
        //this.messageService.showError(error.error);
    }

    return throwError(
      'Something bad happened; please try again later.');
    }
}
