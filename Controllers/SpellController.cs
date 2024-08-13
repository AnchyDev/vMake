using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vMake.Controllers.Models;
using vMake.Controllers.Models.Response;
using vMake.Database;
using vMake.Database.Mangos;

namespace vMake.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpellController : Controller
{
    private readonly MangosDbContext dbContext;

    public SpellController(MangosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("{entry}")]
    public async Task<IActionResult> GetSpellAsync(int? entry)
    {
        if (entry is null)
        {
            return BadRequest(new BasicApiResponse(false, "Missing spell entry in request."));
        }

        var template = await dbContext.SpellTemplate.FirstOrDefaultAsync(s => s.Entry == entry);
        if(template is null)
        {
            return BadRequest(new BasicApiResponse(false, "No spell found with that entry."));
        }

        var spell = new SpellDto()
        {
            Entry = template.Entry,
            Name = template.Name,
            Description = template.Description
        };

        return Ok(new SpellResponse(true, "Found spell.", spell));
    }
}
