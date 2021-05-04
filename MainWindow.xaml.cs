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
        public Data.Deportament SelectedDeportament { get; set; }
        public Data.Staff SelectedStaff { get; set; }

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
                            },
                            new Data.Deportament()
                            {
                                Name = "subNode2"
                            },
                            new Data.Deportament()
                            {
                                Name = "subNode3"
                            },
                        }
                            }
                        }
                            }
                        }
                    }
                }
            }   //Тестовые данные
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
            DeletedDeportament(DeportamentView.SelectedItem as Data.Deportament, Deportaments);
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

        #region Кнопки загрузки и сохранения
        private void LoadDataBtn_Click(object sender, RoutedEventArgs e)   //Загрузка XML файла
        {
            ObservableCollection<Data.Deportament> LoadedCollection = FileHelper.LoadFile(FileTypeSerialization.Xml);

            foreach(var dep in LoadedCollection)
            {
                Deportaments.Add(dep);
            }

        }

        private void SaveDataBtn_Click(object sender, RoutedEventArgs e)  //Сохранение XML файла
        {
            FileHelper.SaveFile(Deportaments, FileTypeSerialization.Xml);
        }

        private void LoadJSONDataBtn_Click(object sender, RoutedEventArgs e)  //Загррузка JSON файла
        {
            ObservableCollection<Data.Deportament> LoadedCollection = FileHelper.LoadFile(FileTypeSerialization.Json);
            foreach (var dep in LoadedCollection)
            {
                Deportaments.Add(dep);
            }
        }

        private void SaveJSONDataBtn_Click(object sender, RoutedEventArgs e) //Сохранение JSON файла
        {
            FileHelper.SaveFile(Deportaments, FileTypeSerialization.Json);
        }
        #endregion

        /// <summary>
        /// Рекурсивный метод удаления депортаментов
        /// </summary>
        /// <param name="deportament">Передать депорртамент к удалению</param>
        /// <param name="targetCollection">передать список на удаление</param>
        /// <returns>Флаг найден элемент для удаления или нет.</returns>
        private bool DeletedDeportament(Data.Deportament deportament, ObservableCollection<Data.Deportament> targetCollection)
        {
            bool FoundItems = false;  //Фллаг что элемент найден
            foreach(var dep in targetCollection) //Проходимся по всему переданному списку
            {
                if (dep.Equals(DeportamentView.SelectedItem))        //Если елемент удаления найден. Возможен баг: когда два одинаковых елемента в соседних ветках дерева, удаляться оба.
                {
                    FoundItems = true;                                  //Меняем флаг на true
                    targetCollection.Remove(dep);                       //Удаляем найденый элемент
                    return FoundItems;                                  //Выходим с передачей что элемент найден
                }
                else
                { 
                    if(dep.Deportaments != null && dep.Deportaments.Count >= 1)       //Если есть дочернии элементы
                        if(DeletedDeportament(deportament, dep.Deportaments))               //Если рекурсия возвращяет true
                        { return true; }                                              //Возвращаем выше что элемент найден.
                }
            }


            return FoundItems;
        }
    }
}
