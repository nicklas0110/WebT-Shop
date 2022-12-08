import { Injectable } from '@angular/core';

import axios from 'axios';

export const costomAxios = axios.create({
  baseURL: 'http://localhost:5111'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getOptions(){
    const httpResponse = await costomAxios.get('option');
    return httpResponse.data;
  }

}
