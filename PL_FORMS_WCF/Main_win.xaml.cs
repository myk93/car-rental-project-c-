﻿using System;
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
    /// Interaction logic for Main_win.xaml
    /// </summary>
    public partial class Main_win : Window
    {
        public Main_win()
        {
            InitializeComponent();
            MessageBox.Show("Test");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
