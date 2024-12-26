using System.Windows;

namespace DemoTest
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
