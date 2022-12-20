
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
// @ts-ignore
import { AdminpageComponent } from './adminpage/adminpage.component';
import {RouterModule, RouterOutlet, Routes} from "@angular/router";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Overlay} from "@angular/cdk/overlay";
import {MatInputModule} from "@angular/material/input";
import {AuthguardService} from "../services/authguard.service";
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatSelectModule} from '@angular/material/select';
import { AndminoptionComponent } from './adminpage/andminoption/andminoption.component';
import { AdmincategoryComponent } from './adminpage/admincatgory/admincategory.component';
import { AdminitemComponent } from './adminpage/adminitem/adminitem.component';
import { AdminoptiongroupComponent } from './adminpage/adminoptiongroup/adminoptiongroup.component';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from "@angular/material/tabs";
import { ItemCardComponent } from './item-card/item-card.component';
import { RegisterComponent } from './register/register.component';
import { MatDialogModule } from '@angular/material/dialog';
import { DialogBalComponent } from './dialog-bal/dialog-bal.component';






const route: Routes = [
  {
    path: '', component: UserpageComponent,
  },
  {
    path: 'login', component: LoginComponent,
  },
    {
        path: 'register', component: RegisterComponent,
    },
  {
    path: 'superadmin', component: SuperadminComponent, canActivate: [AuthguardService]
  },
  {
    path: 'adminpage', component: AdminpageComponent, canActivate: [AuthguardService],
    children: [
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
    ]
  },


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
    AndminoptionComponent,
    ItemCardComponent,
    RegisterComponent,
    DialogBalComponent,

  ],
    entryComponents: [DialogBalComponent],
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
        MatButtonToggleModule,
        MatGridListModule,
        MatSelectModule,
        ReactiveFormsModule,
        CommonModule,
        MatTabsModule,
        MatDialogModule

    ],
  providers: [MatSnackBar, Overlay],
  bootstrap: [AppComponent]
})
// @ts-ignore
export class AppModule {

}
