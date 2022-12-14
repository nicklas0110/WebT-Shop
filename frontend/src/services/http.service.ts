import { Injectable } from '@angular/core';
import axios from "axios";
import {MatSnackBar} from "@angular/material/snack-bar";
import {catchError} from "rxjs";
import {ItemDto} from "../app/adminpage/adminitem/ItemDto";
import {Category, CategoryDto} from "../app/adminpage/admincatgory/CategoryDto";

export const customAxios = axios.create({
  baseURL: 'https://localhost:7153'
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
  async editOption(id : any, dto: { name: string; optionGroupId: Number}) {
    const httpResponse = await customAxios.put('option/Edit/' + id, dto)
    return httpResponse.data;
  }

  async getOptionGroups() {
    const httpResponse = await customAxios.get('optiongroup');
    return httpResponse.data;
  }

  async createOptionGroup(dto: { name: string }) {
    const httpResponse = await customAxios.post('optiongroup',dto)
    return httpResponse.data;
  }

  async editOptionGroup(id: any, dto: { name: string }) {
    const httpResponse = await customAxios.put('OptionGroup/Edit/' + id,dto)
    return httpResponse.data;
  }

  async getItems() {
    const httpResponse = await customAxios.get('item');
    return httpResponse.data;
  }
  async createItem(dto: ItemDto) {
    const httpResponse = await customAxios.post('item',dto)
    return httpResponse.data
  }

  async editItem(id: any, dto: {name: string; price: number; itemCategoryId: number; optionIds: number[];} ) {
    const httpResponse = await customAxios.put('Item/Edit/' + id,dto)
    return httpResponse.data;
  }

  async getCategorys() {
    const httpResponse = await customAxios.get('category');
    return httpResponse.data;
  }


  async createCategory(dto: { categoryName: string }) {
    const httpResponse = await customAxios.post('category',dto)
    return httpResponse.data;
  }

  async editCategory(id: any, dto: { categoryName: string }) {
    const httpResponse = await customAxios.put('Category/Edit/' + id,dto)
    return httpResponse.data;
  }


  async deleteEditCategory(id: number, dto: { deletedAt: string; id: number }) {
    const httpResponse = await customAxios.put('Category/Delete/' + id,dto)
    return httpResponse.data;
  }

  async deleteEditItem(id: number) {
    const httpResponse = await customAxios.put('Item/Delete/' + id)
    return httpResponse.data;
  }
}
