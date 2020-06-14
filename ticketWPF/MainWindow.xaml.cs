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
using System.Drawing;

namespace ticketWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        TicketsEntities entity = new TicketsEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void goPrint(string FIO, string Place, string Country)
        {
            System.Drawing.Image image = Bitmap.FromFile("tiket.jpg");

            Graphics graphicsImage = Graphics.FromImage(image);

            StringFormat Name = new StringFormat();
            Name.Alignment = StringAlignment.Far;

            StringFormat Time = new StringFormat();
            Time.Alignment = StringAlignment.Far;

            System.Drawing.Color TextColor = ColorTranslator.FromHtml("#000000");

            FIO = FIOTextBox.Text;
            Place = PlaceTextBox.Text;
            Country = CountryTextBox.Text;

            graphicsImage.DrawString(FIO, new Font(, ), System.Drawing.Brushes.Black, new System.Drawing.Point(100, 50)));
        }

        private void BuyClick(object sender, RoutedEventArgs e)
        {
            var FIO = entity.Info.Where(c => c.FIO == FIOTextBox.Text).SingleOrDefault();
            var Place = entity.Info.Where(c => c.Place == PlaceTextBox.Text).SingleOrDefault();
            var Country = entity.Info.Where(c => c.Country == CountryTextBox.Text).SingleOrDefault();
            if (FIO != null || Place != null)
            {
                MessageBox.Show("Место занято или билет с ФИО уже зарегестрирован");
            }
            else
            {
                entity.Info.Add(new Info
                {
                    FIO = FIOTextBox.Text,
                    Place = PlaceTextBox.Text,
                    Country = CountryTextBox.Text
                });
                entity.SaveChanges();
                goPrint(FIOTextBox.Text, PlaceTextBox.Text, CountryTextBox.Text);
            }
        }
    }
}
