import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/_models/invoice';
import { InvoicesService } from '../_service/invoices.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  constructor(public InvoicesService: InvoicesService,  public router:Router) { }
  allInvoices:Invoice[]=[];
  Invoicess:Invoice[]=[];
  id:any;


  ngOnInit(): void {
    this.InvoicesService.getAllInvoices().subscribe(a=>{
     this.allInvoices=a;
     this.Invoicess=a;
      console.log(this.allInvoices);
    });


  }

  getSearch(id:any){

    console.log(id);
    console.log(typeof(id));
    debugger;
    if(id!=""){
      this.allInvoices=this.allInvoices.filter(a=>a.invoice_ID==id)
    }
    else{
    this.allInvoices=this.Invoicess;
    ​}
  
   }

}
