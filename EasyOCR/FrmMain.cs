using System;
using System.Drawing;
using System.IO;
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
                var ocr = new IronOcr.IronTesseract { Language = IronOcr.OcrLanguage.CyrillicAlphabet };
                //var ocr = new IronOcr.IronTesseract();
                //ocr.Configuration.WhiteListCharacters = "0123456789-";
                //var dialog = new OpenFileDialog();
                //if (dialog.ShowDialog() != DialogResult.OK)
                //    return;
                var start = DateTime.Now;
                using (var ocrInput = new IronOcr.OcrInput() )
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
                    // MessageBox.Show(ocrResult.Text, $"OCR ({ocrResult.Confidence:00}%)");
                    if (!string.IsNullOrEmpty(ocrResult.Text))
                        Clipboard.SetText(ocrResult.Text);
                }
                System.Diagnostics.Debug.WriteLine((DateTime.Now - start).TotalMilliseconds);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ocr"); }
        }

        Size? imgSize = null;
        int cntClipboardImgChanges = 0;

        private void Tim_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    var img = Clipboard.GetImage();
                    if (!imgSize.HasValue || imgSize.Value != img.Size)
                    {
                        imgSize = img.Size;
                        lblClipboardImgChanges.Text = (++cntClipboardImgChanges).ToString();
                        btnTest.PerformClick();
                    }
                }
                else
                    imgSize = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
