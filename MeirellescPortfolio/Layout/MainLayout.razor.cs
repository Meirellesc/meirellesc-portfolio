using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MeirellescPortfolio.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }

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
