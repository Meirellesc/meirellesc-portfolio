using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MeirellescPortfolio.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace MeirellescPortfolio.Pages
{
    public partial class Contact: ComponentBase
    {
        [Inject] IStringLocalizer<Resource>? StringLocalizer { get; set; }

        MudForm form;

        private string Name { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private string Message { get; set; }

        private bool _success { get; set; }

        public string EmailBodyCompose()
        {
            string baseMsg = "mailto:hello@meirellesc.com?subject=Contact%20-%20Website%20Meirellesc&body=Contact%20Information%20%0A%0A";
            baseMsg += !String.IsNullOrEmpty(Name) ? "Name: " + Name + "%0A" : "";
            baseMsg += !String.IsNullOrEmpty(Email) ? "E-mail: " + Email + "%0A" : "";
            baseMsg += !String.IsNullOrEmpty(Phone) ? "Phone: " + Phone + "%0A" : "";
            baseMsg += !String.IsNullOrEmpty(Message) ? "Message: " + Message + "%0A" : "";

            return baseMsg;
        }
    }
}
