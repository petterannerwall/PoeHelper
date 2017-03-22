using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AForge;
using AForge.Imaging;

namespace ExileHelper
{
    /// <summary>
    /// Interaction logic for PoETradeWindowOverlay.xaml
    /// </summary>
    public partial class PoETradeWindowOverlay : Window
    {
        public PoETradeWindowOverlay()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CellScreenshot(i, j);
                }
            }


        }

        private void CellScreenshot(int column, int row)
        {
            string name = "Row_" + row.ToString() + "_Column_" + column.ToString();

            var cellHeight = (inventoryGrid.RowDefinitions.First().ActualHeight) * 1.25;
            var cellWidth = (inventoryGrid.ColumnDefinitions.First().ActualWidth) * 1.25;
            System.Windows.Point locationFromWindow = Cell_1_1.TranslatePoint(new System.Windows.Point(0, 0), this);
            System.Windows.Point locationFromScreen = Cell_1_1.PointToScreen(locationFromWindow);

            var calcX = locationFromScreen.X + (row * cellHeight);
            var calcY = locationFromScreen.Y + (column * cellWidth); ;

            cellWidth = cellWidth - 7;
            cellHeight = cellHeight - 7;

            Screenshot((int)calcX + 2, (int)calcY + 2, 30, 30, name);
        }

        private void Screenshot(int top, int left, int width, int height, string name)
        {
            Rectangle rect = new Rectangle(top, left, width, height);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("images/" + name + ".jpg", ImageFormat.Jpeg);
        }

    }

}
