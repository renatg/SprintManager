import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { TabViewModule } from 'primeng/tabview';
import { RouterModule, Routes } from '@angular/router';
import { LoginModule } from './components/login/login.module';
import { RegistrationComponent } from './components/registration/registration.component';
import { RegistrationModule } from './components/registration/registration.module';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from "./guards/auth.guard";
import { JwtModule } from "@auth0/angular-jwt";
import { ToastModule } from 'primeng/toast';
import {MessagesModule} from 'primeng/messages';

const appRoutes: Routes = [
  { path: '', component: AppComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegistrationComponent }
]

export function tokenGetter() {
    // @ts-ignore
    return localStorage.getItem["jwt"];
}

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        MenubarModule,
        ButtonModule,
        TabViewModule,
        LoginModule,
        RegistrationModule,
        HttpClientModule,
        ToastModule,
        MessagesModule,
        RouterModule.forRoot(appRoutes),
        JwtModule.forRoot({
            config :{
                tokenGetter: tokenGetter,
                disallowedRoutes: []
            }
        })
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
