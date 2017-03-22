using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileHelper
{
    public class ImageComparer
    {
        public List<string> findCurrency(Bitmap image)
        {
            List<string> foundCurrencies = new List<string>();
            var currencies = Directory.GetFiles(@"C:\SourceControl\PoEHelper\ExileHelper\bin\Debug\currency");

            foreach (var currency in currencies)
            {
                Bitmap sourceImage = (Bitmap)Bitmap.FromFile(currency);
                int hits = compareImages(image, sourceImage);
                if (hits > 0)
                {
                    foundCurrencies.Add(Path.GetFileNameWithoutExtension(currency) + " - " + hits.ToString());
                }
            }

            return foundCurrencies;
        }


        private int compareImages(Bitmap sourceImage, Bitmap template)
        {
            sourceImage = ConvertToFormat(sourceImage, PixelFormat.Format24bppRgb);
            template = ConvertToFormat(template, PixelFormat.Format24bppRgb);

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.95f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(sourceImage, template);
            // highlight found matchings

            BitmapData data = sourceImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {

                AForge.Imaging.Drawing.Rectangle(data, m.Rectangle, System.Drawing.Color.White);

                var match = true;
                // do something else with matching
            }
            sourceImage.UnlockBits(data);

            return matchings.Count();
        }

        public static Bitmap ConvertToFormat(System.Drawing.Image image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }
    }
}
