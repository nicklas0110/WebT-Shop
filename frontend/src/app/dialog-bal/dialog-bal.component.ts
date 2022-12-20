import { Token } from 'src/services/authguard.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { HttpService } from 'src/services/http.service';
import { Router } from '@angular/router';
import { Balance } from './balanceDto';
import {FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dialog-bal',
  templateUrl: './dialog-bal.component.html',
  styleUrls: ['./dialog-bal.component.scss']
})
export class DialogBalComponent implements OnInit {

  user: Token | undefined;

  balanceForm: FormGroup = new FormGroup({
    balance: new FormControl(0, [Validators.required])
  });

  @Output() balanceChange: EventEmitter<number> = new EventEmitter<number>();

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
    this.user = token ? jwtDecode(token!) as Token : undefined;
  }

  async addBalance() {
    console.log(this.user?.id);
    if (this.user?.id && this.balanceForm.valid) {
      const res = await this.http.addBalance(this.user.id, this.balanceForm.value);
      this.balanceChange.emit(res);
    }
  }

}
