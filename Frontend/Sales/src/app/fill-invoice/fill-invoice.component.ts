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

  constructor(public CustomersService: CustomersService,  public router:Router,private toastr: ToastrService) { }
  idCst:number[]=[];
  allCst:Customer[]=[];



  ngOnInit(): void {

    this.CustomersService.getAllCustomers().subscribe(a=>{
      this.allCst=a;
      console.log(a);
    })

  }

//   addRow(index) {
//     this.newDynamic = {title1: "", title2: "",title3:""};
//     this.dynamicArray.push(this.newDynamic);
//     this.toastr.success('New row added successfully', 'New Row');
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
