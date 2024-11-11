using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semenova_MasterPol
{
    /// <summary>
    /// Логика взаимодействия для PartnerPage.xaml
    /// </summary>
    public partial class PartnerPage : Page
    {
        public bool a = false;
        public PartnerPage()
        {
            InitializeComponent();
            var currentServices = Semenova_МастерПолEntities.GetContext().Partner.ToList();
            ServiceListView.ItemsSource = currentServices;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            a = false;
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void ServiceListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            a = true;
            if (ServiceListView.SelectedItem is Partner selectedPartner)
            {
                Manager.MainFrame.Navigate(new AddEditPage(selectedPartner));
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (Visibility == Visibility.Visible)
            {
                Semenova_МастерПолEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ServiceListView.ItemsSource = Semenova_МастерПолEntities.GetContext().Partner.ToList();
            }

        }
    }
}
