
using DuplexClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace DuplexClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DuplexCalculator12Client server;
        public LoginWindow()
        {
            InitializeComponent();
            server = new DuplexCalculator12Client();
        }

        private void userNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            userNameBox.Text = "";
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            if (userNameBox.Text != "" && !userNameBox.Text.Contains("20 characters max") && passwordBox.Password != null)
            {
                try
                {
                    string answer = server.newUser(userNameBox.Text, passwordBox.Password);
                    
                    if(answer != "")
                    {
                        MessageBox.Show(answer, "Something Happen...", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                catch (Exception ex) { MessageBox.Show("Error signing up.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }

            else { MessageBox.Show("Enter valid credentials and try again.", "Credentials error", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }

        public void CallBackClosed(string str)
        {
            //
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            if (userNameBox.Text != "" && !userNameBox.Text.Contains("20 characters max") && passwordBox.Password != null)
            {
                try
                {
                    string answer = server.Login(userNameBox.Text, passwordBox.Password);

                    if (answer != "")
                    {
                        MessageBox.Show(answer, "Something Happen...", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        MainWindow mainwindow = new MainWindow();
                        mainwindow.Show();
                        this.Close();
                    }
                }

                catch (Exception ex) { MessageBox.Show("Error signing in.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
