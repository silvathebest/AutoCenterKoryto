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

namespace AutoCenterKorytoView
{
    /// <summary>
    /// Логика взаимодействия для WindowClientWishes.xaml
    /// </summary>
    public partial class WindowClientWishes : Window
    {
        public WindowClientWishes()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowClientWishe window = new WindowClientWishe();
            window.ShowDialog();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowClientWishe window = new WindowClientWishe();
            window.ShowDialog();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
