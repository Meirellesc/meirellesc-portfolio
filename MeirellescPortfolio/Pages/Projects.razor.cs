using MeirellescPortfolio.Localization;
using MeirellescPortfolio.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    public partial class Projects: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }

        private List<ProjectModel>? ProjectsModel { get; set; } = new List<ProjectModel>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ProjectsModel.Add(
                new ProjectModel()
                {
                    GameTitle = StringLocalizer![$"Project{1}_Title"],
                    GameSubtitle = StringLocalizer![$"Project{1}_Subtitle"],
                    AddressPath = StringLocalizer![$"Project{1}_AddressPath"],
                    ImagePath = StringLocalizer![$"Project{1}_ImagePath"]
                });
        }

        void OnCardClick(string path)
        {
            NavigationManager!.NavigateTo(path);
        }
    }

    
}
