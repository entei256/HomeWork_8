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
        Data.Deportament deport;          // текущий депортамент
        public Data.Staff staff { get; set; }    //Текущий сотрудник
        bool IsCreated = false;       //Флаг создан новый сотрудник или нет.


        /// <summary>
        /// Окно создания или редоктирования сотрудника
        /// </summary>
        /// <param name="Deportament">Текущий выбранный депортамент.</param>
        /// <param name="Staff">Передать сотррудника только если требуется его отредактировать.</param>
        public StaffsWindow(Data.Deportament Deportament, Data.Staff Staff = null)
        {
            InitializeComponent();
            deport = Deportament;          //Сохраняем ссылку на указанный депортамент.
            staff = Staff;                 //Сохраняем ссылку на обьек сотрудника.
            if (staff != null)              //Если передали сотрудника то загрружаем поля  в UI
            {
                AgeForm.Text = staff.Age.ToString();
                LastNameForm.Text = staff.LastName;
                FirstNameForm.Text = staff.FirstName;
                IDForm.Text = staff.Id.ToString();
                SalaryForm.Text = staff.Salary.ToString();

            }
            DeportamentForm.Text = deport.Name;    //Отображаем название текущего депортамента
        }

        private void Button_Click(object sender, RoutedEventArgs e)   //Кнопка Ok
        {
            if (staff == null)          //Если не   передавался сотрудник то его создаем.
            {
                staff = new Data.Staff();
                IsCreated = true;                  //Меняем флаг что бы определять что это создание сотрудника а не его редактирование
            }
            #region Прописываем новые поля в сотрудника
            staff.LastName = LastNameForm.Text;                
            staff.FirstName = FirstNameForm.Text;
            staff.Age = Convert.ToInt32(AgeForm.Text);
            staff.Salary = Convert.ToUInt32(SalaryForm.Text);
            #endregion
            if (deport.Staffs == null)            //Проверяем что у депортамента не инициализирована коллекция сотрудников.
            {
                deport.Staffs = new System.Collections.ObjectModel.ObservableCollection<Data.Staff>();   //Инициализируем коллекцию сотрудников у депортамента
                deport.Staffs.Add(staff);                           //Добовляем нового сотрудника для депортамента
            }
            if (IsCreated)
                deport.Staffs.Add(staff);          //Добовляем нового сотрудника для депортамента

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //Кнопка Cancel
        {
            this.Close();
        }
    }
}
