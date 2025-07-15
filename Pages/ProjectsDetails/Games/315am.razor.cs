using BlazorVideoPlayer;
using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages.ProjectsDetails.Games
{
    public partial class _315am: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }

        private List<Source> _sources = new()
        {
            new()
            {
                Src = "/assets/projects/315am/315am-GameJam+.mp4",
                Type = "video/mp4"
            }
        };
    }
}
