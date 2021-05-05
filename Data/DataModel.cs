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
        private ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();

        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Deportament> Deportaments { get; set; }
        public ObservableCollection<Staff> Staffs 
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
            this.CreatedDate = DateTime.Now;
            this.Staffs = new ObservableCollection<Staff>();
        }
    }

    /// <summary>
    /// Модель данных для сотррудников
    /// </summary>
    public class Staff
    {
        private static uint id = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Deportament Deportament { get; set; }
        public uint Id 
        { 
            get
            { return id; }
            private set
            { id = value; } 
        }
        public uint Salary { get; set; }

        public Staff(Deportament Deportament)
        {
            Id++;
            this.Deportament = Deportament;
        }
    }
}
