using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Tables;

namespace vMake.Components.Pages.Create;

public partial class CreateItem
{
    [SupplyParameterFromForm]
    public int Entry { get; set; }

    [SupplyParameterFromForm]
    public int Patch { get; set; }

    protected string? Error { get; private set; }

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;

    [Inject]
    protected ILogger<CreateItem> Logger { get; set; } = default!;

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    private async Task OnPostAsync()
    {
        Error = "";

        try
        {
            var template = await DbContext.ItemTemplate.FirstOrDefaultAsync(i => i.Entry == Entry && i.Patch == Patch);
            if (template is not null)
            {
                Error = "An item with that entry id and patch already exists.";
                return;
            }

            var newItem = new MangosItemTemplate()
            {
                Entry = Entry,
                Patch = Patch,
                Name = "New Item",
                Description = "This is your new item!"
            };

            var item = await DbContext.ItemTemplate.AddAsync(newItem);

            var rows = await DbContext.SaveChangesAsync();
            if (rows < 1)
            {
                Error = "An unknown error occured while trying to create the item.";
                return;
            }
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"{ex.Message}: {ex.StackTrace}");
            Error = $"An internal error occured while trying to create the item: {ex.Message}";

            return;
        }

        Navigation.NavigateTo("/edit/item");
    }
}
