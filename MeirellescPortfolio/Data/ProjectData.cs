using MeirellescPortfolio.Localization;
using MeirellescPortfolio.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Data
{
    public class ProjectData
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }

        public List<ProjectModel>? ProjectsData { get; private set; } = new List<ProjectModel>();

        public void OnInitializeProjectsData()
        {
            for (int i = 1; i <= 5; i++)
            {
                ProjectsData!.Add(
                    new ProjectModel()
                    {
                        Id = i,
                        GameTitle = StringLocalizer![$"Project{i}_Title"],
                        GameSubtitle = StringLocalizer![$"Project{i}_Subtitle"],
                        AddressPath = StringLocalizer![$"Project{i}_AddressPath"],
                        ImagePath = StringLocalizer![$"Project{i}_ImagePath"]
                    });
            }
        }

        public ProjectModel? GetProjectbyId(int id) => ProjectsData!.Find(x => x.Id == id);
    }
}
