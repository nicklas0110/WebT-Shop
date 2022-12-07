import { Injectable } from '@angular/core';

import axios from "axios";
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5111'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private matSnackbar: MatSnackBar) {
    customAxios.interceptors.response.use(
      response => {
        if(response.status == 201){
          this.matSnackbar.open("Great Success")
        }
        return response
      },
      rejected => {
        if (rejected.response.status>= 400 && rejected.response.status <500){
          matSnackbar.open(rejected.response.data);
        }else if (rejected.response.status>499){
          this.matSnackbar.open("Something Went Wrong")
        }
        catchError(rejected)
      }
    )
  }

  async GetAllOptions(){
    const httpResponse = await customAxios.get('option');
    return httpResponse.data;
  }


  async createNewOption(dto: {  optionName : any }) {
    const httpResponse = await customAxios.post('',dto)
    return httpResponse.data;
  }

  async DeleteUpdateOption(id : any) {
    const httpResponse = await customAxios.delete('option/Delete/' + id)
    return httpResponse.data;
  }

  // puts to the backend using an id and the dto class whits also contain an id and edits
  async UpdateOption(id : any, dto: { optionName: any }) {
    const httpResponse = await customAxios.put('option/' + id, dto)
    return httpResponse.data;
  }


}
