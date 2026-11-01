using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using AvaloniaPostgresApp.Models;

namespace AvaloniaPostgresApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnLoginTextChanged(object? sender, TextChangedEventArgs e) { MessageText.Text = ""; }
    private void OnPasswordTextChanged(object? sender, TextChangedEventArgs e) { MessageText.Text = ""; }

    private void OnLoginClick(object? sender, RoutedEventArgs e)
    {
        MessageText.Text = ""; 

        var login = LoginBox.Text;
        var password = PasswordBox.Text;

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            MessageText.Text = "Заполните все поля!";
            MessageText.Foreground = Brushes.Red;
            return;
        }

        try
        {
            using var context = new DemoContext();
            var user = context.Users.FirstOrDefault(u => u.Login == login);

            if (user == null)
            {
                MessageText.Text = "Пользователь не найден в базе";
                MessageText.Foreground = Brushes.Red;
                return;
            }

            if (user.Password != password)
            {
                MessageText.Text = "Неверный пароль";
                MessageText.Foreground = Brushes.Red;
                return;
            }

            // УСПЕХ! Открываем каталог
            MessageText.Text = $"УСПЕХ! {user.FullName}";
            MessageText.Foreground = Brushes.Green;

            var catalog = new CatalogWindow();
            catalog.Show();
            this.Close(); 
        }
        catch (Exception ex)
        {
            MessageText.Text = $"ОШИБКА БД: {ex.Message}";
            MessageText.Foreground = Brushes.Red;
        }
    }

    private void OnGuestClick(object? sender, RoutedEventArgs e)
    {
        // Вход без пароля
        var catalog = new CatalogWindow();
        catalog.Show();
        this.Close();
    }
}