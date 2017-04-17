using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
using System.Net.Http;
using Newtonsoft.Json;


namespace LoginProject
{
    /// <summary>
    /// Interaction logic for coures_registration.xaml
    /// </summary>
    public partial class coures_registration : Page
    {

        public coures_registration()
        {
            InitializeComponent();
        }
        


        private void getdata(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2848/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync("api/student/" + id).Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsStringAsync().Result;

                List<registerd_crs_Table> crs = JsonConvert.DeserializeObject<List<registerd_crs_Table>>(products);

                lvUsers.ItemsSource = crs;
                //MessageBox.Show(crs[1].offer_crs_id.ToString()  ,crs[2].status.ToString()
                //);
             foreach (var item in crs)
                {
                    firstcours.Text=item.studentsTable.std_name;
                    secondcours.Text = item.offerd_courseTable.CourcesTable.crs_name;
                    thrdcours.Text = item.status;
                    frthcours.Text = crs.Count().ToString();
                }

            }
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getdata(txt.Text.Trim());
        }
    }
}
