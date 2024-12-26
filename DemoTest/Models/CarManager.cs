using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace DemoTest
{
    internal class CarManager
    {
        const string DataFileName = "cars.json";
        public static ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();

        static CarManager()
        {
            LoadData();
        }

        public static void Add(Car car)
        {
            Cars.Add(car);
        }
        public static void Remove(Car car)
        {
            Cars.Remove(car);
        }

        public static void LoadData()
        {
            using (FileStream fs = new FileStream(DataFileName, FileMode.Open))
            {
                List<Car> r = JsonSerializer.Deserialize<List<Car>>(fs);
                Cars = new ObservableCollection<Car>(r);
            }
        }

        public static void SaveData()
        {
            using (FileStream fs = new FileStream(DataFileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, Cars);
            }
        }
    }
}
