using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    partial  class ProjectDetail: ComponentBase
    {
        [Parameter] public string? ProjectPath { get; set; }

        protected override void OnParametersSet()
        {
            ProjectPath = ProjectPath ?? "null";
        }

    }
}
