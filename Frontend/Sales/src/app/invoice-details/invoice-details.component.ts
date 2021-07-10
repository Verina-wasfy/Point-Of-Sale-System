import { InvoicesService } from './../_service/invoices.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {

  constructor(public router:Router,public InvoicesService:InvoicesService) { }

  ngOnInit(): void {
  }

}
