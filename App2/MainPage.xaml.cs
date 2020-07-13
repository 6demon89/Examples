using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    public class Data
    {
        public double XValue { get; set; }

        public double YValue { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Data> sampleData { get; set; } = new List<Data>();
        Random rnd = new Random();
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5000; i++)
            {
                sampleData.Add(new Data() { XValue = rnd.NextDouble(), YValue = rnd.NextDouble() });
            }
            this.scatterPointSeries.DataContext = sampleData;
        }
    }
}
