using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        

        public bool a = false;
        

        private Partner _currentPartner=new Partner();
        public AddEditPage(Partner SelectedService)
        {
            InitializeComponent();
            //if (SelectedService != null)
            //{
            //    a = true;
            //    _currentPartner = SelectedService;
            //}
            var PartnerTypes = Semenova_МастерПолEntities.GetContext().Partner_Type.Select(p => p.Type_name).ToList();

            foreach (var PartnerType in PartnerTypes)
            {
                PartnerTypeComboBox.Items.Add(PartnerType);
            }

            if (SelectedService != null)
            {
                a = true;
                _currentPartner = SelectedService;
                PartnerTypeComboBox.SelectedIndex = _currentPartner.Partner_Type - 1;
            }
            else
            {
                _currentPartner.Rating = 0;
                PartnerTypeComboBox.SelectedIndex = 0;
            }
            DataContext = _currentPartner;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPartner.Partner_Name))
                errors.AppendLine("Укажите название партнера");
            if (_currentPartner.Rating < 0)
                errors.AppendLine("Неверный рейтинг партнера");
            if (string.IsNullOrWhiteSpace(_currentPartner.Address))
                errors.AppendLine("Укажите адрес партнера");
            if (string.IsNullOrWhiteSpace(_currentPartner.Phone)) // Проверка на 11 цифр
            {
                errors.AppendLine("Укажите номер телефона");
            }
            if (string.IsNullOrWhiteSpace(_currentPartner.Surname_Director))
                errors.AppendLine("Укажите фамилию директора");
            if (string.IsNullOrWhiteSpace(_currentPartner.Name_Director))
                errors.AppendLine("Укажите имя директора");
            if (string.IsNullOrWhiteSpace(_currentPartner.Patronymic_Director))
                errors.AppendLine("Укажите отчество директора");
            if (string.IsNullOrWhiteSpace(_currentPartner.Email))
                errors.AppendLine("Укажите Email");
            if (string.IsNullOrWhiteSpace(_currentPartner.INN) || !Regex.IsMatch(_currentPartner.INN, @"^\d{10}$")) // Проверка на 11 цифр
            {
                errors.AppendLine("Укажите ИНН, состоящий из 10 цифр");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var allServices = Semenova_МастерПолEntities.GetContext().Partner.ToList();
            _currentPartner.Partner_Type = PartnerTypeComboBox.SelectedIndex + 1;

            var allPartner = Semenova_МастерПолEntities.GetContext().Partner.ToList();
            allPartner = allPartner.Where(p => p.Partner_Name == _currentPartner.Partner_Name).ToList();
            if (allPartner.Count == 0 || a == true)
            {
                if (_currentPartner.Partner_ID == 0)
                {
                    Semenova_МастерПолEntities.GetContext().Partner.Add(_currentPartner);
                }

                try
                {
                    Semenova_МастерПолEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Такой партнер уже сущевстует!");

        }
    }
}
