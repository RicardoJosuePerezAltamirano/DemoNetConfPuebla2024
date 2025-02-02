//------------------------------------------------------------------------------
// <auto-generated>
//     Este c�digo fue generado por una herramienta.
//     Versi�n de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podr�an causar un comportamiento incorrecto y se perder�n si
//     se vuelve a generar el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

using MauiAppNet9Demo.Shared.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MauiAppNet9Demo.Shared.Pages
{
    public partial class FotosWebComponent:ComponentBase
    {
        private string PhotoBase64 { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await StartCamera();
                await StartCamera();
            }
        }

        private async Task StartCamera()
        {
            // Llama a la funci�n JavaScript para iniciar la c�mara
            await JSRuntime.InvokeVoidAsync("startCamera", "videoElement");
        }

        private async Task CapturePhoto()
        {
            // Llama a la funci�n JavaScript para capturar la foto y obtener la imagen en Base64
            PhotoBase64 = await JSRuntime.InvokeAsync<string>("capturePhoto", "videoElement", "canvasElement");
            StateHasChanged();
        }
    }
}