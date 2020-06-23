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
using BLFactory;
using BL;
using BE;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IBL Bl ;
        //public static object fufu;
        public static int a;
        public MainWindow()
        {
            InitializeComponent();
            Bl = new BlFactory().GetBL();
           
        }
        public static void add(object obj)
        {
            try
            {
            switch (a)
            {
                case 0:
                    if (obj is Client)
                    {
                        new BlFactory().GetBL().add_client((Client)obj);
                    }
                    break;
                case 1:
                    if (obj is car)
                    {
                        new BlFactory().GetBL().add_car(obj as car);
                    }
                    break;
                case 2:
                    if (obj is Fault)
                    {
                        new BlFactory().GetBL().add_Fault(obj as Fault);
                    }
                    break;
                case 3:
                    if (obj is Renting)
                    {
                        new BlFactory().GetBL().add_rent(obj as Renting);
                    }
                    break;
                default:
                    break;
            }
            }
             catch (Exception e)
            {
                
                MessageBox.Show(e.Message,"ERROR",MessageBoxButton.OK,MessageBoxImage.Error);;
            }
        }
        public static void del_obj(object obj)
        {
            try
            {
                switch (a)
                {
                    case 0:
                        if (obj is Client)
                        {
                            new BlFactory().GetBL().del_client(obj as Client);
                        }
                        break;
                    case 1:
                        if (obj is car)
                        {
                            new BlFactory().GetBL().del_car(obj as car);
                        }
                        break;
                    case 2:
                        if (obj is Fault)
                        {
                            new BlFactory().GetBL().del_Fault(obj as Fault);
                        }
                        break;
                    case 3:
                        if (obj is Renting)
                        {
                            new BlFactory().GetBL().del_rent(obj as Renting);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message); ;
            }
        }
        public static void del_number(object obj)
        {
            try
            {
                switch (a)
                {
                    case 0:
                        if (obj is long)
                        {
                            new BlFactory().GetBL().del_client((long)obj);
                        }
                        break;
                    case 1:
                        if (obj is int)
                        {
                            new BlFactory().GetBL().del_car((int)obj);
                        }
                        break;
                    case 2:
                        if (obj is int)
                        {
                            new BlFactory().GetBL().del_Fault((int)obj);
                        }
                        break;
                    case 3:
                        if (obj is long)
                        {
                            new BlFactory().GetBL().del_rent((long)obj);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message); ;
            }
        }
        public static void add_rand()
        {
            try
            {
                switch (a)
                {
                    case 0:
                            new BlFactory().GetBL().createListOfClient();
                            MessageBox.Show("נוסף לקוח בהצלחה","",MessageBoxButton.OK,MessageBoxImage.Information);
                        break;
                    case 1:
                            new BlFactory().GetBL().createListOfCar();
                            MessageBox.Show("נוסף רכב בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 2:
                            new BlFactory().GetBL().createListOfFault();
                            MessageBox.Show("נוסף תקלה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 3:
                            new BlFactory().GetBL().createListOfRent();
                            MessageBox.Show("נוסף חוזה הצלחה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message); ;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cmb.SelectedIndex!=-1)
            {
                Window1 w = new Window1();
                w.Show();
               // Window.GetWindow(this).Close();
            }
           
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            a = cmb.SelectedIndex;
        }
    }
}
