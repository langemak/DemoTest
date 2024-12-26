using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; }
        public RelayCommand ShowAddWindowCommand { get; set; }

        private RelayCommand _removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                  (_removeCommand = new RelayCommand(obj =>
                  {
                      if (obj is Car Car)
                      {
                          CarManager.Remove(Car);
                      }
                  },
                  (obj) => SelectedCar != null));
            }
        }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Cars = CarManager.Cars;
            ShowAddWindowCommand = new RelayCommand(ShowAddWindow);
        }

        private void ShowAddWindow(object obj)
        {
            AddWindow addWindow = new AddWindow
            {
                Owner = (MainWindow)obj,
                DataContext = new AddViewModel()
            };
            addWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
