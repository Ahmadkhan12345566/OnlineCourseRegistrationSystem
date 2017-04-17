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
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LoginProject
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            getdata(2);
            //deleteDataToApi(2);
            // SendDataToApi(pr);
        }

        private async void SendDataToApi(studentdata per)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13713/");
                string endPoint = "api/person";

                string json = JsonConvert.SerializeObject(per);

                var data = new StringContent(content: json,
                                             encoding: Encoding.UTF8,
                                             mediaType: "application/json");

                var res = await client.PostAsync(endPoint, data);
                MessageBox.Show("Data Inserted");
            }
        }






        private void deleteDataToApi(int id)
        {
            id = 2;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13713/");
                var response = client.DeleteAsync("api/person/2").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
            }
        }

/*        private void putdata()
        {
            using (var client = new HttpClient())
            {
           //     Person p = new Person { person_name = "Sourav",  = "Kayal" };
                client.BaseAddress = new Uri("http://localhost:1565/");
                var response = client.PutAsJsonAsync("api/person", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
            }

  */      private void getdata(int id)
        {
             HttpClient client = new HttpClient();  
            client.BaseAddress = new Uri("http://localhost:13713/");   
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));   
            // List all Names.  
            HttpResponseMessage response = client.GetAsync("api/person/4").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)  
            {  
                var products = response.Content.ReadAsStringAsync().Result;

                studentdata crs = JsonConvert.DeserializeObject<studentdata>(products);


                MessageBox.Show(crs.Id.ToString() );
            } 
        }

    }
}
