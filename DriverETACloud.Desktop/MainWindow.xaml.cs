using DriverETACloud.Desktop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Xml.Serialization;

namespace DriverETACloud.Desktop
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Driver driver = new Driver
            {
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                DOB = Convert.ToDateTime(txtDOB.Text),
                IsActive = chkActive.IsChecked
            };
            SaveDriverDetails(driver);
        }

        private async void SaveDriverDetails(Driver driver)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:60251/DriverEtaService.svc/AddDriver");
                request.Content = new StringContent(serialize<Driver>(driver), Encoding.UTF8, "application/Json");
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    lblMessage.Content = response.StatusCode.ToString();

            }
        }

        private string serialize<T>(T type)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, type);
                return Encoding.Default.GetString(stream.ToArray());
            }           
        }

        private IList<T> Deserialize<T>(string  content)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IList<T> temp = serializer.Deserialize<T[]>(content);
            return temp;
        }

        private string Xmlserialize(Driver driver)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(Driver));
                serializer.Serialize(stream, driver);
                return Encoding.Default.GetString(stream.ToArray());
            }


        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:60251/DriverEtaService.svc/Driver");
                response.EnsureSuccessStatusCode();
                IList<Driver> drivers= Deserialize<Driver>(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                    this.dtGrid.ItemsSource = drivers;

            }
        }
    }
}
