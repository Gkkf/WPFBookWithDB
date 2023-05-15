using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KsiazkaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int page = 0;
        public int pageSize = 0;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            Functions.Open();
            Functions.refresh = Refresh;
            progress.Value = page+1;
            progress.Maximum = Functions.MaxPage() + 1;
        }

        public void Refresh()
        {
            searchbar.Text = "";
            page = 0;
            pageSize = Functions.MaxPage();
            progress.Value = 1;
            progress.Maximum = Functions.MaxPage() + 1;
            Load(Functions.GetPersons());
        }

        private void Load(List<Person> people)
        {
            dataGrid.ItemsSource = people;
            pageCount.Content = page+1;
        }

        //stworzenie nowej bazy
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewDBWindow newDB = new NewDBWindow();
            newDB.ShowDialog();
        }

        //dodawanie
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.toEdit = false;
            optionsWindow.ShowDialog();
        }

        //edycja
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            int i = dataGrid.SelectedIndex;
            object selectedObj = dataGrid.SelectedItem;

            if (selectedObj != null)
            {
                Person selectedPerson = (Person)dataGrid.SelectedItem;

                OptionsWindow optionsWindow = new OptionsWindow(selectedPerson.Name, selectedPerson.Surname, selectedPerson.Number, selectedPerson.Email);
                optionsWindow.toEdit = true;
                optionsWindow.person = selectedPerson;
                optionsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nie wybrano kontaktu");
            }
        }

        //usuwanie
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            int i = dataGrid.SelectedIndex;
            object selectedObj = dataGrid.SelectedItem;

            if(selectedObj != null)
            {
                Person selectedPerson = (Person)dataGrid.SelectedCells[0].Item;

                var sureTest = MessageBox.Show("Usunąć kontakt: " + selectedPerson.Name + " " + selectedPerson.Surname + "?", "", MessageBoxButton.YesNo);

                if(sureTest == MessageBoxResult.Yes)
                {
                    Functions.DeletePerson(selectedPerson);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano kontaktu");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if(page <= 0)
            {
                return;
            }

            Load(Functions.GetPersons(--page));
            progress.Value = page + 1;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if(page>=pageSize)
            {
                return;
            }

            Load(Functions.GetPersons(++page));
            progress.Value = page + 1;
        }

        private void searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            pageSize = Functions.MaxPage(searchbar.Text);
            Load(Functions.GetPersons(page = 0, searchbar.Text));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            pageSize = Functions.MaxPage(searchbar.Text);
            Load(Functions.GetPersons(page = 0, searchbar.Text));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            pageSize = Functions.MaxPage();
            Load(Functions.GetPersons());
        }
    }
}
