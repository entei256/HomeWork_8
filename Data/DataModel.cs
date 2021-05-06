using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace HomeWork_8.Data
{
    /// <summary>
    /// Структура данных для депортаментов
    /// </summary>
    public class Deportament
    {
        private ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();          //Пиватное поле для свойства Staffs

        public DateTime CreatedDate { get; set; }               //Дата создавния депорртамента
        public string Name { get; set; }                   //Название депортамента
        public ObservableCollection<Deportament> Deportaments { get; set; }             //Список дочерних депортаментов
        public ObservableCollection<Staff> Staffs         //Список сотрудников в  депортаменте.
        {
            get{ return staffs; }
            set 
            {
                if (value.Count >= 1_000_000)
                    MessageBox.Show("Количество сотрудников превыщает максимум.");
                else
                    staffs = value;
            }
        }

        public Deportament()
        {
            this.CreatedDate = DateTime.Now;            //При создании депортамента указываем ему текущую дату.
        }
    }

    /// <summary>
    /// Модель данных для сотррудников
    /// </summary>
    public class Staff
    {
        private static uint _id = 0;                  //Внутрений счетчик ID
        public string FirstName { get; set; }            //Имя
        public string LastName { get; set; }          //Фамилия
        public int Age { get; set; }                 //Возраст
        public uint Id { get; set; }                //Индентификатор пользователя.
        public uint Salary { get; set; }           //Зарплата

        

        public Staff()
        {
            _id++;      //При  каждом создании нового сотрудника  увеличиваем общий счетчик ID
            Id = _id;           //Присваиваем увеличиный ID  новому пользователю.
        }
    }
}
