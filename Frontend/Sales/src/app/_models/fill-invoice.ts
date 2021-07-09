export class FillInvoice {

  constructor(

    public invoice_ID?:number,
    public invoice_Date?:Date,
    public  cX_ID?:number ,
    public  cX_Name?:string ,
    public total_Price?:number ,
    public  total_Quantity?:number ,

    public  tPrice_PerTotalItems?:number ,
    public  tQuantity_PerItem?:number ,
    public  item_ID?:number ,

    public item_Name?:string,
    public  unit_Price?:number ,

  ){}
}
