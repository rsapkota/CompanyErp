﻿using DataAccessLayer.Data.Models;
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
}