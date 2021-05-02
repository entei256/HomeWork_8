using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Serialization;
using Microsoft.Win32;
using Newtonsoft.Json;


namespace HomeWork_8
{
    class FileHelper
    {

        /// <summary>
        /// Сохранение данных в файл.
        /// </summary>
        /// <param name="DepCollection">Передать колекцию  депортаментов</param>
        /// <param name="typeSerialization">Указать тип данных в файле. XML или JSON</param>
        public static void SaveFile
            (ObservableCollection<Data.Deportament> DepCollection ,FileTypeSerialization typeSerialization)
        {
            var SavePath = new SaveFileDialog(); //Создаем экемплляр диалога сохранения.

            // Еслли отменили сохранение то просто выходим из метода.
            if (SavePath.ShowDialog() != true)   
            {
                return;
            }

            /*//Проверяем существует файл или нет
            if(!File.Exists(SavePath.FileName))
            { 
                File.Create(SavePath.FileName); } //Если не существует то создаем.*/

            //Если выбран тип JSON
            if (typeSerialization == FileTypeSerialization.Json)   
            { 
                var JSONData = JsonConvert.SerializeObject(DepCollection);    //Конвертируем в JSON
                File.WriteAllText(SavePath.FileName, JSONData);   //Записываем в файл JSON строку.
            }
            //Если выборан тип XML
            else if (typeSerialization == FileTypeSerialization.Xml)  
            {
                var Serialization = new XmlSerializer(typeof(ObservableCollection<Data.Deportament>));
                FileStream fs = new FileStream(SavePath.FileName, FileMode.OpenOrCreate, FileAccess.Write);

                Serialization.Serialize(fs, DepCollection);

                fs.Close(); //Закорываем поток.
                fs.Dispose(); //Очищаем поток.
            } 
            //В остальных случаях.
            else
            {
                MessageBox.Show("Не указан тип данных в файле.");
                return;
            }
        }

        /// <summary>
        /// Метод чтения из файла
        /// </summary>
        /// <param name="typeSerialization">Указать тип данных в файле. XML или JSON</param>
        /// <returns>Возвращает колекцию депортаментов.</returns>
        public static ObservableCollection<Data.Deportament> LoadFile(FileTypeSerialization typeSerialization)
        {
            ObservableCollection<Data.Deportament> resoult  = new ObservableCollection<Data.Deportament>();
            var OpenPath = new OpenFileDialog();

            if (OpenPath.ShowDialog() == true)  //Проверяем что файл выбрали.
            {
                if (typeSerialization == FileTypeSerialization.Json)   //Если выбран тип JSON
                {
                    var Deserealization = new JsonSerializer();
                    var FileText = File.ReadAllText(OpenPath.FileName);
                    try
                    {
                        resoult = JsonConvert.DeserializeObject<ObservableCollection<Data.Deportament>>(FileText);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка сериализзации. Проверьте что выбрали нужный файл JSON.");
                    }
                }
                else if (typeSerialization == FileTypeSerialization.Xml)  //Если выборан тип XML
                {
                    var Deserealization = new XmlSerializer(typeof(ObservableCollection<Data.Deportament>));
                    FileStream fs = new FileStream(OpenPath.FileName, FileMode.Open, FileAccess.Read);
                    try
                    {
                        resoult = Deserealization.Deserialize(fs) as ObservableCollection<Data.Deportament>;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка сериализзации. Проверььте что выбрали нужный файл XML");
                    }
                }
                else
                {
                    MessageBox.Show("Не указан тип данных в файле.");
                }
            }

            return resoult;
        }
    }

    /// <summary>
    /// Перечисление типов данных.
    /// </summary>
    public enum FileTypeSerialization
    {
        Json = 0,
        Xml = 1
    }
}
