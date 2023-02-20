using System;
using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;

namespace CaliperApi.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll();
        Invoice Find(int invoiceId);
        Invoice CreateInvoice(InvoiceDto InvoiceDto);
        InvoiceDto ToInvoiceDto(Invoice Invoice);
        Invoice GetInvoice(int invoiceId);

    }

    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;
        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Invoice> GetAll()
        {
            return _context.Invoices.ToList();
        }

        public Invoice Find(int invoiceId)
        {
            return _context.Invoices.Find(invoiceId);
        }

        public Invoice CreateInvoice(InvoiceDto InvoiceDto)
        {   
            var Invoice = ToInvoice(InvoiceDto);
            _context.Invoices.Add(Invoice);
            this._context.SaveChanges();
            return Invoice;
        }

        private Invoice ToInvoice(InvoiceDto InvoiceDto)
        {
            return new Invoice
            {   

                invoiceId= InvoiceDto.invoiceId,
                cusname= InvoiceDto.cusname,
                products= InvoiceDto.products,
                discount= InvoiceDto.discount,
                comission = InvoiceDto.comission,
                total = InvoiceDto.total,
            };
        }

        public InvoiceDto ToInvoiceDto(Invoice Invoice)
        {
            return new InvoiceDto
            {
                id= Invoice.id,
                invoiceId= Invoice.invoiceId,
                cusname= Invoice.cusname,
                products= Invoice.products,
                discount= Invoice.discount,
                comission = Invoice.comission,
                total = Invoice.total,

            };
        }
        
          public Invoice GetInvoice(int invoiceId)
        {
            return _context.Invoices.Find(invoiceId);
        }
         public List<Invoice> GetALL()
        {
            return _context.Invoices.ToList();
        }
    }
}