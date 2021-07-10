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
  nameCst:string="";
  itemsnames:number[]=[];
  //allCst:Customer[]=[];
  //allItems:ItemsDetails[]=[];
  unitPrice:any[]=[];
  totalPriceForOne:any[]=[];
  priceForOne:any;
 // groups:FillInvoice[]=[];
  
   quantity:any;
   totalPrc:any;
   totalItems:number=0;
   sumBill:number=0;
   objToBeEdit:FillInvoice=new FillInvoice();
   itmsNam:any[]=[];
   tQuan:any[]=[];
  
  ngOnInit(): void {

    this.getItemsNames();
   this.fieldArray.push(this.newAttribute)
  this.newAttribute = {};
  this.ac.params.subscribe(par=>{
    this.InvoicesService.getInvoiceById(par.id).subscribe(result => {
    this.invoiceDetails=result;
    console.log(result);
     
    console.log(this.invoiceDetails)
});
})


  }
getItemsNames(){
  this.ItemsInfoService.getAllItems().subscribe(a=>{
    this.allItems=a;
    console.log(a);
  })
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

//send edited version
saveEdit(){

  debugger;
  console.log(this.objToBeEdit);

  this.InvoicesService.addInvoice(this.objToBeEdit).subscribe(a=>{

  this.router.navigateByUrl('/allInvoices')
})
}
}
