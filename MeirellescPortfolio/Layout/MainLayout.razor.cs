using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.Utilities;
using System.Diagnostics;

namespace MeirellescPortfolio.Layout
{
    public partial class MainLayout : LayoutComponentBase, IBrowserViewportObserver, IAsyncDisposable
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }
        [Inject] IBrowserViewportService? BrowserViewportService { get; set; }

        Guid IBrowserViewportObserver.Id { get; } = Guid.NewGuid();
        private Breakpoint _breakpoint;
        private bool _isHomePage;

        private bool _isOpen = false;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await BrowserViewportService!.SubscribeAsync(this, fireImmediately: true);
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        public async ValueTask DisposeAsync() => await BrowserViewportService!.UnsubscribeAsync(this);

        public void ToggleOpen()
        {
            Debug.Print($"Menu Antes = { _isOpen}");
            _isOpen = !_isOpen;
            Debug.Print($"Menu Depois = {_isOpen}");
        }

        ResizeOptions IBrowserViewportObserver.ResizeOptions { get; } = new()
        {
            ReportRate = 250,
            NotifyOnBreakpointOnly = true
        };


        Task IBrowserViewportObserver.NotifyBrowserViewportChangeAsync(BrowserViewportEventArgs browserViewportEventArgs)
        {
            _breakpoint = browserViewportEventArgs.Breakpoint;
            return InvokeAsync(StateHasChanged);
        }

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
