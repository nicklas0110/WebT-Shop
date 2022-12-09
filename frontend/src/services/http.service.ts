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

  async getOption(){
    const httpResponse = await customAxios.get('option');
    return httpResponse.data;
  }

  async createBox(dto: {name: any;}) {
    const httpResponse = await customAxios.post('option',dto)
    return httpResponse.data;
  }
}
