using Microsoft.AspNetCore.Components;

using vMake.Models;

namespace vMake.Components.QuestEditor;

public partial class QuestLog
{
    [Parameter]
    public MakeQuestTemplate Template { get; set; } = default!;

    private MarkupString ParseTokens(string s)
    {
        return new MarkupString(s.Replace("$B", "<br />"));
    }
}
