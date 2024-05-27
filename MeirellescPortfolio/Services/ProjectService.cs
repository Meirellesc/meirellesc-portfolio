using MeirellescPortfolio.Localization;
using MeirellescPortfolio.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Services
{
    public class ProjectService : IProjectService
    {
        private readonly List<ProjectModel> _projects = new List<ProjectModel>();

        public Task LoadSetupData(IStringLocalizer<Resource> StringLocalizer)
        {
            for (int i = 1; i <= 3; i++)
            {
                string stringtitle = $"Project{i}_Title";
                string title = StringLocalizer[stringtitle];

                string pDeviceText = StringLocalizer[$"Project{i}_ProjectDevice"];
                ProjectDevice pDevice = ProjectDevice.None;

                if(pDeviceText == ProjectDevice.Mobile.ToString())
                {
                    pDevice = ProjectDevice.Mobile;
                }
                else if (pDeviceText == ProjectDevice.Desktop.ToString())
                {
                    pDevice = ProjectDevice.Desktop;
                }
                else if (pDeviceText == ProjectDevice.Console.ToString())
                {
                    pDevice = ProjectDevice.Console;
                }

                ProjectModel pModel = new ProjectModel()
                {
                    Id = i,
                    GameTitle = title,
                    GameSubtitle = StringLocalizer[$"Project{i}_Subtitle"],
                    AddressPath = StringLocalizer[$"Project{i}_AddressPath"],
                    ImagePath = StringLocalizer[$"Project{i}_ImagePath"],
                    ProjectType = StringLocalizer[$"Project{i}_ProjectType"] == ProjectType.Game.ToString() ? ProjectType.Game : ProjectType.Website,
                    ProjectDevice = pDevice
                };

                AddProject(pModel);
            }

            return Task.CompletedTask;
        }

        public Task AddProject(ProjectModel project)
        {
            _projects.Add(project);
            return Task.CompletedTask;
        }

        public Task<List<ProjectModel>> GetProjects()
        {
            return Task.FromResult(_projects);
        }

        public Task<ProjectModel?> GetProjectbyId(int id)
        {
            return Task.FromResult(_projects.Find(x => x.Id == id));
        }          

        public Task<ProjectModel?> GetProjectbyTitle(string title)
        {
            return Task.FromResult(_projects.Find(x => string.Equals(x.GameTitle,title, StringComparison.OrdinalIgnoreCase)));
        }
    }

    public interface IProjectService
    {
        Task LoadSetupData(IStringLocalizer<Resource> StringLocalizer);
        Task<List<ProjectModel>> GetProjects();
        Task<ProjectModel?> GetProjectbyId(int id);
        Task<ProjectModel?> GetProjectbyTitle(string title);
        Task AddProject(ProjectModel project);
    }
}
