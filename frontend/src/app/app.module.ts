
import {Injectable, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatCardModule} from "@angular/material/card";
import { LoginComponent } from './login/login.component';
import { UserpageComponent } from './userpage/userpage.component';
import { SuperadminComponent } from './superadmin/superadmin.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import {RouterModule, RouterOutlet, Routes} from "@angular/router";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Overlay} from "@angular/cdk/overlay";
import {MatInputModule} from "@angular/material/input";
import { AdminitemComponent } from './adminpage/adminitem/adminitem.component';
import { AdminoptiongroupComponent } from './adminpage/adminoptiongroup/adminoptiongroup.component';
import { AdmincategoryComponent } from './adminpage/admincatgory/admincategory.component';
import {MatSelectModule} from "@angular/material/select";
import { AndminoptionComponent } from './adminpage/andminoption/andminoption.component';


const route: Routes = [
  {
    path: 'userpage', component: UserpageComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'adminpage', component: AdminpageComponent,
  },
  {
    path: 'adminoption', component: AndminoptionComponent,
  },
  {
    path: 'admincategory', component: AdmincategoryComponent,
  },
  {
    path: 'adminitem', component: AdminitemComponent,
  },
  {
    path: 'adminoptiongroup', component: AdminoptiongroupComponent,
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
    AdminpageComponent,
    AdminitemComponent,
    AdminoptiongroupComponent,
    AdmincategoryComponent,
    AndminoptionComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    FormsModule,
    MatCardModule,
    RouterModule.forRoot(route),
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSelectModule
  ],
  providers: [MatSnackBar, Overlay],
  bootstrap: [AppComponent]
})
// @ts-ignore
export class AppModule {

}
