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
invoiceDetails:FillInvoice=new FillInvoice();
test:any=[];
priceOne:any=[];
quan:any=[];
// unitP:any[]| undefined;



  ngOnInit(): void {

    this.ac.params.subscribe(par=>{
      this.InvoicesService.getInvoiceById(par.id).subscribe(result => {
      this.invoiceDetails=result;
      this.test=this.invoiceDetails.tPrice_PerTotalItems
      this.priceOne=this.invoiceDetails.unit_Price
      this.quan=this.invoiceDetails.tQuantity_PerItem
      // console.log(result);
      console.log(this.test)

      // console.log(this.invoiceDetails)
 });
})
// let x=this.unitP=this.invoiceDetails.tQuantity_PerItem;
    // console.log(x);

  }

}
