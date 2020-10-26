using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace InvoiceProject
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems { get; set; }
        public int LineItemCount { get; set;}

        public Invoice DeepCopy()
        {


            Invoice temp = (Invoice)this.MemberwiseClone();
            temp.InvoiceNumber = this.InvoiceNumber;
            temp.InvoiceDate = this.InvoiceDate;
            temp.LineItems = new List<InvoiceLine>(this.LineItems);


            return temp;
        }
    }

    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }


    }
}
