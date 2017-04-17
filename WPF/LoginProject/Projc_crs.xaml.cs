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
using LoginProject.Models;

namespace LoginProject
{
    /// <summary>
    /// Interaction logic for Projc_crs.xaml
    /// </summary>
    public partial class Projc_crs : Window
    {
        public Projc_crs()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getstudentdetail(txt.Text);
            getdata(txt.Text);
            getoffercourse(txt.Text);
        }

                private void getdata(string id)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:2665/");
                    // Add an Accept header for JSON format.  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // List all Names.  
                    HttpResponseMessage response = client.GetAsync("api/regcrs_list/" + id).Result;  // Blocking call!  
                    if (response.IsSuccessStatusCode)
                    {
                        var products = response.Content.ReadAsStringAsync().Result;

                        List<Student_courses> crs = JsonConvert.DeserializeObject<List<Student_courses>>(products);
                        Total_cources.Text = crs.Count().ToString();
                
                        lvUsers.ItemsSource = crs;
                       }
                }
        private void getstudentdetail(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2665/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync("api/Student_detail/" + id).Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsStringAsync().Result;

                Studentdetail stu_detail = JsonConvert.DeserializeObject<Studentdetail>(products);
                Student_name.Text = stu_detail.student_name;
                Student_Departmnt.Text = stu_detail.student_departmnt;
                Student_program.Text = stu_detail.student_program;   
            }
        }

        private void getoffercourse(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2665/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync("api/offercourse/" + id).Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsStringAsync().Result;

                List<Student_courses> crs = JsonConvert.DeserializeObject<List<Student_courses>>(products);
                Total_cources.Text = crs.Count().ToString();

                offerd.ItemsSource = crs;
            }
        }



    }
}
