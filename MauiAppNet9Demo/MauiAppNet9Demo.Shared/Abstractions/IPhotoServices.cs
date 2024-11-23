using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNet9Demo.Shared.Abstractions
{
    public interface IPhotoServices: INotifyPropertyChanged
    {
        Task SetSourceImage(Stream photoStream);
        Task PickPhoto();
        Task TakePhoto();
        public string SourceImage { get ; set; }
       
        //Task SetPhoto(FileResult photo)
    }
}
