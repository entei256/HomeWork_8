using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Data.Deportament> Deportaments { get; set; }

        public MainWindow()
        {
            Deportaments = new ObservableCollection<Data.Deportament>();
            InitializeComponent();
            Deportaments.Add(new Data.Deportament()
            {
                Name = "Node 1",
                Deportaments = new ObservableCollection<Data.Deportament>()
                {
                    new Data.Deportament()
                    {
                        Name = "subNode",
                        Staffs = new ObservableCollection<Data.Staff>()
                        {
                            new Data.Staff{LastName  = "kkk",FirstName="kkkkk" },
                            new Data.Staff{LastName  = "ddd",FirstName="ddddd" },
                            new Data.Staff{LastName  = "sss",FirstName="sssss" },
                            new Data.Staff{LastName  = "aaa",FirstName="aaaaa" },
                            new Data.Staff{LastName  = "zzz",FirstName="zzzzz" }
                        },
                        Deportaments = new ObservableCollection<Data.Deportament>()
                        {
                            new Data.Deportament()
                            {
                                Name = "subNode",
                                Deportaments = new ObservableCollection<Data.Deportament>()
                        {
                            new Data.Deportament()
                            {
                                Name = "subNode",
                                Deportaments = new ObservableCollection<Data.Deportament>()
                        {
                            new Data.Deportament()
                            {
                                Name = "subNode"
                            }
                        }
                            }
                        }
                            }
                        }
                    }
                }
            }   //Тестовые  данные
            );
            DeportamentView.ItemsSource = Deportaments;
        }

        #region кнопки депортамента
        private void MenuItem_Click(object sender, RoutedEventArgs e)  //Добавить депортамент
        {
            var DAForm = new DeportamentWindow();
            DAForm.ShowDialog();
        }

        private void EditDeportament_Click(object sender, RoutedEventArgs e)  //Редактировать депортамент
        {
            var DEForm = new DeportamentWindow();
            DEForm.ShowDialog();
        }

        private void DeleteDeportament_Click(object sender, RoutedEventArgs e)  //Удалить депортамент
        {

        }
        #endregion

        #region Кнопки Сотрудников
        private void AddStaff_Cilck(object sender, RoutedEventArgs e)    //Добавить сотрудника
        {
            var SAForm = new StaffsWindow();
            SAForm.ShowDialog();
        }

        private void EditStaff_Click(object sender, RoutedEventArgs e)  //Редактировать сотрудника
        {
            var SEForm = new StaffsWindow();
            SEForm.ShowDialog();
        }

        private void DeleteStaff_Click(object sender, RoutedEventArgs e)  //Удалить сотрудника
        {

        }
        #endregion

#region Кнопки сортировки
        private void SortByName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortByLastName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortByAge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortById_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SortBySolary_Click(object sender, RoutedEventArgs e)
        {

        }
#endregion
    }
}
