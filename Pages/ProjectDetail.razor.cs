using MeirellescPortfolio.Models;
using MeirellescPortfolio.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    partial  class ProjectDetail: ComponentBase
    {
        [Inject] IProjectService? ProjectService { get; set; }

        [Parameter] public string? ProjectTitle { get; set; }

        private ProjectModel? _projectModel;


        protected override Task OnParametersSetAsync()
        {
            ProjectTitle = ProjectTitle ?? "null";

            _projectModel = ProjectService!.GetProjectbyTitle(ProjectTitle).Result;

            return base.OnParametersSetAsync();
        }
    }
}
