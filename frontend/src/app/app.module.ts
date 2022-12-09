
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule} from "@angular/forms";
import {MatCardModule} from "@angular/material/card";
import { LoginComponent } from './login/login.component';
import { UserpageComponent } from './userpage/userpage.component';
import { SuperadminComponent } from './superadmin/superadmin.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import {RouterModule, RouterOutlet, Routes} from "@angular/router";

const route: Routes = [
  {
    path: 'userpage', component: UserpageComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'adminpage', component: AdminpageComponent
  },
  {
    path: 'superadmin', component: SuperadminComponent
  }

]


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserpageComponent,
    SuperadminComponent,
    AdminpageComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    FormsModule,
    MatCardModule,
    RouterModule.forRoot(route)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
