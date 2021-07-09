import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invoice } from 'src/app/_models/invoice';
@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  constructor(private http: HttpClient) { }

  getAllInvoices(){
    return this.http.get<Invoice[]>("https://localhost:44365/api/AllInvoices/Invoices");
  }

  getInvoiceById(){
    return this.http.get<Invoice[]>("juh");
  }
}
