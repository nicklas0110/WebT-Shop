import { Injectable } from '@angular/core';
import axios from "axios";
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";

export const customAxios = axios.create({
  baseURL: 'https://localhost:7153',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private matSnackbar: MatSnackBar){
    customAxios.interceptors.response.use(
    response => {
      if(response.status == 201){
        this.matSnackbar.open("Great Success")
      }
      return response
    },
    rejected => {
    //   if (rejected.response.status>= 400 && rejected.response.status <500){
    //     matSnackbar.open(rejected.response.data);
    //   }else if (rejected.response.status>499){
    //     this.matSnackbar.open("Something Went Wrong")
    //   }
     catchError(rejected)
    })
  }

  async getOption(){
    const httpResponse = await customAxios.get('option');
    return httpResponse.data;
  }

  async createOption(dto: { name: string; optionGroupId: Number }) {
    const httpResponse = await customAxios.post('option',dto)
    return httpResponse.data;
  }

  // puts to the backend using an id and the dto class whits also contain an id and edits
  async editOption(id : any, dto: { size: any; type: any; customerName: any }) {
    const httpResponse = await customAxios.put('box/' + id, dto)
    return httpResponse.data;
  }

    async login(dto: any) {
      const httpResult = await customAxios.post('auth/controller/login', dto);
      return httpResult.data;
    }
}
