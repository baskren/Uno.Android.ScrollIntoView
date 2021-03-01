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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace x1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var items = new List<string> { "1 one", "2 two", "3 three", "4 four", "5 five", "6 six", "7 seven", "8 eight", "9 nine", "10 ten", "11 eleven", "12 twelve", "13 thirteen", "14 fourteen", "15 fifteen", "16 sixteen", "17 seventeen", "18 eighteen", "19 nineteen", "20 twenty", "21 twenty one", "22 twenty two", "23 twenty three", "24 twenty four", "25 twenty five", "26 twenty six" };
            _listView.ItemsSource = items;

            _listView.ItemClick += OnItemClicked;
        }

        int _countDown = 0;
        async void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            if (_countDown > 0)
                return;

            _countDown = 10;
            _countDownLabel.Text = _countDown.ToString();
            _listView.Footer = new Windows.UI.Xaml.Shapes.Rectangle { Height = 1000 };
            await System.Threading.Tasks.Task.Delay(200);
            _listView.ScrollIntoView(e.ClickedItem, ScrollIntoViewAlignment.Leading);
            Timer.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _countDown--;
                _countDownLabel.Text = _countDown.ToString();
                if (_countDown > 0)
                    return true;
                _listView.Footer = null;
                return false;
            });
        }


    }
}
