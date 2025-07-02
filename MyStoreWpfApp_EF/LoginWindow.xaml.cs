using MyStoreWpfApp_EF.Models;
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

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }
        private void ChangeBackground()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Gold, 0.25));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.5));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Gold, 0.75));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

            btnCancel.Background = gradientBrush;

            RadialGradientBrush radialBrush = new RadialGradientBrush();
            radialBrush.GradientOrigin = new Point(0.5, 0.75);
            radialBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            radialBrush.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));
            btnLogin.Background = radialBrush;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();
            AccountMember accountMember = context.AccountMembers
                .FirstOrDefault(m => m.EmailAddress == email && m.MemberPassword == password);
            if (accountMember == null)
            {
                MessageBox.Show("Invalid email or password."
                    , "Login Failed"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }
            else
            {
                if(accountMember.MemberRole==1)
                {
                    MessageBox.Show($"Welcome {accountMember.FullName}!"
                        , "Login Admin Successful"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Information);
                    AdminWindow aw= new AdminWindow();
                    aw.Show();
                    Close();
                }
                else if (accountMember.MemberRole == 2)
                {
                    MessageBox.Show($"Welcome {accountMember.FullName}!"
                        , "Login Staff Successful"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Information);
                }
                else if (accountMember.MemberRole == 3)
                {
                    MessageBox.Show($"Welcome {accountMember.FullName}!"
                        , "Login Customer Successful"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Information);
                }
            }
        }
    }
}
