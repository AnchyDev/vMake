using Microsoft.AspNetCore.Components;

using System.Text;
using System.Text.Json;

using vMake.Database.Tables;
using vMake.Models;

namespace vMake.Components.Pages.Edit;

public partial class EditItem
{
    [Parameter]
    public int? Entry { get; set; } = 0;

    [Parameter]
    public int? Patch { get; set; } = 0;

    [Parameter]
    public string? Import { get; set; }

    [Inject]
    protected NavigationManager Navigation { get; set; } = default!;

    protected string? Error { get; set; }

    private void HandleBase64()
    {
        if(string.IsNullOrWhiteSpace(Import))
        {
            Error = "You must enter a base64 string exported from an item.";
            return;
        }

        try
        {
            var data = Convert.FromBase64String(Import);
            var json = Encoding.UTF8.GetString(data);

            _ = JsonSerializer.Deserialize<MakeItemTemplate>(json);
        }
        catch(Exception)
        {
            Error = "Invalid import string.";
            return;
        }

        Navigation.NavigateTo($"/edit/item/{Import}");
    }

    private void HandleEntryPatch()
    {
        if (Entry is null && Patch is null)
        {
            Error = "You must enter an entry and patch.";
            return;
        }

        Navigation.NavigateTo($"/edit/item/{Entry}/{Patch}");
    }
}
