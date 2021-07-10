import { Customer } from './../_models/customer';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  constructor(private http: HttpClient) { }
  getAllCustomers(){
    return this.http.get<Customer[]>("https://localhost:44365/api/Customer/Customers");
  }

  addCustomer(addCst:Customer){
    return this.http.post(
      'https://localhost:44365/api/Customer',
      addCst
    );

  }
}
