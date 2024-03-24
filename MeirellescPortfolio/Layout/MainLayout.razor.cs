using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MeirellescPortfolio.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }

        private bool _isHomePage;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _isHomePage = NavigationManager!.Uri.EndsWith('/');
        }

        protected override bool ShouldRender()
        {
            _isHomePage = NavigationManager!.Uri.EndsWith('/');
            return base.ShouldRender();
        }

        MudTheme DarkTheme = new MudTheme()
        {
            Palette = new PaletteDark()
            {
                
            },
            

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            },

            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = new[] { "Titillium Web", "MuseoModerno", "sans-serif" }
                }
            }
        };
    }
}
