export class FillInvoice {

  constructor(

    public invoice_ID?:number,
    public invoice_Date?:Date,
    public  cX_ID?:number ,
    public  cX_Name?:string ,
    public total_Price?:number ,
    public  total_Quantity?:number ,

    public  tPrice_PerTotalItems?: any[],
    public  tQuantity_PerItem?: any[] ,
    public  item_ID?: any[] ,

    public item_Name?: any[],
    public  unit_Price?: any[] ,

  ){}
}
