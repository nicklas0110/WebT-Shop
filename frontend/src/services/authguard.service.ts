import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";
import jwtDecode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthguardService implements CanActivate {

  constructor() { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        let token = localStorage.getItem('token');
        if(token) {
            let decodedToken = jwtDecode(token) as Token;
            let currentDate = new Date();
            if(decodedToken.exp) {
                let expiry = new Date(decodedToken.exp*1000);
                if(currentDate<expiry && decodedToken.role=='Admin' || currentDate<expiry && decodedToken.role=='SuperAdmin') {
                    return true;
                }
            }
        }
        return false;
    }
}

export class Token {
    exp?: number;
    role?: string;
    email?: string;
    balance?: number;
    id?: number;
}