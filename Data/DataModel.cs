using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace HomeWork_8.Data
{
    public class Deportament
    {
        private ObservableCollection<Staff> staffs = new ObservableCollection<Staff>();

        //public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Deportament> Deportaments { get; set; }
        //public uint CountStaff { get; set; }
        public Deportament Parent { get; set; }
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
    }

    public class Staff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public Deportament Deportament { get; set; }
        public int Id { get; set; }
        public uint salary { get; set; }
    }
}
