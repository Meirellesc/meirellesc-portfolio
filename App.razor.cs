using System.IO;
using Microsoft.AspNetCore.Components;

namespace MeirellescPortfolio
{
    public partial class App : ComponentBase
    {
        [Inject] NavigationManager? Navigation { get; set; }

        private static bool _hasRedirected = false;

        protected override void OnInitialized()
        {
            if (_hasRedirected || Navigation == null) return;

            Uri? uri = new Uri(Navigation.Uri);

            string? path = uri.AbsolutePath.ToLowerInvariant();

            System.Collections.Specialized.NameValueCollection? query = System.Web.HttpUtility.ParseQueryString(uri.Query);

            string? redirect = query["redirect"];

            // Redireciona apenas se estiver em /index.html com redirect
            if (!string.IsNullOrEmpty(redirect) && 
                Navigation.Uri.Contains("redirect=") && 
                !path.Equals(redirect, StringComparison.OrdinalIgnoreCase))
            {
                _hasRedirected = true;
                Navigation.NavigateTo(redirect, true); // Ensure redirect is not null or empty
            }
        }
    }
}
