using System.Text.RegularExpressions;
using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MeirellescPortfolio.Pages
{
    public partial class Contact: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }

        bool success;

        //TODO travar para adicionar apenas numero 
    }
}
