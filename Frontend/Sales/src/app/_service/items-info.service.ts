import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ItemsDetails } from '../_models/items-details';

@Injectable({
  providedIn: 'root'
})
export class ItemsInfoService {

  constructor(private http: HttpClient) { }

  getAllItems(){
    return this.http.get<ItemsDetails[]>("https://localhost:44365/api/Items/Items");
  }

  getPriceById(name:any){
    return this.http.get<string>("https://localhost:44365/api/Items/UnitPrice/"+name);
  }
}
