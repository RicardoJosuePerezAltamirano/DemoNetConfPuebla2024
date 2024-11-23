using MauiAppNet9Demo.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppNet9Demo.Shared.Services
{
    public abstract class PhotoServices : IPhotoServices
    {
        private string photoPath;
        private string sourceImage;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public string SourceImage
        {
            get { return sourceImage; }
            set
            {
                if (value != sourceImage)
                {
                    sourceImage = value;
                    OnPropertyChanged("SourceImage");
                }
            }
        }
        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                if (value != photoPath)
                {
                    photoPath = value;
                    OnPropertyChanged("PhotoPath");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract Task PickPhoto();


        public abstract Task SetSourceImage(Stream photoStream);

        public abstract Task TakePhoto();
    }
}
