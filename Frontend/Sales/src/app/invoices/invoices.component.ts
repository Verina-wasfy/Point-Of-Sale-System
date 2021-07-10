import { Customer } from './../_models/customer';
import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/_models/invoice';
import { InvoicesService } from '../_service/invoices.service';
import { Router } from '@angular/router';
import { CustomersService } from '../_service/customers.service';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  constructor(public InvoicesService: InvoicesService,  public customersService: CustomersService,public router:Router) { }
  allInvoices:Invoice[]=[];
  Invoicess:Invoice[]=[];
  id:any;
  toBeDel:any;
  newCX:Customer=new Customer();

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

   deleteInvoice(idD:any){
    debugger;
this.toBeDel=idD;

   }
   delInvoice(){
     debugger;
    this.InvoicesService.deleteInvoice(this.toBeDel).subscribe(a=>{

    })
   }

   delete(){
    debugger;
    this.delInvoice()
    window.location.reload();
   }


   addCst(){
     debugger;
     this.customersService.addCustomer(this.newCX).subscribe(a=>{
     // console.log(this.newCX);
     })

   }

   details(id:any){
  this.router.navigate(['/detailedInvoice/',id])
   }
}
