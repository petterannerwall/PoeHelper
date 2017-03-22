
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Input;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for findCurrencyWindow.xaml
    /// </summary>
    public partial class findCurrencyWindow : Window
    {
        ImageComparer _imageComparer;

        public findCurrencyWindow()
        {
            InitializeComponent();
            _imageComparer = new ImageComparer();
        }


        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            var height = (int)(this.ActualHeight * 1.25);
            var width = (int)(this.ActualWidth * 1.25);

            System.Windows.Point locationFromWindow = this.TranslatePoint(new System.Windows.Point(0, 0), this);
            System.Windows.Point locationFromScreen = this.PointToScreen(locationFromWindow);

            var top = (int)locationFromScreen.X;
            var left = (int)locationFromScreen.Y;

            Bitmap screenshot = Screenshot(top, left, width, height);

            var result = _imageComparer.findCurrency(screenshot);
            
             Application.Current.Dispatcher.Invoke((Action)delegate
            {
                resultListbox.ItemsSource = result;

            });


        }

        private Bitmap Screenshot(int top, int left, int width, int height)
        {
            Rectangle rect = new Rectangle(top, left, width, height);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("images/findCurrencyScreenshot.jpg", ImageFormat.Jpeg);

            return bmp;
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
