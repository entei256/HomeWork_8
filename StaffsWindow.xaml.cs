using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork_8
{
    /// <summary>
    /// Логика взаимодействия для StaffsWindow.xaml
    /// </summary>
    public partial class StaffsWindow : Window
    {
        public StaffsWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)   //Кнопка Ok
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //Кнопка Cancel
        {
            this.Close();
        }
    }
}
