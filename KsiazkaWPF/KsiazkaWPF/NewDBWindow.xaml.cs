using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KsiazkaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy NewDBWindow.xaml
    /// </summary>
    public partial class NewDBWindow : Window
    {
        public NewDBWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Regex.IsMatch(dbName.Text, "[a-zA-Z]+"))
            {
                Functions.AddTable(dbName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędna nazwa");
                dbName.BorderBrush = Brushes.HotPink;
            }
        }

        private void dbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbName.BorderBrush = Brushes.Gray;
        }
    }
}
