import { Directive } from '@angular/core';
import { AbstractControl, NG_ASYNC_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';
import { AuthorizationService } from "../services/authorization.service";

@Directive({
  selector: '[loginUnique][ngModel]',
  providers: [{provide: NG_ASYNC_VALIDATORS,
    useExisting: LoginUniqueValidatorDirective, multi: true}]
})
export class LoginUniqueValidatorDirective implements Validator{

  constructor(private authorizationService: AuthorizationService) { }

  validate(c: AbstractControl): Promise<{[key: string]: any} | null> {
    const login = c.value;

    return new Promise(resolve => this.authorizationService.checkLoginUnique(login)
      .subscribe(res => res? resolve(null) :
        resolve({userNotUnique: true})));
  }
}


