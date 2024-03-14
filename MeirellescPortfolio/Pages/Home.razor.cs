using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MeirellescPortfolio.Components;

namespace MeirellescPortfolio.Pages
{
    public partial class Home: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
    }
}
