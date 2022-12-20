import { Token } from 'src/services/authguard.service';
import { Component, OnInit } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { HttpService } from 'src/services/http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dialog-bal',
  templateUrl: './dialog-bal.component.html',
  styleUrls: ['./dialog-bal.component.scss']
})
export class DialogBalComponent implements OnInit {
  userId: undefined;
  balance: any;
  user: Token | undefined;

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
  }

  async addBalance() {
    let dto = {
      balance: this.balance,
      userId: this.userId
    }
    var token = await this.http.addBalance(this.userId, dto);
    localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    decodedToken.balance = this.balance;
  }

}
