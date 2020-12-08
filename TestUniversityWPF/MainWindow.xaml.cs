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
using System.Threading;

namespace TestUniversityWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string hostUrl = "https://localhost:5001/";
        TokenModel tokenModel;
        
        static HttpClient client = new HttpClient();
        public MainWindow(TokenModel token)
        {
            tokenModel = token;
            InitializeComponent();
        }

        private async Task<UserInfoModel> GetUserInfo()
        {
            client.BaseAddress = new Uri(hostUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.token);

            UserInfoModel userInfo = new UserInfoModel();
            var response = await client.GetAsync("api/Teachers/GetTeacherById").ConfigureAwait(false);
            // Verification  
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                userInfo = JsonSerializer.Deserialize<UserInfoModel>(res);
                return userInfo;
            }
            return userInfo;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = await GetUserInfo();

            userName.Text = user.firstName + " " + user.surname;

        }
    }
}
