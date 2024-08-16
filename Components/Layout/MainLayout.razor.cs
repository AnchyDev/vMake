using Microsoft.AspNetCore.Components;

using vMake.Configuration;

namespace vMake.Components.Layout;

public partial class MainLayout
{
    [Inject]
    protected MakeConfig Config { get; set; } = default!; 
}
