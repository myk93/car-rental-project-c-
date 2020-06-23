using BE;
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
using BL;
using BLFactory;
namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for add_car_win.xaml
    /// </summary>
    public partial class add_car_win : Window
    {
        IBL bl = new BlFactory().GetBL();
        bool temp = false;
        public add_car_win()
        {
            InitializeComponent();

            for (int i = 2000; i < 2015; i++)
                year.Items.Add(i);

            string[] company = { "הונדה", "מזדה", "סובארו", "שברולט", "סוזוקי", "וולוו" };
            foreach (var item in company)
                compan.Items.Add(item);
            model.IsEnabled = false;
            for (int i = 1000; i < 4000; i+=100)
                manoa.Items.Add(i);
            gir.Items.Add(BE.gear.automety);
            gir.Items.Add(BE.gear.yadni);
            for (int i = 2; i < 8; i++)
			  mekomot.Items.Add(i);
			
            for (int i = 2; i < 5; i++)
                door.Items.Add(i);
			for (int i = 1; i < 13; i++)
                month_test.Items.Add(i);
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
                year_test.Items.Add(i);
            for (int i = 0; i < 5; i++)
                categorya.Items.Add((BE.catagory_of_vehicles)i);

            takin_combo.Items.Add(true);
            takin_combo.Items.Add(false);
            muskar_combo_Copy.Items.Add(true);
            muskar_combo_Copy.Items.Add(false);
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool tkin=true,musker=false;
            int mis_rish = 0;
            if (int.Parse(tb_mis_ris.Text) != 0)
                if (tb_mis_ris.Text.Length == 7)
                    mis_rish = int.Parse(tb_mis_ris.Text);
                else
                {
                    MessageBox.Show(" מספר הרישוי של הרכב צריך להיות בן 7 ספרות \n" + "או הכנס 0 לבריירת מחדל", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (year_test.SelectedIndex == -1 || month_test.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור תאריך ");
                return;
            }
            if (categorya.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור סוג רישיון");
                return;
            }
            if (year.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור  שנת ייצור");
                return;
            }
            if (compan.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור יצרן לרכב");
                return;
            }
            if (model.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור מודל הרכב");
                return;
            }
            if (manoa.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור סוג מנוע");
                return;
            }
            if (gir.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור סוג רישיון");
                return;
            }
            if (door.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור כמה דלתות");
                return;
            }
            if (mekomot.SelectedIndex == -1)
            {
                MessageBox.Show("צריך לבחור כמה מקומות");
                return;
            }
            if (tb_build.Text.Length==0)
            {
                MessageBox.Show("צריך להכניס מספר בנין");
                return;
            }
            if (tb_city.Text.Length==0)
            {
                MessageBox.Show("צריך להכניס שם עיר");
                return;
            }
            if (tb_stre.Text.Length == 0)
            {
                MessageBox.Show("צריך להכניס שם רחוב");
                return;
            }
            if (!tkin&&!Date.SelectedDate.HasValue)
            {
                MessageBox.Show("צריך להכניס תאריך חזרה מתיקון");
                return;
            }
            if (takin_combo.SelectedIndex == 1)
                tkin=false;

            if (muskar_combo_Copy.SelectedIndex == 0)
                musker = true;

            car_type ct;
            ct.Engine_capacety=(int)manoa.SelectedItem;
            ct.Manufacturer=(string)compan.SelectedItem;
            ct.model=(string)model.SelectedItem;

            addres a;
            a.building=int.Parse(tb_build.Text);
            a.city=tb_city.Text;
            a.street=tb_stre.Text;
            float dis=0;
            dis = float.Parse(KM.Text);
            rishion_rachav rr;
            rr.test=new DateTime((int)year_test.SelectedItem,(int)month_test.SelectedItem,1);
            rr.type=(catagory_of_vehicles)categorya.SelectedItem;
            try
            {
                bl.add_car(new car(ct,(gear)gir.SelectedItem,(int)mekomot.SelectedItem,(int)door.SelectedItem,a,rr,(int)year.SelectedItem,dis,Date.SelectedDate,tkin,mis_rish,musker));
                MessageBox.Show("car was added sucsesfuly");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    
        }

        private void compan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.IsEnabled = true;
            model.Items.Clear();
            switch (compan.SelectedIndex)
            {
                case 0://הונדה
                    model.Items.Add("סיוויק");
                    model.Items.Add("אקורד");
                    model.Items.Add("ג'אז");
                    break;
                case 1://מזדה
                    model.Items.Add("3");
                    model.Items.Add("6");
                    model.Items.Add("5");
                    break;
                case 2://סובארו
                    model.Items.Add("אימפרזה");
                    model.Items.Add("לוגאסי");
                    model.Items.Add("B4");
                    model.Items.Add("B3");
                    break;
                case 3://שברולט
                    model.Items.Add("אופטרה");
                    model.Items.Add("קרוז");
                    model.Items.Add("אוויאו");
                    break;
                case 4://סוזוקי
                    model.Items.Add("סוויפט");
                    model.Items.Add("שךאם");
                    break;
                case 5://וולוו
                    model.Items.Add("v8"); 
                    model.Items.Add("v6");
                    break;
                default:
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל","אזהרה",MessageBoxButton.YesNo,MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void tb_mis_ris_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;

            foreach (var item in tb_mis_ris.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_mis_ris.Text = tb_mis_ris.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void takin_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (takin_combo.SelectedIndex == 1)
                Date.Visibility = System.Windows.Visibility.Visible;
            else
                Date.Visibility = System.Windows.Visibility.Hidden;

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_city.Text)
            {
                if (!((item <= 'z' && item >= 'A') || (item <= 'ת' && item >= 'א')))
                {
                    MessageBox.Show("צריך להכניס רק אותיות");
                    tb_city.Text = tb_city.Text.Remove(i, 1);
                }
                i++;
            }
        }

        private void KM_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;

            foreach (var item in tb_mis_ris.Text)
            {
                if (item > '9' || item < '0'&&item!='.')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_mis_ris.Text = tb_mis_ris.Text.Remove(i, 1);
                }
                i++;
            }
              
            if (tb_mis_ris.Text.Length > 0 && tb_mis_ris.Text[tb_mis_ris.Text.Length - 1] == '.' && temp)
            {
                MessageBox.Show("מותר רק נקודה עשרונית אחת");
                tb_mis_ris.Text = tb_mis_ris.Text.Remove(tb_mis_ris.Text.Length - 1);
            }
            if (tb_mis_ris.Text.Contains('.'))
            {
                temp = true;
            }   
        }
        private void tb_build_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            foreach (var item in tb_build.Text)
            {
                if (item > '9' || item < '0')
                {
                    MessageBox.Show("צריך לשלוח רק מספרים");
                    tb_build.Text = tb_build.Text.Remove(i, 1);
                }
                i++;
            }
        }      
    }
}
