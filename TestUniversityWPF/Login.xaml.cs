using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using TestUniversityWPF.Models;

namespace TestUniversityWPF
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string hostUrl = "https://localhost:5001/api/Auth";

        bool logHasErr;
        bool passHasErr;
        AuthModel auth;
        TokenModel token;
        public string Log { get; set; }
        public string Pass { get; set; }
        public Login()
        {
            logHasErr = true;
            passHasErr = true;
            auth = new AuthModel();
            token = new TokenModel();

            InitializeComponent();
            login.IsEnabled = false;
            spiner.Visibility = Visibility.Collapsed;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                errorEmail.Text = "Empty login";
                logHasErr = true;
            }
            else if (((sender as TextBox).Text).IndexOf('@') <= 0)
            {
                errorEmail.Text = @"The email must contain '@' symbol";
                logHasErr = true;
            }
            else
            {
                logHasErr = false;
                Log = (sender as TextBox).Text;
            }

            errorEmail.Visibility = (logHasErr) ? Visibility.Visible : Visibility.Hidden;
            ButtonTrigger();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as PasswordBox).Password.Length == 0)
            {
                errorPass.Text = "Empty password";
                passHasErr = true;
            }
            else if (((sender as PasswordBox).Password).IndexOf(' ') >= 0)
            {
                errorPass.Text = @"Delete spaces from password field";
                passHasErr = true;
            }
            else if ((sender as PasswordBox).Password.Length <= 6)
            {
                errorPass.Text = "Passord must be longer than 6 simbols";
                passHasErr = true;
            }
            else
            {
                errorPass.Text = (sender as PasswordBox).Password.ToString();
                passHasErr = false;
                Pass = (sender as PasswordBox).Password;
            }

            errorPass.Visibility = (passHasErr) ? Visibility.Visible : Visibility.Hidden;
            ButtonTrigger();
        }
        void ButtonTrigger()
        {
            login.IsEnabled = (logHasErr || passHasErr) ? false : true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(hostUrl) as HttpWebRequest;
            request.ContentType = "application/json";

            request.Method = "POST"; // we have some post data, act as post request.
            
            auth.email = email.Text;
            auth.password = password.Password;

            string jsonString;
            jsonString = JsonSerializer.Serialize(auth);

            // write post data to request stream, and dispose streamwriter afterwards.
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                spiner.Visibility = Visibility.Visible;
                writer.Write(jsonString);
                writer.Close();
            }


            string responseData = string.Empty;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseData = reader.ReadToEnd();
                    reader.Close();
                }

                response.Close();
            }

            token = JsonSerializer.Deserialize<TokenModel>(responseData);
            //errorEmail.Text = responseData;
            spiner.Visibility = Visibility.Collapsed;
            errorEmail.Visibility = Visibility.Visible;
            MainWindow main = new MainWindow(token);
            main.Show();
            Close();
        }
    }
}
