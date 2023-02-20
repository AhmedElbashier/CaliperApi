using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;
using CaliperApi.Domain.Repositories;

namespace CaliperApi.Domain.Services
{
    public interface IInvoiceService
    {
        Invoice GetInvoice(int invoiceId);
        List<InvoiceDto> GetALl();
        Invoice CreateInvoice(InvoiceDto InvoiceDto);
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _InvoiceRepository;

        public InvoiceService(IInvoiceRepository InvoiceRepository)
        {
            _InvoiceRepository = InvoiceRepository;    
        }
        
       
        public Invoice GetInvoice(int invoiceId)
        {
            return _InvoiceRepository.GetInvoice(invoiceId);
        }

        public Invoice CreateInvoice(InvoiceDto InvoiceDto)
        {
            return _InvoiceRepository.CreateInvoice(InvoiceDto);
        }
        public List<InvoiceDto> GetALl()
        {
            return _InvoiceRepository.GetAll().Select(_InvoiceRepository.ToInvoiceDto).ToList();
        }
      
        
    }
}