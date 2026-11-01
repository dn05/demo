using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using AvaloniaPostgresApp.Models;

namespace AvaloniaPostgresApp;

public partial class CatalogWindow : Window
{
    private List<Product> _allProducts = new();

    public CatalogWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        using var context = new DemoContext();

        _allProducts = context.Products
            .Include(p => p.ProductName)
            .Include(p => p.Manufacturer)
            .Include(p => p.Supplier)
            .ToList();

        ProductList.ItemsSource = _allProducts;
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        var text = SearchBox.Text?.ToLower() ?? "";
        
        if (string.IsNullOrWhiteSpace(text))
        {
            ProductList.ItemsSource = _allProducts;
            return;
        }

        var filtered = _allProducts.Where(p => 
            (p.ProductName?.ProductName1 != null && p.ProductName.ProductName1.ToLower().Contains(text)) ||
            (p.Article != null && p.Article.ToLower().Contains(text))
        ).ToList();

        ProductList.ItemsSource = filtered;
    }

    private void OnSortChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SortCombo.SelectedIndex == 0)
        {
            ProductList.ItemsSource = _allProducts.OrderBy(p => p.Price).ToList();
        }
        else if (SortCombo.SelectedIndex == 1)
        {
            ProductList.ItemsSource = _allProducts.OrderByDescending(p => p.Price).ToList();
        }
    }
}