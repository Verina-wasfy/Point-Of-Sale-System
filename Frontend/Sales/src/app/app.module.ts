import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InvoicesComponent } from './invoices/invoices.component';
import { FillInvoiceComponent } from './fill-invoice/fill-invoice.component';


@NgModule({
  declarations: [
    AppComponent,
    InvoicesComponent,
    FillInvoiceComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,FormsModule,ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
