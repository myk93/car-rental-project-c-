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

namespace PL_FORMS
{
    /// <summary>
    /// Interaction logic for end_rent_tkinut.xaml
    /// </summary>
    public partial class end_rent_tkinut : Window
    {
        public static BE.Renting r =new BE.Renting();
        public static BE.Fault fa;
        public end_rent_tkinut(BE.Renting re )
        {
            re = r;
            InitializeComponent();
            com_gorm.Items.Add(BE.who_fault.blay);
            com_gorm.Items.Add(BE.who_fault.Negligence);
       
            com_kind.Items.Add(BE.fault_type.betichut);
            com_kind.Items.Add(BE.fault_type.blamim);
            com_kind.Items.Add(BE.fault_type.chasmal);
            com_kind.Items.Add(BE.fault_type.gir);
            com_kind.Items.Add(BE.fault_type.light);
            com_kind.Items.Add(BE.fault_type.magavim);
            com_kind.Items.Add(BE.fault_type.marout);
            com_kind.Items.Add(BE.fault_type.mazgan);
            com_kind.Items.Add(BE.fault_type.mnoah);
            com_kind.Items.Add(BE.fault_type.pancher);
            com_kind.Items.Add(BE.fault_type.pch);
            com_kind.Items.Add(BE.fault_type.plastica);
            com_kind.Items.Add(BE.fault_type.radio);
            com_kind.Items.Add(BE.fault_type.tipulTen);
            com_kind.Items.Add(BE.fault_type.tzeva);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (com_gorm.SelectedIndex == -1 || com_kind.SelectedIndex == -1 || com_num.SelectedIndex == -1)
            {
                 MessageBox.Show("בשביל אישור עלייך למלאות את השדות.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            pri.Text = fa.total_price.ToString();
            new BLFactory.BlFactory().GetBL().update_Fault(fa, BE.update.gorm_htakla, (BE.who_fault)com_gorm.SelectedValue);
            r.is_defcive=true;
            new BLFactory.BlFactory().GetBL().update_rent(r,BE.update.gorm_htakla,false);
          BE.car ca =new BE.car();
          foreach (BE.car item in (new BLFactory.BlFactory().GetBL().return_list(retur.car)))
	                 if (item.car_number == r.number_of_rishui){
                        ca= item;
                         break;
                     }
          new BLFactory.BlFactory().GetBL().update_car(ca, BE.update.takin, false);
          new BLFactory.BlFactory().GetBL().add_Car_fault(ca.car_number, fa.fault_number);    
            MessageBox.Show(" השדות של הרכב, תקלות ותקלת מכונית עודכנו.", "אישור תקלה", MessageBoxButton.OK, MessageBoxImage.Information);
		     this.Close();
	    }
      

        private void com_kind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (BE.Fault item in new BLFactory.BlFactory().GetBL().return_list(BE.retur.fault))
                if ((BE.fault_type)com_kind.SelectedValue == item.Ft)
                {
                    com_num.Items.Add(item.fault_number);
                }
                    
        }

        private void com_num_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (BE.Fault item in new BLFactory.BlFactory().GetBL().return_list(BE.retur.fault))
	              if(item.fault_number == (int)com_num.SelectedValue){
                      fa = new BE.Fault();
                      fa=item;
                      break;
                  }
        }

        private void com_gorm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fa.who = (BE.who_fault)com_gorm.SelectedValue;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//כפתור סיום
        {
            if (MessageBox.Show("אתה בטוח שברצונך לבטל", "אזהרה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
