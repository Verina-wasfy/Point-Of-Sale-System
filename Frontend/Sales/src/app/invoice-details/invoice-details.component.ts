import { FillInvoice } from './../_models/fill-invoice';
import { InvoicesService } from './../_service/invoices.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {

  constructor(public router:Router,public InvoicesService:InvoicesService,private ac:ActivatedRoute) { }
invoiceDetails:FillInvoice[]= [];


  ngOnInit(): void {

    this.ac.params.subscribe(params=>{
      this.InvoicesService.getInvoiceById(params.id).subscribe(result => {
      this.invoiceDetails=result;

      console.log(this.invoiceDetails)
 });
})

  
  }

}