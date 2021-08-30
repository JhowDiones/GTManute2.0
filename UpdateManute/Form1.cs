using Ionic.Zip;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace UpdateManute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnDownload_Click();
        }
        
        private void BtnDownload_Click()
        {

            string path = @"c:\GTManute\Updates\InstallManute.zip";

            try
            {
                // Determine whether the directory exists.
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://j-tec.000webhostapp.com/GTManuteUp/InstallManute.zip"),
                        // Param2 = Path to save
                        "C:\\GTManute\\Updates\\InstallManute.zip"

                    );
                    Descompactar();
                }
                catch
                {

                }
            }
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage - 10;
        }
        public void Descompactar()
        {
            ZipFile arquivoZip = ZipFile.Read("C:\\GTManute\\Updates\\InstallManute.zip");
            try
            {
                foreach (ZipEntry e in arquivoZip)
                {
                    e.Extract("C:\\GTManute\\Updates");
                    progressBar1.Value = 100;
                    MessageBox.Show("Instalador extraido com sucesso! Finalize a atualização pelo instalador!!!");
                }
                arquivoZip.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
