import { FillInvoice } from './../_models/fill-invoice';
import { ItemsInfoService } from './../_service/items-info.service';
import { ItemsDetails } from './../_models/items-details';
import { Customer } from './../_models/customer';
import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../_service/customers.service';
import { Router } from '@angular/router';

import { InvoicesService } from './../_service/invoices.service';


@Component({
  selector: 'app-fill-invoice',
  templateUrl: './fill-invoice.component.html',
  styleUrls: ['./fill-invoice.component.css']
})
export class FillInvoiceComponent implements OnInit {

  constructor(public CustomersService: CustomersService, public ItemsInfoService:ItemsInfoService, public router:Router,public InvoicesService:InvoicesService ) { }
  nameCst:string="";
  itemsnames:number[]=[];
  allCst:Customer[]=[];
  allItems:ItemsDetails[]=[];
  unitPrice:any[]=[];
  totalPriceForOne:any[]=[];
  priceForOne:any;
  groups:FillInvoice[]=[];
   fieldArray: Array<any> = [];
   newAttribute: any = {};
   quantity:any;
   totalPrc:any;
   totalItems:number=0;
   sumBill:number=0;
   objToBeSent:FillInvoice=new FillInvoice();
   itmsNam:any[]=[];
   tQuan:any[]=[];


  ngOnInit(): void {
    this.CustomersService.getAllCustomers().subscribe(a=>{
      this.allCst=a;
      console.log(a);
    })
   this.getItemsNames();
   this.fieldArray.push(this.newAttribute)
  this.newAttribute = {};
  }

getItemsNames(){
  this.ItemsInfoService.getAllItems().subscribe(a=>{
    this.allItems=a;
    console.log(a);
  })
}
getPrice(itm:any){
  this.ItemsInfoService.getPriceById(itm).subscribe(a=>{
    this.unitPrice.push(a);
    this.itemsnames.push(itm);
    console.log(a);
  })
}

calculateTotalEach(quantity:any,unitPrice:any){
let x=quantity*unitPrice;
this.totalItems=this.totalPriceForOne.length+1;
  this.totalPriceForOne.push(x);
  this.tQuan.push(quantity);


  console.log(this.totalPriceForOne);
this.sumBill+=x;

}

addRow(){

  this.fieldArray.push(this.newAttribute)
  this.newAttribute = {};


}
deleteRow(index:any){
  this.fieldArray.splice(index, 1);
  let x=this.totalPriceForOne[index];
  console.log(x);
  let y =this.unitPrice[index];
  console.log(y);
  let id=this.totalPriceForOne.indexOf(x);
  this.totalPriceForOne.splice(id,1);
  this.unitPrice.splice(id,1);
 this.sumBill-=x;
  this.totalItems= this.totalItems-1;
}
clearAll(){
  this.fieldArray.splice(0);
  this.nameCst=" ";
}

//send data to backend
addBill(){

  this.objToBeSent.cX_Name=this.nameCst;
  this.objToBeSent.total_Price=this.sumBill;
  this.objToBeSent.total_Quantity=this.totalItems;

  this.objToBeSent.unit_Price=this.unitPrice;
  this.objToBeSent.tPrice_PerTotalItems=this.totalPriceForOne;
  this.objToBeSent.tQuantity_PerItem=this.tQuan;
  this.objToBeSent.item_Name=this.itemsnames;

  console.log(this.objToBeSent);

  this.InvoicesService.addInvoice(this.objToBeSent).subscribe(a=>{

  this.router.navigateByUrl('/allInvoices')
})
}
}
