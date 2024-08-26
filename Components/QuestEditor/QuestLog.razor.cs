using Microsoft.AspNetCore.Components;
using vMake.Models;

namespace vMake.Components.QuestEditor;

public partial class QuestLog
{
    [Parameter]
    public MakeQuestTemplate Template { get; set; } = default!;
}
