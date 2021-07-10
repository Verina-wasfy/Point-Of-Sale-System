import { FillInvoice } from './../_models/fill-invoice';
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

  getInvoiceById(id:any){
    return this.http.get<Invoice[]>("https://localhost:44365/api/AllInvoices/Invoice/"+id);
  }

  deleteInvoice(id:any){
    return this.http.delete(
      'https://localhost:44365/api/AllInvoices/DeleteInvoiceDetails/'+id
      );
  }

  addInvoice(filInvoice:FillInvoice){
    return this.http.post(
      'https://localhost:44365/api/AllInvoices/AddInvoice',filInvoice
      );

  }
}
