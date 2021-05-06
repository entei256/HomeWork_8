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
        public static ObservableCollection<Data.Deportament> Deportaments { get; set; }   //Общая коллекция депортаментов.

        public MainWindow()
        {
            Deportaments = new ObservableCollection<Data.Deportament>();
            InitializeComponent();

            DeportamentView.ItemsSource = Deportaments;
        }

        #region кнопки депортамента
        private void MenuItem_Click(object sender, RoutedEventArgs e)  //Добавить депортамент
        {
            Data.Deportament newDeportament = new Data.Deportament();         //Новый элемент депортамента.
            var currDep = DeportamentView.SelectedItem as Data.Deportament;      //Текущий депортамент.
            var DAForm = new DeportamentWindow(newDeportament, currDep);        //Создаем форму добовления депортамента и передаем  выбранный депортамент и новый
            DAForm.ShowDialog();         //Открываем  форму.

            DeportamentView.Items.Refresh();

        }

        private void EditDeportament_Click(object sender, RoutedEventArgs e)  //Редактировать депортамент
        {
            Data.Deportament cangedDeportament = DeportamentView.SelectedItem as Data.Deportament;        
            var DEForm = new DeportamentWindow(cangedDeportament);                  //Передаем только какой депортамент изменить.
            DEForm.ShowDialog();
            DeportamentView.Items.Refresh();                                  //Обновляем древо что быотобразились изменения
        }

        private void DeleteDeportament_Click(object sender, RoutedEventArgs e)  //Удалить депортамент
        {
            DeportamrntActions(DeportamentView.SelectedItem as Data.Deportament, Deportaments,Action.delete);     //Пкдкдаем в метот рекурсивного поиска что и действие
        }
        #endregion

        #region Кнопки Сотрудников
        private void AddStaff_Cilck(object sender, RoutedEventArgs e)    //Добавить сотрудника
        {
            if (DeportamentView.SelectedItem == null)  //Проверка что выбран депортамент для сотрудника.
            {
                MessageBox.Show("Не выбран депортамент.");
                return;
            }
            Data.Deportament curDeport = DeportamentView.SelectedItem as Data.Deportament;
            Data.Staff newStaff = null;
            var SAForm = new StaffsWindow(curDeport,newStaff);  //Создаем форму и передаем сотрудника и 
            SAForm.ShowDialog();
            
            StaffsView.Items.Refresh();                 //Обновляем что бы отобразились изменения

        }

        private void EditStaff_Click(object sender, RoutedEventArgs e)  //Редактировать сотрудника
        {
            if (DeportamentView.SelectedItem == null || StaffsView.SelectedItem == null)       //Проверяем что выбран депортамент и сотрудник
            {
                MessageBox.Show("Не выбран депортамент или сотруднник.");
                return;
            }
            Data.Deportament curDeport = DeportamentView.SelectedItem as Data.Deportament;
            Data.Staff curStaff = StaffsView.SelectedItem as Data.Staff;
            var SEForm = new StaffsWindow(curDeport,curStaff);            //Открываем форму с передачей выбранных депортамента и сотрудника
            SEForm.ShowDialog();

            StaffsView.Items.Refresh();                                 //Обновляем что бы применить изменения
        }

        private void DeleteStaff_Click(object sender, RoutedEventArgs e)  //Удалить сотрудника
        {
            var tmpDep = DeportamentView.SelectedItem as Data.Deportament;
            tmpDep.Staffs.Remove(StaffsView.SelectedItem as Data.Staff);
        }
        #endregion

        
        #region Кнопки загрузки и сохранения
        private void LoadDataBtn_Click(object sender, RoutedEventArgs e)   //Загрузка XML файла
        {
            ObservableCollection<Data.Deportament> LoadedCollection = FileHelper.LoadFile(FileTypeSerialization.Xml); 
            Deportaments.Clear();
            foreach(var dep in LoadedCollection)     //Проходимся по всем загрруженным элементам.
            {
                Deportaments.Add(dep);             //Добовляем в список депортаментов
            }

        }

        private void SaveDataBtn_Click(object sender, RoutedEventArgs e)  //Сохранение XML файла
        {
            FileHelper.SaveFile(Deportaments, FileTypeSerialization.Xml);     //Выбираем что  и как сохранить в файл
        }

        private void LoadJSONDataBtn_Click(object sender, RoutedEventArgs e)  //Загррузка JSON файла
        {
            ObservableCollection<Data.Deportament> LoadedCollection = FileHelper.LoadFile(FileTypeSerialization.Json);     //Сохрааняем загруженные  обьекты во врременный список.
            Deportaments.Clear();
            foreach (var dep in LoadedCollection)          //Проходимся по списку обьектов загррруженных из файла.
            {
                Deportaments.Add(dep);             //Добовляем в общий список.
            }
        }

        private void SaveJSONDataBtn_Click(object sender, RoutedEventArgs e) //Сохранение JSON файла
        {
            FileHelper.SaveFile(Deportaments, FileTypeSerialization.Json);            //Указывем что и как сохранить в  файл.
        }
        #endregion

        /// <summary>
        /// Рекурсивный метод удаления депортаментов
        /// </summary>
        /// <param name="deportament">Передать депорртамент к удалению</param>
        /// <param name="targetCollection">передать список на удаление</param>
        /// <param name="action">Действие</param>
        /// <returns>Флаг найден элемент для удаления или нет.</returns>
        private bool DeportamrntActions(Data.Deportament deportament, ObservableCollection<Data.Deportament> targetCollection,Action action)
        {
            bool FoundItems = false;  //Фллаг что элемент найден
            foreach(var dep in targetCollection) //Проходимся по всему переданному списку
            {
                if (dep.Equals(deportament))        //Если елемент удаления найден. Возможен баг: когда два одинаковых елемента в соседних ветках дерева, удаляться оба.
                {
                    FoundItems = true;              //Меняем флаг на true
                    targetCollection.Remove(dep);                       //Удаляем найденый элемент
                    return FoundItems;                                  //Выходим с передачей что элемент найден
                }
                else
                { 
                    if(dep.Deportaments != null && dep.Deportaments.Count >= 1)       //Если есть дочернии элементы
                        if(DeportamrntActions(deportament, dep.Deportaments,action))               //Если рекурсия возвращяет true
                        { return true; }                                              //Возвращаем выше что элемент найден.
                }
            }


            return FoundItems;
        }

        //Разрешшенные действия с рекурсивным методом.
        enum Action
        {
            delete
        }

    }
}
