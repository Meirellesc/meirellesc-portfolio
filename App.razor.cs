using System.IO;
using Microsoft.AspNetCore.Components;

namespace MeirellescPortfolio
{
    public partial class App : ComponentBase
    {
        [Inject] NavigationManager? Navigation { get; set; }

        protected override void OnInitialized()
        {
            var uri = new Uri(Navigation.Uri);
            var path = uri.AbsolutePath.ToLowerInvariant();
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var redirect = query["redirect"];

            // Redireciona apenas se estiver em /index.html com redirect
            if (path.EndsWith("/index.html") && !string.IsNullOrEmpty(redirect))
            {
                Navigation.NavigateTo(redirect, true);
            }
        }
    }
}
