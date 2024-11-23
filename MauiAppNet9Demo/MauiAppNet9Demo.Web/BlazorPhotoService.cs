using MauiAppNet9Demo.Shared.Services;

namespace MauiAppNet9Demo.Web
{
    public class BlazorPhotoService : PhotoServices
    {
        public override Task PickPhoto()
        {
            throw new NotImplementedException();
        }

        public override Task SetSourceImage(Stream photoStream)
        {
            throw new NotImplementedException();
        }

        public override Task TakePhoto()
        {
            throw new NotImplementedException();
        }
    }
}
