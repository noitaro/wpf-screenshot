using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace wpf_webview2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 矩形領域
            var rectangle = new Rectangle(0, 0, (int)sliderH.Value, (int)sliderV.Value);
            var bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            var graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(new System.Drawing.Point(rectangle.X, rectangle.Y), new System.Drawing.Point(0, 0), bitmap.Size);
            // グラフィックスの解放
            graphics.Dispose();

            // 画像の表示
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
}
