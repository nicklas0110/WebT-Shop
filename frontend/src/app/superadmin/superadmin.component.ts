import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { HttpService } from 'src/services/http.service';
import { Token } from 'src/services/authguard.service';

@Component({
  selector: 'app-superadmin',
  templateUrl: './superadmin.component.html',
  styleUrls: ['./superadmin.component.scss']
})

export class SuperadminComponent implements OnInit {
  email: any;
  password: any;
  balance: any;
  role: any;
  decodedToken: Token = new Token;

  constructor(private http: HttpService, private router: Router) { }

  ngOnInit(): void {
  }

  async registerAdmin() {
    let dto = {
      email: this.email,
      password: this.password,
      balance: this.balance,
      role: 'Admin'
    }
    var token = await this.http.register(dto);
    localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    decodedToken.role = 'Admin'
    this.router.navigateByUrl('/');
  }

}
