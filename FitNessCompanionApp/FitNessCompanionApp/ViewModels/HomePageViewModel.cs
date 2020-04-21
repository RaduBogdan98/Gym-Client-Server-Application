using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace FitNessCompanionApp.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public HomePageViewModel(Canvas canvas)
        {
            this.canvas = canvas;
        }

        #region Methods
        internal void setImageChangeTimer()
        {
            doFadeInAnimation();

            myTimer = new Timer();
            myTimer.Interval = 6000;
            myTimer.Start();
            myTimer.Elapsed += MyTimer_Elapsed;
        }

        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            myTimer.Stop();
            if (index == (bannerImages.Count() - 1))
            {
                index = 0;
            }
            else
            {
                index++;
            }

            doFadeOutAnimation();
            myTimer = new Timer();
            myTimer.Interval = 2000;
            myTimer.Start();
            myTimer.Elapsed += ChangeImage;
        }

        private void ChangeImage(object sender, ElapsedEventArgs e)
        {
            myTimer.Stop();
            NotifyPropertyChanged("DisplayedImage");
            setImageChangeTimer();
        }


        private void doFadeOutAnimation()
        {
            canvas.Dispatcher.Invoke(() =>
            {
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(1500));
                canvas.BeginAnimation(Canvas.OpacityProperty, animation);
            });
        }

        private void doFadeInAnimation()
        {
            canvas.Dispatcher.Invoke(() =>
            {
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(1500));
                canvas.BeginAnimation(Canvas.OpacityProperty, animation);
            });
        }
        #endregion

        #region Properties
        public String DisplayedImage
        {
            get
            {
                return "../../Images/Banner/" + bannerImages[index];
            }
        }
        #endregion

        #region Fields
        private int index = 0;
        private Canvas canvas;
        Timer myTimer;
        private List<String> bannerImages = new List<string>()
        {
            "banner1.jpg",
            "banner2.jpg",
            "banner3.jpg"
        };
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region PropertyChangedImplementation
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
