using Microsoft.AspNetCore.Components;

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

    private void NavigateToProperRoute()
    {
        if(Entry is not null && Patch is not null)
        {
            Navigation.NavigateTo($"/edit/item/{Entry}/{Patch}");
        }
        else if(Import is not null)
        {
            Navigation.NavigateTo($"/edit/item/{Import}");
        }
    }
}
