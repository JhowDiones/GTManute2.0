using Ionic.Zip;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
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
                string url = "https://j-tec.000webhostapp.com/GTManuteUp/InstallManute.zip";
                try
                {
                    Thread thread = new Thread(() =>
                    {
                        WebClient client = new WebClient();
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        String nomeArquivo = Path.GetFileName(url);
                        client.DownloadFileAsync(new Uri(url), @"C:\GTManute\Updates\" + nomeArquivo);
                    });
                    thread.Start();
                }
                catch
                {

                }
            }
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
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
