using Microsoft.AspNetCore.Mvc;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Services;
using CaliperApi.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Linq;

namespace CaliperApi.Domain.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInvoiceService _InvoiceService;

        public InvoiceController(AppDbContext context, IInvoiceService InvoiceService)
        {
            _context = context;
            _InvoiceService = InvoiceService;
        }

        [HttpGet]
        public IActionResult GetInvoices()
        {
            var Invoices = _InvoiceService.GetALl();
            return Ok(Invoices);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Invoice> GetInvoice(int id)
        {
            var Invoice = _InvoiceService.GetInvoice(id);

            if (Invoice == null)
            {
                return NotFound();
            }

            return Ok(Invoice);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice Invoice)
        {
            if (id != Invoice.id)
            {
                return BadRequest();
            }

            _context.Entry(Invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public IActionResult CreateInvoice(InvoiceDto InvoiceDto)
        {
            var Invoice = _InvoiceService.CreateInvoice(InvoiceDto);
            return Ok(Invoice);
        }

                private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            var Invoice = await _context.Invoices.FindAsync(id);
            if (Invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(Invoice);
            await _context.SaveChangesAsync();

            return Invoice;
        }

    }
}