using Majorsoft.Blazor.Components.Common.JsInterop.Scroll;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MeirellescPortfolio.Components
{
    public partial class HeaderCmpnt: ComponentBase
    {
        [Inject] IScrollHandler? ScrollHandler { get; set; } 

        [CascadingParameter(Name = "HeaderTitle")] private LocalizedString? HeaderTitle { get; set; }

        [CascadingParameter(Name = "HeaderSubtitle")] private LocalizedString? HeaderSubtitle { get; set; }

        private async void OnScrollToElement()
        {
            await ScrollHandler!.ScrollToPageYAsync(400, true);
        }
    }
}
