import { FillInvoice } from './../_models/fill-invoice';
import { ItemsInfoService } from './../_service/items-info.service';
import { ItemsDetails } from './../_models/items-details';
import { Customer } from './../_models/customer';
import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../_service/customers.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-fill-invoice',
  templateUrl: './fill-invoice.component.html',
  styleUrls: ['./fill-invoice.component.css']
})
export class FillInvoiceComponent implements OnInit {

  constructor(public CustomersService: CustomersService, public ItemsInfoService:ItemsInfoService, public router:Router,public toastr: ToastrService) { }
  idCst:number[]=[];
  itemsnames:number[]=[];
  allCst:Customer[]=[];
  allItems:ItemsDetails[]=[];
  unitPrice:any;
  totalPriceForOne:any;
  priceForOne:any;
  groups:FillInvoice[]=[];
   fieldArray: Array<any> = [];
   newAttribute: any = {};
   quantity:any;
   totalPrc:any;

  ngOnInit(): void {

    this.CustomersService.getAllCustomers().subscribe(a=>{
      this.allCst=a;
      console.log(a);
    })
   this.getItemsNames();
   this.fieldArray.push(this.newAttribute)
  this.newAttribute = {};
    // this.ItemsInfoService.getAllItems().subscribe(a=>{
    //   this.allItems=a;
    //   console.log(a);
    // })

  }
getItemsNames(){
  this.ItemsInfoService.getAllItems().subscribe(a=>{
    this.allItems=a;
    console.log(a);
  })
}
getPrice(itm:any){
  this.ItemsInfoService.getPriceById(itm).subscribe(a=>{
    this.unitPrice=a;
    console.log(a);
  })
}

calculateTotalEach(quantity:any,unitPrice:any){
  debugger;
  this.totalPriceForOne=quantity*unitPrice;
  console.log(this.totalPriceForOne);

}

addRow(){
  debugger;
  this.fieldArray.push(this.newAttribute)
  this.newAttribute = {};
}
deleteRow(index:any){
  this.fieldArray.splice(index, 1);
}

//   addRow(index) {
//     this.newDynamic = {title1: "", title2: "",title3:""};
//     this.dynamicArray.push(this.newDynamic);
//    this.toastr.success('New row added successfully', 'New Row');
//     console.log(this.dynamicArray);
//     return true;
// }

// deleteRow(index) {
//     if(this.dynamicArray.length ==1) {
//       this.toastr.error("Can't delete the row when there is only one row", 'Warning');
//         return false;
//     } else {
//         this.dynamicArray.splice(index, 1);
//         this.toastr.warning('Row deleted successfully', 'Delete row');
//         return true;
//     }  }

}
