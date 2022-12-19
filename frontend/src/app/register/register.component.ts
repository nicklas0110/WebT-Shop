import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { HttpService } from '../../services/http.service';
import { Token } from 'src/services/authguard.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  email: any;
  password: any;
  balance: any;
  role: any;
  decodedToken: Token = new Token;

  constructor(private http: HttpService, private router: Router) { }

  ngOnInit(): void {
  }

  async register() {
    let dto = {
      email: this.email,
      password: this.password,
      balance: this.balance,
      role: 'User'
    }
    var token = await this.http.register(dto);
    localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    decodedToken.role = 'User'
    this.router.navigateByUrl('/');
  }
}
