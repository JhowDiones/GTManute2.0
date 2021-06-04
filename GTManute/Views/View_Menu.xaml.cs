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
using GTManute.Views.Lançamento;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Menu.xaml
    /// </summary>
    public partial class View_Menu : Window
    {
        public View_Menu()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void Home2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cadastro.View_CadFornecedores view_Abast = new Cadastro.View_CadFornecedores();
            view_Abast.Show();
        }

        private void btn_Config_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View_Banco view_Banco = new View_Banco();
            view_Banco.ShowDialog();
        }

        private void Home3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Lançamento.View_Abast view_Abast = new Lançamento.View_Abast();
            view_Abast.Show();
        }
    }
}
