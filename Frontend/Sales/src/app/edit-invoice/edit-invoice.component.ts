import { InvoicesService } from './../_service/invoices.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ItemsDetails } from '../_models/items-details';
import { ItemsInfoService } from './../_service/items-info.service';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.css']
})
export class EditInvoiceComponent implements OnInit {

  constructor(public router:Router, public InvoicesService:InvoicesService,public ItemsInfoService:ItemsInfoService) { }

  fieldArray: Array<any> = [];
  newAttribute: any = {};
  allItems:ItemsDetails[]=[];

  
  ngOnInit(): void {

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
}
