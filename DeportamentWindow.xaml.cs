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
        Data.Deportament deport;      //новый или редактируемый депортамент
        Data.Deportament curDep;        //Выбранный депотамент

        /// <summary>
        /// Создание или редактирование депортамента.
        /// </summary>
        /// <param name="deportament">Передать выбранный депортамент.</param>
        /// <param name="CurrentDeportament">Применяется если создается депортамент.</param>
        public DeportamentWindow(Data.Deportament deportament ,Data.Deportament CurrentDeportament = null)
        {
            InitializeComponent();
            
            deport = deportament ;
            curDep = CurrentDeportament;

            //Запорлняем форму полями
            DatePicForm.SelectedDate = deport.CreatedDate;
            CountStaffForm.Text = deport.Staffs.Count.ToString();
            NameForm.Text = deport.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //Кнопка Ok
        {
            
            //Соханяем данные из UI в обьек депорртамента
            deport.CreatedDate = DatePicForm.SelectedDate.Value;
            deport.Name = NameForm.Text;
            if (curDep != null)  //Проверяем что был передан выбранный депортамент
            {
                if (curDep.Deportaments == null)         //Проверяем инициализирована ли коллекция дочерних депортаментов.
                    curDep.Deportaments = new ObservableCollection<Data.Deportament>();        //Инициализируем коллекцию дочерних депортаментов.
                curDep.Deportaments.Add(deport);         //Добовляем новый дочерний депортамент для выбранного депортамента.
            }
            else 
            {
                MainWindow.Deportaments.Add(deport);
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //Кнопка Cancel
        {
            this.Close();
        }
    }
}
