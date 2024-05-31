using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages.ProjectsDetails.Games
{
    public partial class TheMystery: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
    }
}
