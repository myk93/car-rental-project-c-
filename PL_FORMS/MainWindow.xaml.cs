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
        CryptoRC4.RC4Engine[] t = new CryptoRC4.RC4Engine[]
        {
            new CryptoRC4.RC4Engine(1),
            new CryptoRC4.RC4Engine(),
            new CryptoRC4.RC4Engine(true)
        };
        public IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            bl = new BLFactory.BlFactory().GetBL();
           
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool temp = false;
            for (int i = 0; i < 3; i++)
            {
                if (t[i].istrue(pass_box.Password, tb_box.Text.ToLower()))
                {
                    ma_win mw = new ma_win();
                    mw.Show();
                    temp = true;
                }

              //  MessageBox.Show(t[i].encripted);
            }
            if (!temp)
            {
                MessageBox.Show("שם משתמש או סיסמא אינם נכונים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                this.Close();
            }

            //ma_win mw = new ma_win();
            //mw.Show();
            //this.Close();
        }

        private void pass_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Device is KeyboardDevice)
            {
                if (e.Key == Key.Enter)
                {
                    Button_Click(sender, new RoutedEventArgs());
                }
            }
        }
    }
}
