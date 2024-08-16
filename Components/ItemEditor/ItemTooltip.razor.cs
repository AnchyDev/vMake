using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using vMake.Database;
using vMake.Database.Tables;
using vMake.Database.Types;
using vMake.Models;

namespace vMake.Components.ItemEditor;

public partial class ItemTooltip
{
    [Parameter]
    public MakeItemTemplate? Template { get; set; }

    [Inject]
    protected MangosDbContext DbContext { get; set; } = default!;
}
