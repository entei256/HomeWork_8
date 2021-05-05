using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для DeportamentWindow.xaml
    /// </summary>
    public partial class DeportamentWindow : Window
    {
        Data.Deportament deport;
        public DeportamentWindow(ref Data.Deportament deportament)
        {
            InitializeComponent();
            deport = deportament;
            DatePicForm.SelectedDate = deport.CreatedDate;
            CountStaffForm.Text = deport.Staffs.Count.ToString();
            NameForm.Text = deport.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //Кнопка Ok
        {
            deport.CreatedDate = DatePicForm.SelectedDate.Value;
            deport.Name = NameForm.Text;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //Кнопка Cancel
        {
            this.Close();
        }
    }
}
