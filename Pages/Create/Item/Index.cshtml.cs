using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Mangos;

namespace vMake.Pages.Create.Item;

public class IndexModel : PageModel
{
    public string? Error { get; set; }

    private readonly MangosDbContext dbContext;
    private readonly ILogger<IndexModel> logger;

    public IndexModel(MangosDbContext dbContext, ILogger<IndexModel> logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
    }

    public async Task<IActionResult> OnPostAsync([FromForm]int? entry)
    {
        try
        {
            if (entry is null)
            {
                Error = "You must fill in an entry id to create.";
                return Page();
            }

            var template = await dbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == entry);
            if (template is not null)
            {
                Error = "An item with that entry id already exists.";
                return Page();
            }

            var newItem = new MangosItemTemplate()
            {
                Entry = entry.Value,
                Name = "New Item",
                Description = "This is your new item!"
            };

            var item = await dbContext.ItemTemplate.AddAsync(newItem);

            var rows = await dbContext.SaveChangesAsync();
            if (rows < 1)
            {
                Error = "An unknown error occured while trying to create the item.";
                return Page();
            }

            return RedirectToPage("/Edit/Item/Index", new { entry = entry });
        }
        catch(Exception ex)
        {
            logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to create the item: {ex.Message}";
            return Page();
        }
    }
}
