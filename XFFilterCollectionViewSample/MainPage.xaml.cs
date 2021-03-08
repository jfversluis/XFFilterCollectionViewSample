using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFilterCollectionViewSample
{
    public partial class MainPage : ContentPage
    {
        private readonly string[] sourceItems = new[] { "Subscribe", "YouTube Channel", "Monkeys", "Gerald", "Subscribed yet?" };

        public ObservableCollection<string> MyItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            MyItems = new ObservableCollection<string>(sourceItems);

            BindingContext = this;
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }

            searchTerm = searchTerm.ToLowerInvariant();

            var filteredItems = sourceItems.Where(value => value.ToLowerInvariant().Contains(searchTerm)).ToList();

            foreach (var value in sourceItems)
            {
                if (!filteredItems.Contains(value))
                {
                    MyItems.Remove(value);
                }
                else if (!MyItems.Contains(value))
                {
                    MyItems.Add(value);
                }
            }
        }
    }
}
