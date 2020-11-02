using SkiaSharp;
using SkiaSharp.QrCode;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace QrCode
{
   class Program
    {
        static void Main(string[] args)
        {
            var g = new QRCodeGenerator();
            var lvl = ECCLevel.H;

            var content = "https://diegoadias.online/";

            var qr = g.CreateQrCode(content, lvl);
            var inf = new SKImageInfo(256, 256);

            var srfce = SKSurface.Create(inf);

            var cnvs = srfce.Canvas;
            cnvs.Render(qr, 256, 256, SKColors.White);

            var img = srfce.Snapshot();
            var dat = img.Encode(SKEncodedImageFormat.Png, 100);
            var stream = File.OpenWrite(@"Teste.png");

            dat.SaveTo(stream);

            img.Dispose(); dat.Dispose(); stream.Close(); stream.Dispose();

            Image img2 = Image.FromFile(@"Teste.png");

            Graphics g2 = Graphics.FromImage(img2);
            g2.DrawImage(Image.FromFile("Rei.png"), new Point(100, 80));
            g2.Dispose();

            img2.Save("output.png", ImageFormat.Png);
            img2.Dispose();
        }
    }
}
