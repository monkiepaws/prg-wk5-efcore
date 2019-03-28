using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApi.Models;
using LoanApi.ViewModels;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanDbContext _context;

        public LoansController(LoanDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanVm>>> GetLoan()
        {
            return await _context.Loan
                .Include(l => l.Student)
                .Include(l => l.IsbnNavigation)
                .Select(l => new LoanVm(l))
                .ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{isbn}")]
        public async Task<ActionResult<LoanVm>> GetLoan(string isbn)
        {
            var loan = await _context.Loan
                .Where(l => l.Isbn == isbn)
                .Include(l => l.Student)
                .Include(l => l.IsbnNavigation)
                .Select(l => new LoanVm(l))
                .FirstOrDefaultAsync();

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        // PUT: api/Loans/5
        //[HttpPut("{isbn}")]
        //public async Task<IActionResult> PutLoan(string isbn, Loan loan)
        //{
        //    if (isbn != loan.Isbn)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(loan).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoanExists(isbn))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Loans
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
            _context.Loan.Add(loan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoanExists(loan.Isbn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoan", new { id = loan.Isbn }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{isbn}")]
        public async Task<ActionResult<Loan>> DeleteLoan(string isbn)
        {
            var loan = await _context.Loan.FindAsync(isbn);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        private bool LoanExists(string id)
        {
            return _context.Loan.Any(e => e.Isbn == id);
        }
    }
}
