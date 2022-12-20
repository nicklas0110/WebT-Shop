import { Token } from 'src/services/authguard.service';
import { Component, OnInit } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { HttpService } from 'src/services/http.service';
import { Router } from '@angular/router';
import { Balance } from './balanceDto';

@Component({
  selector: 'app-dialog-bal',
  templateUrl: './dialog-bal.component.html',
  styleUrls: ['./dialog-bal.component.scss']
})
export class DialogBalComponent implements OnInit {
  userId: any;
  balance: number = 0;
  user: Token | undefined;
  formModule : Balance = new Balance();

  constructor(private http: HttpService, private router: Router) { }

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
    console.log(this.user);
  }

  async addBalance() {
    let dto : Balance = {
      balance: this.formModule.balance,
      userId: this.formModule.userId

    }

    var token = await this.http.addBalance(this.formModule.userId, dto);
    console.log(this.formModule.userId);
    localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    decodedToken.balance = this.formModule.balance
    decodedToken.id = this.formModule.userId
    console.log(this.formModule.userId);

  }

}
