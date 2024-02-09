using DataAccessLayer.Data.Models;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FrontOfficeController : ControllerBase
{
    private readonly AppDbContext _context;

    public FrontOfficeController(AppDbContext context)
    {
        _context = context;
    }

    #region Visitor

    // GET: api/Visitors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visitor>>> GetVisitors()
    {
        return await _context.Visitors.ToListAsync();
    }

    // GET: api/Visitors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Visitor>> GetVisitor(int id)
    {
        var visitor = await _context.Visitors.FindAsync(id);

        if (visitor == null)
        {
            return NotFound();
        }

        return visitor;
    }

    // POST: api/Visitors
    [HttpPost]
    public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
    {
        _context.Visitors.Add(visitor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVisitor", new { id = visitor.Id }, visitor);
    }

    // PUT: api/Visitors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
    {
        if (id != visitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(visitor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitorExists(id))
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

    // DELETE: api/Visitors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisitor(int id)
    {
        var visitor = await _context.Visitors.FindAsync(id);
        if (visitor == null)
        {
            return NotFound();
        }

        _context.Visitors.Remove(visitor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VisitorExists(int id)
    {
        return _context.Visitors.Any(e => e.Id == id);
    }
    #endregion


    #region Phone Call Log
    // GET: api/Complains
    [HttpGet("complains")]
    public async Task<ActionResult<IEnumerable<Complain>>> GetComplains()
    {
        return await _context.Complains.ToListAsync();
    }

    // GET: api/Complains/5
    [HttpGet("complains/{id}")]
    public async Task<ActionResult<Complain>> GetComplain(int id)
    {
        var complain = await _context.Complains.FindAsync(id);

        if (complain == null)
        {
            return NotFound();
        }

        return complain;
    }

    // POST: api/Complains
    [HttpPost("complains")]
    public async Task<ActionResult<Complain>> PostComplain(Complain complain)
    {
        _context.Complains.Add(complain);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetComplain", new { id = complain.Id }, complain);
    }

    // PUT: api/Complains/5
    [HttpPut("complains/{id}")]
    public async Task<IActionResult> PutComplain(int id, Complain complain)
    {
        if (id != complain.Id)
        {
            return BadRequest();
        }

        _context.Entry(complain).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ComplainExists(id))
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

    // DELETE: api/Complains/5
    [HttpDelete("complains/{id}")]
    public async Task<IActionResult> DeleteComplain(int id)
    {
        var complain = await _context.Complains.FindAsync(id);
        if (complain == null)
        {
            return NotFound();
        }

        _context.Complains.Remove(complain);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ComplainExists(int id)
    {
        return _context.Complains.Any(e => e.Id == id);
    }

    #endregion

    #region PostalReceive
    // GET: api/PostalReceives
    [HttpGet("postalReceives")]
    public async Task<ActionResult<IEnumerable<PostalReceive>>> GetPostalReceives()
    {
        return await _context.PostalReceives.ToListAsync();
    }

    // GET: api/PostalReceives/5
    [HttpGet("postalReceives/{id}")]
    public async Task<ActionResult<PostalReceive>> GetPostalReceive(int id)
    {
        var postalReceive = await _context.PostalReceives.FindAsync(id);

        if (postalReceive == null)
        {
            return NotFound();
        }

        return postalReceive;
    }

    // POST: api/PostalReceives
    [HttpPost("postalReceives")]
    public async Task<ActionResult<PostalReceive>> PostPostalReceive(PostalReceive postalReceive)
    {
        _context.PostalReceives.Add(postalReceive);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPostalReceive", new { id = postalReceive.Id }, postalReceive);
    }

    // PUT: api/PostalReceives/5
    [HttpPut("postalReceives/{id}")]
    public async Task<IActionResult> PutPostalReceive(int id, PostalReceive postalReceive)
    {
        if (id != postalReceive.Id)
        {
            return BadRequest();
        }

        _context.Entry(postalReceive).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostalReceiveExists(id))
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

    // DELETE: api/PostalReceives/5
    [HttpDelete("postalReceives/{id}")]
    public async Task<IActionResult> DeletePostalReceive(int id)
    {
        var postalReceive = await _context.PostalReceives.FindAsync(id);
        if (postalReceive == null)
        {
            return NotFound();
        }

        _context.PostalReceives.Remove(postalReceive);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PostalReceiveExists(int id)
    {
        return _context.PostalReceives.Any(e => e.Id == id);
    }

    #endregion


    #region PostalDispatch
    // GET: api/PostalDispatches
    [HttpGet("postalDispatches")]
    public async Task<ActionResult<IEnumerable<PostalDispatch>>> GetPostalDispatches()
    {
        return await _context.PostalDispatches.ToListAsync();
    }

    // GET: api/PostalDispatches/5
    [HttpGet("postalDispatches/{id}")]
    public async Task<ActionResult<PostalDispatch>> GetPostalDispatch(int id)
    {
        var postalDispatch = await _context.PostalDispatches.FindAsync(id);

        if (postalDispatch == null)
        {
            return NotFound();
        }

        return postalDispatch;
    }

    // POST: api/PostalDispatches
    [HttpPost("postalDispatches")]
    public async Task<ActionResult<PostalDispatch>> PostPostalDispatch(PostalDispatch postalDispatch)
    {
        _context.PostalDispatches.Add(postalDispatch);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPostalDispatch", new { id = postalDispatch.Id }, postalDispatch);
    }

    // PUT: api/PostalDispatches/5
    [HttpPut("postalDispatches/{id}")]
    public async Task<IActionResult> PutPostalDispatch(int id, PostalDispatch postalDispatch)
    {
        if (id != postalDispatch.Id)
        {
            return BadRequest();
        }

        _context.Entry(postalDispatch).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostalDispatchExists(id))
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

    // DELETE: api/PostalDispatches/5
    [HttpDelete("postalDispatches/{id}")]
    public async Task<IActionResult> DeletePostalDispatch(int id)
    {
        var postalDispatch = await _context.PostalDispatches.FindAsync(id);
        if (postalDispatch == null)
        {
            return NotFound();
        }

        _context.PostalDispatches.Remove(postalDispatch);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PostalDispatchExists(int id)
    {
        return _context.PostalDispatches.Any(e => e.Id == id);
    }

    #endregion


    #region PhoneCallLog
    // GET: api/PhoneCallLogs
    [HttpGet("phoneCallLogs")]
    public async Task<ActionResult<IEnumerable<PhoneCallLog>>> GetPhoneCallLogs()
    {
        return await _context.PhoneCallLogs.ToListAsync();
    }

    // GET: api/PhoneCallLogs/5
    [HttpGet("phoneCallLogs/{id}")]
    public async Task<ActionResult<PhoneCallLog>> GetPhoneCallLog(int id)
    {
        var phoneCallLog = await _context.PhoneCallLogs.FindAsync(id);

        if (phoneCallLog == null)
        {
            return NotFound();
        }

        return phoneCallLog;
    }

    // POST: api/PhoneCallLogs
    [HttpPost("phoneCallLogs")]
    public async Task<ActionResult<PhoneCallLog>> PostPhoneCallLog(PhoneCallLog phoneCallLog)
    {
        _context.PhoneCallLogs.Add(phoneCallLog);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPhoneCallLog", new { id = phoneCallLog.Id }, phoneCallLog);
    }

    // PUT: api/PhoneCallLogs/5
    [HttpPut("phoneCallLogs/{id}")]
    public async Task<IActionResult> PutPhoneCallLog(int id, PhoneCallLog phoneCallLog)
    {
        if (id != phoneCallLog.Id)
        {
            return BadRequest();
        }

        _context.Entry(phoneCallLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PhoneCallLogExists(id))
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

    // DELETE: api/PhoneCallLogs/5
    [HttpDelete("phoneCallLogs/{id}")]
    public async Task<IActionResult> DeletePhoneCallLog(int id)
    {
        var phoneCallLog = await _context.PhoneCallLogs.FindAsync(id);
        if (phoneCallLog == null)
        {
            return NotFound();
        }

        _context.PhoneCallLogs.Remove(phoneCallLog);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PhoneCallLogExists(int id)
    {
        return _context.PhoneCallLogs.Any(e => e.Id == id);
    }

    #endregion

}
