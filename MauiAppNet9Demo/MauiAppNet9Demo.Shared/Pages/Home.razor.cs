#if ANDROID || WINDOWS
using MauiAppNet9Demo.Services;
#endif
using MauiAppNet9Demo.Shared.Abstractions;
using Microsoft.AspNetCore.Components;
using static System.Net.Mime.MediaTypeNames;

namespace MauiAppNet9Demo.Shared.Pages
{
    public partial class Home
    {
        [Inject]
        public IFormFactor FormFactor { get; set; }
        private string factor => FormFactor.GetFormFactor();
        private string platform => FormFactor.GetPlatform();

        protected override async Task OnInitializedAsync()
        {


        }

#if ANDROID || WINDOWS
      
       
#endif
    }
}