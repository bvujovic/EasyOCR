using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyOCR
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                // https://www.c-sharpcorner.com/article/ocr-using-tesseract-in-C-Sharp/
                // https://ironsoftware.com/csharp/ocr/examples/intl-languages/
                // https://www.youtube.com/watch?v=X0wW4KyLvJ4
                //var ocr1 = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.Serbian };
                //var ocr = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.CyrillicAlphabet };
                var ocr = new IronOcr.IronTesseract();
                //ocr.Configuration.WhiteListCharacters = "0123456789-";
                //var dialog = new OpenFileDialog();
                //if (dialog.ShowDialog() != DialogResult.OK)
                //    return;

                using (var ocrInput = new IronOcr.OcrInput())
                {
                    //ocrInput.AddImage(dialog.FileName);

                    var bmp = Clipboard.GetImage() as Bitmap;
                    using (var ms = new MemoryStream())
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ocrInput.AddImage(ms.ToArray());
                    }

                    // ocrInput.AddPdf("document.pdf");
                    var ocrResult = ocr.Read(ocrInput);
                    MessageBox.Show(ocrResult.Text, $"OCR ({ocrResult.Confidence:00}%)");
                    Clipboard.SetText(ocrResult.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ocr"); }
        }
    }
}
