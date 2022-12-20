import {Component, OnInit, OnChanges, ViewChild, TemplateRef} from '@angular/core';
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
  balance: number = 0;

  @ViewChild('balanceDialog') balanceDialog!: TemplateRef<any>;

  constructor(private router: Router, public dialog: MatDialog, private http: HttpService) { }

  ngOnInit(): void {
    // Load user info from jwt when page is changed
    this.router.events.subscribe(() => {
      this.loadUserFromJwt();
    });

    // Load Initial
    this.loadUserFromJwt();

    this.http.balanceChanged.subscribe(
        () => this.updateBalance()
    );
  }

  loadUserFromJwt() {
    const token = localStorage.getItem('token');
    console.log(token);
    this.user = token ? jwtDecode(token!) as Token : undefined;

    this.updateBalance();
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
    this.dialog.open(this.balanceDialog);
  }

  async updateBalance() {
    this.balance = await this.http.getBalance(this.user?.id!);
  }
}
