using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestUniversityWPF.Models;

namespace TestUniversityWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string hostUrl = "https://localhost:5001/api/api/Teachers/GetTeacherById";
        TokenModel tokenModel;
        UserInfoModel userInfo;
        static HttpClient client = new HttpClient();
        public MainWindow(TokenModel token)
        {
            tokenModel = token;
            InitializeComponent();
           
        }

        private async Task GetUserInfo()
        {
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            

            string jsonString;
            jsonString = JsonSerializer.Serialize("Bearer " + tokenModel.token);

            // write post data to request stream, and dispose streamwriter afterwards.
          


            string responseData = string.Empty;

           

            userInfo = new UserInfoModel();
            userInfo = JsonSerializer.Deserialize<UserInfoModel>(responseData);
            //errorEmail.Text = responseData;
            userName.Text = userInfo.FirstName + " " + userInfo.Surname;
           
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetUserInfo();
        }
    }
}
