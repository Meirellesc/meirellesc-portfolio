using MeirellescPortfolio.Localization;
using MeirellescPortfolio.Models;
using MeirellescPortfolio.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    public partial class Projects : ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }
        [Inject] IProjectService? ProjectService { get; set; }

        private List<ProjectModel>? _projects { get; set; } = new List<ProjectModel>();


        protected override async Task OnInitializedAsync()
        {
            _projects = await ProjectService!.GetProjects();
        }

        void OnCardClick(string path)
        {
            NavigationManager!.NavigateTo(path);
        }
    }

    
}
