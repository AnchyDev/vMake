using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Mangos;

namespace vMake.Pages.Edit.Item;

public class IndexModel : PageModel
{
    public string? Error { get; set; }

    [BindProperty]
    public MangosItemTemplate? ItemTemplate { get; set; }

    private readonly MangosDbContext dbContext;
    private readonly ILogger<IndexModel> logger;

    public IndexModel(MangosDbContext dbContext, ILogger<IndexModel> logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(int? entry)
    {
        try
        {
            if (entry is null)
            {
                return Page();
            }

            var itemTemplate = await dbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == entry);
            if (itemTemplate is null)
            {
                Error = "An item with that entry id does not exist.";
                return Page();
            }

            ItemTemplate = itemTemplate;

            return Page();
        }
        catch(Exception ex)
        {
            logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to get the item: {ex.Message}";
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync(string? type, int? entry)
    {
        if(type is null)
        {
            return Page();
        }

        switch(type.ToLower())
        {
            case "edit":
                return RedirectToPage("/Edit/Item/Index", new { entry = entry });

            case "update":
                return await UpdateEntryAsync();

            default:
                return Page();
        }
    }

    private async Task<IActionResult> UpdateEntryAsync()
    {
        try
        {
            if (ItemTemplate is null)
            {
                return Page();
            }

            dbContext.ItemTemplate.Update(ItemTemplate);

            var rows = await dbContext.SaveChangesAsync();
            if (rows < 1)
            {
                Error = "An unknown error occured while trying to update the item.";
                return Page();
            }

            return RedirectToPage("/Edit/Item/Index", new { entry = ItemTemplate.Entry });
        }
        catch(Exception ex)
        {
            logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to update the item: {ex.Message}";
            return Page();
        }
    }
}
