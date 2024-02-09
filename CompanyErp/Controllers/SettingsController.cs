using DataAccessLayer.Data;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SettingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SettingsController(AppDbContext context)
    {
        _context = context;
    }
    #region Unit
    // GET: api/Settings/GetAllUnits
    [HttpGet("GetAllUnits")]
    public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnits()
    {
        return await _context.Units.ToListAsync();
    }

    // GET: api/Settings/GetUnitById/5
    [HttpGet("GetUnitById/{id}")]
    public async Task<ActionResult<Unit>> GetUnitById(int id)
    {
        var unit = await _context.Units.FindAsync(id);

        if (unit == null)
        {
            return NotFound();
        }

        return unit;
    }

    // POST: api/Settings/CreateUnit
    [HttpPost("CreateUnit")]
    public async Task<ActionResult<Unit>> CreateUnit(Unit unit)
    {
        _context.Units.Add(unit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUnitById", new { id = unit.Id }, unit);
    }

    // PUT: api/Settings/UpdateUnit/5
    [HttpPut("UpdateUnit/{id}")]
    public async Task<IActionResult> UpdateUnit(int id, Unit unit)
    {
        if (id != unit.Id)
        {
            return BadRequest();
        }

        _context.Entry(unit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UnitExists(id))
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

    // DELETE: api/Settings/DeleteUnit/5
    [HttpDelete("DeleteUnit/{id}")]
    public async Task<IActionResult> DeleteUnit(int id)
    {
        var unit = await _context.Units.FindAsync(id);
        if (unit == null)
        {
            return NotFound();
        }

        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UnitExists(int id)
    {
        return _context.Units.Any(e => e.Id == id);
    }
    #endregion

    #region Income
    // GET: api/Settings/GetAllIncomeHeads
    [HttpGet("GetAllIncomeHeads")]
    public async Task<ActionResult<IEnumerable<IncomeHead>>> GetAllIncomeHeads()
    {
        return await _context.IncomeHeads.ToListAsync();
    }

    // GET: api/Settings/GetIncomeHeadById/5
    [HttpGet("GetIncomeHeadById/{id}")]
    public async Task<ActionResult<IncomeHead>> GetIncomeHeadById(int id)
    {
        var incomeHead = await _context.IncomeHeads.FindAsync(id);

        if (incomeHead == null)
        {
            return NotFound();
        }

        return incomeHead;
    }

    // POST: api/Settings/CreateIncomeHead
    [HttpPost("CreateIncomeHead")]
    public async Task<ActionResult<IncomeHead>> CreateIncomeHead(IncomeHead incomeHead)
    {
        _context.IncomeHeads.Add(incomeHead);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIncomeHeadById", new { id = incomeHead.Id }, incomeHead);
    }

    // PUT: api/Settings/UpdateIncomeHead/5
    [HttpPut("UpdateIncomeHead/{id}")]
    public async Task<IActionResult> UpdateIncomeHead(int id, IncomeHead incomeHead)
    {
        if (id != incomeHead.Id)
        {
            return BadRequest();
        }

        _context.Entry(incomeHead).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IncomeHeadExists(id))
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

    // DELETE: api/Settings/DeleteIncomeHead/5
    [HttpDelete("DeleteIncomeHead/{id}")]
    public async Task<IActionResult> DeleteIncomeHead(int id)
    {
        var incomeHead = await _context.IncomeHeads.FindAsync(id);
        if (incomeHead == null)
        {
            return NotFound();
        }

        _context.IncomeHeads.Remove(incomeHead);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IncomeHeadExists(int id)
    {
        return _context.IncomeHeads.Any(e => e.Id == id);
    }
    #endregion


    #region ExpenseHead
    // GET: api/Settings/GetAllExpenseHeads
    [HttpGet("GetAllExpenseHeads")]
    public async Task<ActionResult<IEnumerable<ExpenseHead>>> GetAllExpenseHeads()
    {
        return await _context.ExpenseHeads.ToListAsync();
    }

    // GET: api/Settings/GetExpenseHeadById/5
    [HttpGet("GetExpenseHeadById/{id}")]
    public async Task<ActionResult<ExpenseHead>> GetExpenseHeadById(int id)
    {
        var expenseHead = await _context.ExpenseHeads.FindAsync(id);

        if (expenseHead == null)
        {
            return NotFound();
        }

        return expenseHead;
    }

    // POST: api/Settings/CreateExpenseHead
    [HttpPost("CreateExpenseHead")]
    public async Task<ActionResult<ExpenseHead>> CreateExpenseHead(ExpenseHead expenseHead)
    {
        _context.ExpenseHeads.Add(expenseHead);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetExpenseHeadById", new { id = expenseHead.Id }, expenseHead);
    }

    // PUT: api/Settings/UpdateExpenseHead/5
    [HttpPut("UpdateExpenseHead/{id}")]
    public async Task<IActionResult> UpdateExpenseHead(int id, ExpenseHead expenseHead)
    {
        if (id != expenseHead.Id)
        {
            return BadRequest();
        }

        _context.Entry(expenseHead).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExpenseHeadExists(id))
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

    // DELETE: api/Settings/DeleteExpenseHead/5
    [HttpDelete("DeleteExpenseHead/{id}")]
    public async Task<IActionResult> DeleteExpenseHead(int id)
    {
        var expenseHead = await _context.ExpenseHeads.FindAsync(id);
        if (expenseHead == null)
        {
            return NotFound();
        }

        _context.ExpenseHeads.Remove(expenseHead);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExpenseHeadExists(int id)
    {
        return _context.ExpenseHeads.Any(e => e.Id == id);
    }
    #endregion


    #region AddWork
    // GET: api/Settings/GetAllAddWorks
    [HttpGet("GetAllAddWorks")]
    public async Task<ActionResult<IEnumerable<AddWork>>> GetAllAddWorks()
    {
        return await _context.AddWorks.ToListAsync();
    }

    // GET: api/Settings/GetAddWorkById/5
    [HttpGet("GetAddWorkById/{id}")]
    public async Task<ActionResult<AddWork>> GetAddWorkById(int id)
    {
        var addWork = await _context.AddWorks.FindAsync(id);

        if (addWork == null)
        {
            return NotFound();
        }

        return addWork;
    }

    // POST: api/Settings/CreateAddWork
    [HttpPost("CreateAddWork")]
    public async Task<ActionResult<AddWork>> CreateAddWork(AddWork addWork)
    {
        _context.AddWorks.Add(addWork);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAddWorkById", new { id = addWork.Id }, addWork);
    }

    // PUT: api/Settings/UpdateAddWork/5
    [HttpPut("UpdateAddWork/{id}")]
    public async Task<IActionResult> UpdateAddWork(int id, AddWork addWork)
    {
        if (id != addWork.Id)
        {
            return BadRequest();
        }

        _context.Entry(addWork).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddWorkExists(id))
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

    // DELETE: api/Settings/DeleteAddWork/5
    [HttpDelete("DeleteAddWork/{id}")]
    public async Task<IActionResult> DeleteAddWork(int id)
    {
        var addWork = await _context.AddWorks.FindAsync(id);
        if (addWork == null)
        {
            return NotFound();
        }

        _context.AddWorks.Remove(addWork);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AddWorkExists(int id)
    {
        return _context.AddWorks.Any(e => e.Id == id);
    }
    #endregion

    #region PaymentMethod
    // GET: api/Settings/GetAllPaymentMethods
    [HttpGet("GetAllPaymentMethods")]
    public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetAllPaymentMethods()
    {
        return await _context.PaymentMethods.ToListAsync();
    }

    // GET: api/Settings/GetPaymentMethodById/5
    [HttpGet("GetPaymentMethodById/{id}")]
    public async Task<ActionResult<PaymentMethod>> GetPaymentMethodById(int id)
    {
        var paymentMethod = await _context.PaymentMethods.FindAsync(id);

        if (paymentMethod == null)
        {
            return NotFound();
        }

        return paymentMethod;
    }

    // POST: api/Settings/CreatePaymentMethod
    [HttpPost("CreatePaymentMethod")]
    public async Task<ActionResult<PaymentMethod>> CreatePaymentMethod(PaymentMethod paymentMethod)
    {
        _context.PaymentMethods.Add(paymentMethod);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaymentMethodById", new { id = paymentMethod.Id }, paymentMethod);
    }

    // PUT: api/Settings/UpdatePaymentMethod/5
    [HttpPut("UpdatePaymentMethod/{id}")]
    public async Task<IActionResult> UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
    {
        if (id != paymentMethod.Id)
        {
            return BadRequest();
        }

        _context.Entry(paymentMethod).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentMethodExists(id))
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

    // DELETE: api/Settings/DeletePaymentMethod/5
    [HttpDelete("DeletePaymentMethod/{id}")]
    public async Task<IActionResult> DeletePaymentMethod(int id)
    {
        var paymentMethod = await _context.PaymentMethods.FindAsync(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        _context.PaymentMethods.Remove(paymentMethod);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentMethodExists(int id)
    {
        return _context.PaymentMethods.Any(e => e.Id == id);
    }
    #endregion


    #region AddWorkProcess
    // GET: api/Settings/GetAllAddWorkProcesses
    [HttpGet("GetAllAddWorkProcesses")]
    public async Task<ActionResult<IEnumerable<AddWorkProcess>>> GetAllAddWorkProcesses()
    {
        return await _context.AddWorkProcesses.ToListAsync();
    }

    // GET: api/Settings/GetAddWorkProcessById/5
    [HttpGet("GetAddWorkProcessById/{id}")]
    public async Task<ActionResult<AddWorkProcess>> GetAddWorkProcessById(int id)
    {
        var addWorkProcess = await _context.AddWorkProcesses.FindAsync(id);

        if (addWorkProcess == null)
        {
            return NotFound();
        }

        return addWorkProcess;
    }

    // POST: api/Settings/CreateAddWorkProcess
    [HttpPost("CreateAddWorkProcess")]
    public async Task<ActionResult<AddWorkProcess>> CreateAddWorkProcess(AddWorkProcess addWorkProcess)
    {
        _context.AddWorkProcesses.Add(addWorkProcess);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAddWorkProcessById", new { id = addWorkProcess.Id }, addWorkProcess);
    }

    // PUT: api/Settings/UpdateAddWorkProcess/5
    [HttpPut("UpdateAddWorkProcess/{id}")]
    public async Task<IActionResult> UpdateAddWorkProcess(int id, AddWorkProcess addWorkProcess)
    {
        if (id != addWorkProcess.Id)
        {
            return BadRequest();
        }

        _context.Entry(addWorkProcess).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddWorkProcessExists(id))
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

    // DELETE: api/Settings/DeleteAddWorkProcess/5
    [HttpDelete("DeleteAddWorkProcess/{id}")]
    public async Task<IActionResult> DeleteAddWorkProcess(int id)
    {
        var addWorkProcess = await _context.AddWorkProcesses.FindAsync(id);
        if (addWorkProcess == null)
        {
            return NotFound();
        }

        _context.AddWorkProcesses.Remove(addWorkProcess);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AddWorkProcessExists(int id)
    {
        return _context.AddWorkProcesses.Any(e => e.Id == id);
    }
    #endregion 
}
