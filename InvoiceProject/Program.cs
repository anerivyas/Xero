/*
    Welcome to the Xero technical excercise!
    ---------------------------------------------------------------------------------
    The test consists of a small invoice application that has a number of issues.

    Your job is to fix them and make sure you can perform the functions in each method below.

    Note your first job is to get the solution compiling!

    Rules
    ---------------------------------------------------------------------------------
    * The entire solution must be written in C# (any version)
    * You can modify any of the code in this solution, split out classes, add projects etc
    * You can modify Invoice and InvoiceLine, rename and add methods, change property types (hint)
    * Feel free to use any libraries or frameworks you like as long as they are .NET based
    * Feel free to write tests (hint)
    * Show off your skills!

    Good luck :)

    When you have finished the solution please zip it up and email it back to the recruiter or developer who sent it to you
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace InvoiceProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Xero Tech Test!");

            CreateInvoiceWithOneItem();
            CreateInvoiceWithMultipleItemsAndQuantities();
            RemoveInvoiceItem();
            MergeInvoices();
            CloneInvoice();
            InvoiceToString();
        }

        #region Create invoice with one item

        private static void CreateInvoiceWithOneItem()
        {
            Invoice invoice = new Invoice();
            List<InvoiceLine> invoiceLine = new List<InvoiceLine>();

            invoice.LineItems = invoiceLine;

            invoice.InvoiceNumber = 1;

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99,
                Quantity = 1,
                Description = "Apple"
            });


            GetTotal(invoice);

        }

        #endregion

        #region Get the total of an invoice. Cost * Quantity

        public static void GetTotal(Invoice invoice)
        {


            foreach (var i in invoice.LineItems)
            {
                var cost = i.Cost;
                var quantity = i.Quantity;
                var itemDescription = i.Description;

                string invoiceNumber = Convert.ToString(invoice.InvoiceNumber);

                Console.WriteLine("Invoice Number: " + invoiceNumber + ". Cost for the " + itemDescription + " is; $" + (cost * quantity));
            }


        }

        #endregion

        #region Create invoice with multiple items

        private static void CreateInvoiceWithMultipleItemsAndQuantities()
        {
            Invoice invoice = new Invoice();
            List<InvoiceLine> invoiceLine = new List<InvoiceLine>();

            invoice.LineItems = invoiceLine;

            invoice.InvoiceNumber = 2;

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = (double)10.21m,
                Quantity = 4,
                Description = "Banana"
            });

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21,
                Quantity = 1,
                Description = "Orange"
            });

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21,
                Quantity = 5,
                Description = "Pineapple"
            });

            GetTotal(invoice);

        }

        #endregion

        #region Remove item from invoice

        // In this specific example we remove item at position 1

        private static void RemoveInvoiceItem()
        {
            Invoice invoice = new Invoice();
            List<InvoiceLine> invoiceLine = new List<InvoiceLine>();

            invoice.LineItems = invoiceLine;

            invoice.InvoiceNumber = 3;

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21,
                Quantity = 1,
                Description = "Orange"
            });

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 10.99,
                Quantity = 4,
                Description = "Banana"
            });

            invoiceLine.RemoveAt(1);
            GetTotal(invoice);

        }

        #endregion

        #region Merge two invoices

        private static void MergeInvoices()
        {
            Invoice invoice1 = new Invoice();
            List<InvoiceLine> invoiceLine1 = new List<InvoiceLine>();

            invoice1.LineItems = invoiceLine1;

            invoice1.InvoiceNumber = 4;

            invoiceLine1.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33,
                Quantity = 4,
                Description = "Banana"
            });

            Invoice invoice2 = new Invoice();
            List<InvoiceLine> invoiceline2 = new List<InvoiceLine>();

            invoice2.LineItems = invoiceline2;

            invoice2.InvoiceNumber = 4;

            invoiceline2.Add(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.22,
                Quantity = 1,
                Description = "Orange"
            });

            invoiceline2.Add(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 6.27,
                Quantity = 3,
                Description = "Blueberries"
            });

            Invoice invoiceMerged = new Invoice();
            List<InvoiceLine> invoiceLine3 = new List<InvoiceLine>();

            invoiceMerged.InvoiceNumber = 4;


            var merged = new List<InvoiceLine>(invoiceLine1);

            merged.AddRange(invoiceline2);

            invoiceMerged.LineItems = merged;

            GetTotal(invoiceMerged);

        }

        #endregion

        #region Deep clone invoice

        private static void CloneInvoice()
        {
            Invoice invoice = new Invoice();
            List<InvoiceLine> invoiceLine = new List<InvoiceLine>();

            invoice.LineItems = invoiceLine;

            invoice.InvoiceNumber = 5;

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99,
                Quantity = 1,
                Description = "Apple"
            });

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 6.27,
                Quantity = 3,
                Description = "Blueberries"
            });


            Invoice invoice2 = invoice.DeepCopy();

            GetTotal(invoice);


        }

        #endregion

        #region Create invoice into a string

        private static void InvoiceToString()
        {

            DateTime invoiceDate = DateTime.ParseExact(DateTime.Now.ToString("dd'/'MM'/'yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Invoice invoice = new Invoice();
            List<InvoiceLine> invoiceLine = new List<InvoiceLine>();

            invoice.LineItems = invoiceLine;

            invoice.InvoiceDate = invoiceDate;
            invoice.InvoiceNumber = 1000;

            invoiceLine.Add(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99,
                Quantity = 1,
                Description = "Apple"
            });

            var count = invoiceLine.Count;

            invoice.LineItemCount = count;

            var json = JsonConvert.SerializeObject(invoice);
            Console.WriteLine(json);

            Console.WriteLine("Thank you for taking out the time to review my code!");

        }

        #endregion

    }
}

