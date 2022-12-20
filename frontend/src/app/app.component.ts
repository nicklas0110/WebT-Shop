import {Component, OnInit, OnChanges} from '@angular/core';
import {HttpService} from "../services/http.service";
import axios from "axios";
import jwtDecode from 'jwt-decode';
import { Token } from '../services/authguard.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogBalComponent } from './dialog-bal/dialog-bal.component';


export const customAxios = axios.create({
  baseURL: 'http://localhost:5111'
})



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
// @ts-ignore
export class AppComponent implements OnInit {

  user: Token | undefined;

  constructor(private router: Router, public dialog: MatDialog) { }

  ngOnInit(): void {
    // Load user info from jwt when page is changed
    this.router.events.subscribe(() => {
      this.loadUserFromJwt();
    });

    // Load Initial
    this.loadUserFromJwt();
  }

  loadUserFromJwt() {
    const token = localStorage.getItem('token');
    console.log(token);
    this.user = token ? jwtDecode(token!) as Token : undefined;
  }

  logout() {
    localStorage.removeItem('token');
    this.user = undefined;
    this.router.navigateByUrl('/');
  }

  isUserAdmin() {
    return this.user?.role == 'Admin' || this.user?.role == 'SuperAdmin';
  }

  addBal() {
    this.dialog.open(DialogBalComponent);
  }
}
