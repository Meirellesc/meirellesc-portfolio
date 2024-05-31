using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MeirellescPortfolio.Components
{
    public partial class MenuDialogCmpnt: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        void Cancel() => MudDialog.Cancel();
    }
}
