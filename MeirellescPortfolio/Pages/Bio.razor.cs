using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    public partial class Bio: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
    }
}
