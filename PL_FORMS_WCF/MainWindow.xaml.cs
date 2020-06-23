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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
using System.Collections;

namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] user = { "ezra", "manny", "pinchas" };
        string pass = "12345678";
        public IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            bl = new BLFactory.BlFactory().GetBL();
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (user.Contains(tb_box.Text) && pass_box.Password == pass)
            {
                ma_win mw = new ma_win();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("שם משתמש או סיסמא אינם נכונים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //ma_win mw = new ma_win();
            //mw.Show();
            //this.Close();
        }
    }
}
