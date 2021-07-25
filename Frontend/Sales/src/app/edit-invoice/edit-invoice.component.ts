import { InvoicesService } from './../_service/invoices.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemsDetails } from '../_models/items-details';
import { ItemsInfoService } from './../_service/items-info.service';
import { FillInvoice } from '../_models/fill-invoice';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.css']
})
export class EditInvoiceComponent implements OnInit {

  constructor(public router:Router, public InvoicesService:InvoicesService,public ItemsInfoService:ItemsInfoService,private ac:ActivatedRoute) { }
  invoiceDetails:FillInvoice=new FillInvoice();
  fieldArray: Array<any> = [];
  newAttribute: any = {};
  allItems:ItemsDetails[]=[];
  // nameCst:string="";
  // itemsnames:number[]=[];
  //allCst:Customer[]=[];
  //allItems:ItemsDetails[]=[];
  unitPrice:any[]=[];
  totalPriceForOne:any[]=[];
  priceForOne:any;
 // groups:FillInvoice[]=[];

   quantity:any;
   totalPrc:any;
  //  totalItems:number=0;
   sumBill:number=0;
   objToBeEdit:FillInvoice=new FillInvoice();
   itmsNam:any=[];
  //  tQuan:any=[];
   tun:any=[];
   ttotoal:any=[]

//details
   test:any=[];
  priceOne:any=[];
  quan:any=[];
  tPrice:any;
  tQuan:any;
  nameItm:any;
  namess:any=[];


  ngOnInit(): void {

    this.getItemsNames();
   //this.fieldArray.push(this.newAttribute)
  this.newAttribute ={};
  this.ac.params.subscribe(par=>{
    this.InvoicesService.getInvoiceById(par.id).subscribe(result => {
    this.invoiceDetails=result;
    this.test=this.invoiceDetails.tPrice_PerTotalItems;
    this.priceOne=this.invoiceDetails.unit_Price;
    this.quan=this.invoiceDetails.tQuantity_PerItem;
    this.itmsNam=this.invoiceDetails.item_Name;
    this.tPrice=this.invoiceDetails.total_Price;
    this.tQuan=this.invoiceDetails.total_Quantity
    console.log(result);
      this.namess= this.itmsNam;
    console.log(this.invoiceDetails)
});
})


  }
getItemsNames(){
  this.ItemsInfoService.getAllItems().subscribe(a=>{
    this.allItems=a;
    console.log(a);
    // this.itmsNam.push(this.nameItm);

  })
}

addRow(){
  this.itmsNam.push(this.nameItm)
  //this.test.push(this.newAttribute)
  // this.priceOne.push(this.newAttribute)
 // this.quan.push(this.newAttribute)

  this.newAttribute = this.nameItm;
  // this.itmsNam.push(this.nameItm);
}

deleteRow(index:any){
  this.itmsNam.splice(index, 1);
  let x=this.test[index];
  console.log(x);
  let y =this.unitPrice[index];
  console.log(y);
  let id=this.test.indexOf(x);
  this.test.splice(id,1);
  this.priceOne.splice(id,1);
 this.tPrice-=x;
  this.tQuan= this.tQuan-1;
}
clearAll(){
  this.itmsNam.splice(0);

}

getPrice(itm:any,index:any){
  console.log(itm);
  this.ItemsInfoService.getPriceById(itm).subscribe(a=>{
    this.priceOne.push(a);
    this.nameItm=itm;
    console.log(typeof(this.nameItm));
  //  this.namess.push(itm);
    // this.itmsNam.push(itm);
    console.log(this.priceOne);
  })
}

calculateTotalEach(quantity:any,unitPrice:any){
let x=quantity*unitPrice;
this.tQuan=this.priceOne.length;
  this.test.push(x);
  console.log(typeof(quantity));
  this.quan.push(Number(quantity));
 // this.namess.push(this.nameItm);
  // console.log(this.totalItems);
this.tPrice+=x;

}

//send edited version
saveEdit(){
  debugger;

  this.objToBeEdit.cX_ID=this.invoiceDetails.cX_ID;
  this.objToBeEdit.total_Price=this.tPrice;
  this.objToBeEdit.total_Quantity=this.tQuan;
  this.objToBeEdit.unit_Price=this.priceOne;
  this.objToBeEdit.tPrice_PerTotalItems=this.test;
  this.objToBeEdit.tQuantity_PerItem=this.quan;
  this.objToBeEdit.item_Name=this.itmsNam;
  this.objToBeEdit.invoice_ID=this.invoiceDetails.invoice_ID;
  this.objToBeEdit.invoice_Date=this.invoiceDetails.invoice_Date;

  console.log(this.objToBeEdit);

  this.InvoicesService.editInvoice(this.objToBeEdit).subscribe(a=>{

  this.router.navigateByUrl('/allInvoices')
})
}
}
