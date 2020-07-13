using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelerikWpfApp1.Converters
{
    public class RangeToColorConverter : MarkupExtension, IValueConverter
    {
        private static RangeToColorConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
            {
                _converter = new RangeToColorConverter();
            }
            return _converter;
        }
        public object Convert(
            object value, 
            Type targetType, 
            object parameter,
            CultureInfo culture)
        {
            if (value is null) return Brushes.Violet;
            string inputText = value.ToString();
            if (string.IsNullOrEmpty(inputText)) return Brushes.Black;
            switch(inputText)
            {
                case "1": return Brushes.Red;
                case "2": return Brushes.Green;
            }
            return Brushes.GhostWhite;
        }


        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

namespace TelerikWpfApp1.ViewModels
{
    public class ViewModelExample
    {
        CollectionViewSource source = new CollectionViewSource();
        List<string> values = new List<string>();

        public ICollectionView Data { get => source.View; }

        public ViewModelExample()
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                values.Add(rnd.Next(100,999).ToString());
            }
            var items = new ObservableCollection<string>(values);
            source.Source = items;
            source.Filter += Source_Filter;
        }

        private void Source_Filter(object sender, FilterEventArgs e)
        {
            if (Filter is null)
            {
                e.Accepted = true;
                return;
            }
            if (e.Item.ToString().ToUpper().Contains(Filter))
                e.Accepted = true;
            else
                e.Accepted = false;

        }

        private string filter;

        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.filter = value;
                OnFilterChanged();
            }
        }

        private void OnFilterChanged()
        {
            source.View.Refresh();
        }
    }
}

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
