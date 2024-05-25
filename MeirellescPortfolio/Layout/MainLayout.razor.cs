using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Utilities;

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

        MudTheme CustomTheme = new MudTheme()
        {
            Palette = new PaletteDark()
            {
                BackgroundGrey = new MudColor("#000000"),
                Background = new MudColor("#000000"),
                AppbarBackground = new MudColor("#000000"),

                Info = new MudColor("#4D6C73"),
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
