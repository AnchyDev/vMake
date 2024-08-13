using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Mangos;

namespace vMake.Pages.Edit.Item;

public class IndexModel : PageModel
{
    public int Entry { get; set; }
    public int Patch { get; set; }

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

    public async Task<IActionResult> OnGetAsync(int? entry, int? patch)
    {
        try
        {
            if (entry is null || patch is null)
            {
                return Page();
            }

            Entry = entry.Value;
            Patch = patch.Value; 

            var itemTemplates = await dbContext.ItemTemplate.Where(i => i.Entry == entry).ToListAsync();
            if(itemTemplates.Count < 1)
            {
                Error = "An item with that entry id does not exist.";
                return Page();
            }

            var itemTemplate = itemTemplates.FirstOrDefault(i => i.Patch == patch);
            if(itemTemplate is null)
            {
                var patches = string.Join(", ", itemTemplates.Select(i => i.Patch.ToString()));
                Error = $"No entry was found with that patch. Available patch versions: {patches}";
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

    public async Task<IActionResult> OnPostAsync()
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
        catch (Exception ex)
        {
            logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to update the item: {ex.Message}";
            return Page();
        }
    }
}
