export class Invoice {
  constructor(
    public  invoice_ID ?:number ,
    public  invoice_Date?:Date,
    public  cX_ID?:number  ,
    public  cX_Name?:string ,
    public  total_Price?:number  ,
    public  total_Quantity?:number ,

  ){}
}
