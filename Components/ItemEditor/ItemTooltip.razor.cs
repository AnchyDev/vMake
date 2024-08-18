using Microsoft.AspNetCore.Components;

using vMake.Database;
using vMake.Models;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MakeItemTemplate? Template { get; set; }

    [Inject]
    private MangosDbContext DbContext { get; set; } = default!;
}
