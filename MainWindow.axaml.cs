using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Microsoft.EntityFrameworkCore;
using skiing.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace skiing
{
    public partial class MainWindow : Window
    {
        public List<User> users;
        public DispatcherTimer block;

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        public MainWindow(bool block)
        {
            InitializeComponent();
            if (block)
            {
                logBtn.IsEnabled = false;
                
            }
            else
            {
                logBtn.IsEnabled = true;
            }
            LoadUsers();
        }

        public void LoadUsers()
        {
            users = Helper.Database.Users
                .Include(x => x.IdClientsNavigation)
                .Include(x => x.IdPositionNavigation)
                .Include(x => x.LoginHistories)
                .OrderBy(x => x.IdUser)
                .ToList();
        }

        public void StartBlock()
        {
            block = new DispatcherTimer() { Interval = new System.TimeSpan(0, 3, 0)};
            block.Tick += TimerTick;
            block.Start();
        }


        public void TimerTick(object? sender, EventArgs e)
        {
            logBtn.IsEnabled = true;
            block.Stop();
        }

        public void ShowPassword(object? sender, RoutedEventArgs e)
        {
            if (passwordBox.PasswordChar == 'Х')
            {
                passwordBox.PasswordChar = '\0';
            }
            else
            {
                passwordBox.PasswordChar = 'Х';
            }
        }

        public void LoginButton(object? sender, RoutedEventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordBox.Text;

            User userFounder = null;

            foreach (User user in users)
            {
                if (user.UserLogin == login)
                {
                    userFounder = user;
                    break;
                }
            }

            if (userFounder == null)
            {
                errorText.Text = "пользователь не найден";
                return;
            }

            if (userFounder.UserPassword == password)
            {
                LoginHistory loginHistory = new LoginHistory() { LoginDate = DateTime.Now, Validation = true };
                userFounder.LoginHistories.Add(loginHistory);

                Helper.Database.SaveChanges();

                
                Authorisation loginWindow = new Authorisation();
                loginWindow.Show();
                Close();

            }
            else
            {
                LoginHistory loginHistory = new LoginHistory() { LoginDate = DateTime.Now, Validation = false };
                userFounder.LoginHistories.Add(loginHistory);
                Helper.Database.SaveChanges();
                errorText.Text = "неверный пароль";
            }
        }

     

    }
}