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
        Data.Deportament deport;
        Data.Staff staff;

        public StaffsWindow(ref Data.Deportament Deportament, ref Data.Staff Staff)
        {
            InitializeComponent();
            deport = Deportament;
            staff = Staff;

            DeportamentForm.Items.Add(staff.Deportament);     //To-do: переделать.
            AgeForm.Text = staff.Age.ToString();
            LastNameForm.Text = staff.LastName;
            FirstNameForm.Text = staff.FirstName;
            IDForm.Text = staff.Id.ToString();
            SalaryForm.Text = staff.Salary.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)   //Кнопка Ok
        {
            staff.Deportament = deport;
            staff.LastName = LastNameForm.Text;
            staff.FirstName = FirstNameForm.Text;
            staff.Age = Convert.ToInt32(AgeForm.Text);
            staff.Salary = Convert.ToUInt32(SalaryForm.Text);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //Кнопка Cancel
        {
            this.Close();
        }
    }
}
