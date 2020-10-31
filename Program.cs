using SkiaSharp;
using SkiaSharp.QrCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var content = "https://diegoadias.online/";
            var g = new QRCodeGenerator();
            var level = ECCLevel.Q;
            var qr = g.CreateQrCode(content, level);
            var i = new SKImageInfo(256, 256);
            var surface = SKSurface.Create(i);
            var canvas = surface.Canvas;
            
            canvas.Render(qr, 256, 256, SKColors.White);

            var img = surface.Snapshot();
            var d = img.Encode(SKEncodedImageFormat.Png, 100);
            var stream = File.OpenWrite(@"Teste.png");
            
            d.SaveTo(stream);
        }
    }
}
