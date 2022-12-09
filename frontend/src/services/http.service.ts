import { Injectable } from '@angular/core';
import axios from "axios";

export const customAxios = axios.create({
  baseURL: 'http://localhost5111'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }
}
