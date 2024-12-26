using System.Windows;
using System.Windows.Input;

namespace DemoTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CarManager.SaveData();
        }
    }
}
