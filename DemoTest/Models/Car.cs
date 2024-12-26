using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DemoTest
{
    public class Car : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errors.Count > 0;

        string _model = "Модель";

        [Required]
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
                Validate(nameof(Model), value);
            }
        }

        string _company;

        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        int _price;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Цена не может быть отрицательной!")]
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
                Validate(nameof(Price), value);
            }
        }

        private int _year = 2024;

        [Required]
        [Range(1885, 2100)]
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
                Validate(nameof(Year), value);
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        public void Validate(string propertyName, object propertyValue)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(propertyValue, new ValidationContext(this) { MemberName = propertyName }, results);

            if (results.Any())
            {
                if (_errors.ContainsKey(propertyName)) return;
                _errors.Add(propertyName, results.Select(x => x.ErrorMessage).ToList());
            }
            else
            {
                if (!_errors.Remove(propertyName)) return;
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
