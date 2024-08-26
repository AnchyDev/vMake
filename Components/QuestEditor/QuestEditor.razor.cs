using Microsoft.AspNetCore.Components;

using vMake.Models;

namespace vMake.Components.QuestEditor;

public partial class QuestEditor
{
    [Parameter]
    public MakeQuestTemplate Template { get; set; } = default!;
}
