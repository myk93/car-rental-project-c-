using BL;
using BLFactory;
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

namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for kabla.xaml
    /// </summary>
    public partial class kabla : Window
    {
        public BE.car ca;
        public kabla(BE.Renting rent)
        {
            IBL bl = new BlFactory().GetBL();

            ca = new BE.car();
            InitializeComponent();
            texst_end_time.Text = DateTime.Now.ToString();
            lchod.Text = rent.driver.first_id.ToString();
            text_azma.Text = rent.number_of_rishui.ToString();
            text_risuy.Text = rent.number_of_rishui.ToString();
            foreach (BE.car t in bl.return_list(BE.retur.car))
            if (t.car_number == rent.number_of_rishui)
                {
                    ca= t;
                    text_gir.Text = t.car_gear.ToString();
                    text_category.Text = t.rishion.type.ToString();
                    texst_doors.Text = t.number_of_car_doors.ToString();
                    texst_mekomot.Text = t.car_people_able.ToString();
                    break;
                }
            text_stat_time.Text = rent.start_rent.ToString("dd/MM/yyyy");
            r_end_tim.Text = rent.end_rent.ToString("dd/MM/yyyy");
            days.Text = rent.days.ToString();
            start_KM.Text =rent.start_rent.ToString();
            end_KM.Text = rent.number_at_end.ToString();
            neto_dis.Text = ((int)(rent.number_at_end - rent.number_at_start)).ToString();
            tkinut.Text = rent.is_defcive.ToString();
            if (!(bool.Parse(tkinut.Text)))
            {
                gorm.Visibility = System.Windows.Visibility.Collapsed;
                gorm_t.Visibility = System.Windows.Visibility.Collapsed;
               //gorm.Text= rent.
                kind_fault.Visibility = System.Windows.Visibility.Collapsed;
                ////להמשיך למלות
            }///////////////////////////--------------------------------//////////////////////-----------------------------//////////////////////////--------------------//////////////
            string a="";
            foreach (BE.Client t in bl.return_list(BE.retur.client))
                if (t.Id1 == rent.driver.first_id){
                     a=t.Card_dit.number_c.ToString();
                    break;
                }
            for (int i = 0; i < a.Length-4; i++)
                card.Text += "*";
            card.Text += (" - "+a[a.Length - 4] + a[a.Length - 3] + a[a.Length - 2] + a[a.Length - 1]).ToString();
            sum.Text = rent.price.ToString();
            sof_sum.Text = (rent.price * 1.18F).ToString();
        }
    }
}
