using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GTManute.Views.CompanyControl
{
    /// <summary>
    /// Lógica interna para Control_Acesso.xaml
    /// </summary>
    public partial class Control_Acesso : Window
    {
        public Control_Acesso()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime agora = DateTime.Now;
            string senha = "Di32383074" + agora.ToString("HHmm");
            if (senha == textBox.Text)
            {
                Company_Control control = new Company_Control();
                control.ShowDialog();
            }
            else
            {
                MessageBox.Show("Senha invalida!");
            }
        }
    }
}
