using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Pages
{
    public partial class Contact: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
    }
}
