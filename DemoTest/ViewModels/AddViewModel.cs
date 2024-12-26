namespace DemoTest
{
    internal class AddViewModel
    {
        public AddViewModel()
        {
            Car = new Car();
            AddCommand = new RelayCommand(AddCar, CanAddCar);
        }

        public Car Car { get; private set; }
        public RelayCommand AddCommand { get; private set; }

        private void AddCar(object obj)
        {
            CarManager.Add(Car);
        }

        private bool CanAddCar(object arg)
        {
            return !Car.HasErrors;
        }
    }
}
