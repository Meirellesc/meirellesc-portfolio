using Microsoft.AspNetCore.Components;

namespace MeirellescPortfolio
{
    public partial class App : ComponentBase
    {
        [Inject] NavigationManager? Navigation { get; set; }

        protected override void OnInitialized()
        {
            var uri = new Uri(Navigation.Uri);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var redirect = query["redirect"];

            if (!string.IsNullOrEmpty(redirect))
            {
                Navigation.NavigateTo(redirect, true);
            }
        }
    }
}
