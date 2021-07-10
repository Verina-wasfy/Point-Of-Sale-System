import { FillInvoiceComponent } from './fill-invoice/fill-invoice.component';
import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { InvoicesComponent } from './invoices/invoices.component';
import{NotFoundComponent} from './not-found/not-found.component';



const routes: Routes = [
  {path : "" , component:InvoicesComponent },
  {path : "allInvoices" , component:InvoicesComponent },
  {path : "fillInvoice" , component:FillInvoiceComponent },
  {path : "**" , component:NotFoundComponent },

];



export const RoutingComponents = [
  InvoicesComponent
]


const routerOptions: ExtraOptions = {
  useHash: false,
  anchorScrolling: 'enabled',
  // ...any other options you'd like to use
};
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
