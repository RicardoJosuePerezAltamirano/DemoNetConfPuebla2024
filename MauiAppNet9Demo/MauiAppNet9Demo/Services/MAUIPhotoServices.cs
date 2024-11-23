using MauiAppNet9Demo.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNet9Demo.Services
{
    public class MAUIPhotoServices:PhotoServices
    {
     
        public override async Task SetSourceImage(Stream photoStream)
        {
            if (photoStream != null)
            {
                //razor component needs a base64 encoded string so it can display the image in <img /> tag
                byte[] imageBytes = new byte[photoStream.Length];
                photoStream.Read(imageBytes, 0, (int)photoStream.Length);

                var imageSource = Convert.ToBase64String(imageBytes);
                imageSource = string.Format("data:image/jpg;base64,{0}", imageSource);

                SourceImage = imageSource;
            }
        }
        

        public override async Task PickPhoto()
        {
            //MAUI abstracts the device specific code for us
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            await SetPhoto(photo);
        }
        public override async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                try
                {
                    //MAUI abstracts the device specific code for us
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                    //await SetPhoto(photo);
                    using (var stream = await photo.OpenReadAsync())
                    {
                        // Convertir la imagen a Base64
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            byte[] imageBytes = memoryStream.ToArray();
                            string base64Image = Convert.ToBase64String(imageBytes);

                            // Devolver la imagen en formato Base64

                            var imageSource = string.Format("data:image/jpg;base64,{0}", base64Image);

                            SourceImage = imageSource;
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    //Capture is not supported or could not be completed.
                    Debug.WriteLine(ex);
                }
            }
        }
        private async Task SetPhoto(FileResult photo)
        {
            if (photo != null)
            {
                using Stream sourceStream = await photo.OpenReadAsync();
                PhotoPath = photo.FullPath;
                //razor component needs a base64 encoded string so it can display the image in <img /> tag
                await SetSourceImage(sourceStream);
            }
        }

      
    }
}
