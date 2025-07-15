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
            if (_hasRedirected) return;

            //Exemplo: uri= https://localhost:7200/projects
            Uri? uri = new Uri(Navigation.Uri);

            // Exemplo: projects
            string? path = uri.AbsolutePath.ToLowerInvariant();

            System.Collections.Specialized.NameValueCollection? query = System.Web.HttpUtility.ParseQueryString(uri.Query);

            string? redirect = query["redirect"];

            // Redireciona apenas se estiver em /index.html com redirect
            if (Navigation.Uri.Contains("redirect=") && !path.Equals(redirect, StringComparison.OrdinalIgnoreCase))
            {
                _hasRedirected = true;
                Navigation.NavigateTo(redirect, true);
            }
        }
    }
}
