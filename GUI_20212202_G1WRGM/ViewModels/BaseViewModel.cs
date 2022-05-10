using GUI_20212202_G1WRGM.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public static MediaPlayer mediaPlayer = new MediaPlayer();
        public static OST currentlySelectedOST = OST.Doom;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
        }
    }
}
