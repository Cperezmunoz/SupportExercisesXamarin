using Ej2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace XFMasterDetailPageNavigation
{
    public partial class MainPage : MasterPageItems
    {
        public List<MasterPageItems> menuList
        {
            get;
            set;
        }
        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItems>();
            // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterPageItems()
            {
                Title = "Home",
                Icon = "homeicon.png",
                TargetType = typeof(TestPage1)
            });
            menuList.Add(new MasterPageItems()
            {
                Title = "Contact",
                Icon = "contacticon.png",
                TargetType = typeof(TestPage2)
            });
            menuList.Add(new MasterPageItems()
            {
                Title = "About",
                Icon = "abouticon.png",
                TargetType = typeof(TestPage3)
            });
            menuList.Add(new MasterPageItems()
            {
                Title = "Main",
                Icon = "icon.png",
                TargetType = typeof(TestPage1)
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TestPage1)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItems)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}