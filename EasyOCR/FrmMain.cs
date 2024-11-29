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
            cmbLanguage.SelectedIndex = 0;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                // https://www.c-sharpcorner.com/article/ocr-using-tesseract-in-C-Sharp/
                // https://ironsoftware.com/csharp/ocr/examples/intl-languages/
                // https://www.youtube.com/watch?v=X0wW4KyLvJ4
                var ocr = new IronOcr.IronTesseract();
                var lang = cmbLanguage.SelectedItem.ToString();
                if (lang == "English")
                    ocr.Language = IronOcr.OcrLanguage.English;
                if (lang == "SerbianLatin")
                    ocr.Language = IronOcr.OcrLanguage.SerbianLatin;
                if (lang == "CyrillicAlphabet")
                    ocr.Language = IronOcr.OcrLanguage.CyrillicAlphabet;
                //ocr.Configuration.WhiteListCharacters = "0123456789-";

                var start = DateTime.Now;
                using (var ocrInput = new IronOcr.OcrInput())
                {
                    //var dialog = new OpenFileDialog();
                    //if (dialog.ShowDialog() != DialogResult.OK)
                    //    return;
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

            using (var soundPlayer = new System.Media.SoundPlayer(@"c:\Windows\Media\ringout.wav"))
                soundPlayer.Play();
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
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
    }
}
