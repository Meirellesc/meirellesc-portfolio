using MeirellescPortfolio.Components;
using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;
using MudBlazor.Utilities;

namespace MeirellescPortfolio.Layout
{
    public partial class MainLayout : LayoutComponentBase, IBrowserViewportObserver, IAsyncDisposable
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }
        [Inject] NavigationManager? NavigationManager { get; set; }
        [Inject] IDialogService? DialogService { get; set; }
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

        public void OpenMenu()
        {
            DialogService!.Show<MenuDialogCmpnt>();
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
                BackgroundGrey = new MudColor("#0D0D0D"),
                Background = new MudColor("#0D0D0D"),

                AppbarBackground = new MudColor("#0D0D0D"),
                AppbarText = new MudColor("#B6F2D6"),
                

                Primary = new MudColor("#F2F2F0"),
                Secondary = new MudColor("#D9CBA0"),
                Info = new MudColor("#8484FF"),
                Tertiary = new MudColor("#B6F2D6"),
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
