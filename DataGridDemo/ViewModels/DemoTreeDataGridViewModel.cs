using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGridDemo.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace DataGridDemo.ViewModels;
public partial class DemoTreeDataGridViewModel : ViewModelBase
{
    public record DemoTreeDataGridRecord(int Id, string OrderNumber, decimal Quantity, decimal Price, string Sku, DateOnly OrderDate, string DistributorName);

    [ObservableProperty]
    private ObservableCollection<DemoTreeDataGridRecord> _demoTreeDataGridList = new ObservableCollection<DemoTreeDataGridRecord>(); // List to hold order history records
    public FlatTreeDataGridSource<DemoTreeDataGridRecord> DemoTreeDataGridSource { get; set; }

    public DemoTreeDataGridViewModel()
    {
        InitTreeDataGridSources();
    }

    void InitTreeDataGridSources()
    {
        DemoTreeDataGridSource = new FlatTreeDataGridSource<DemoTreeDataGridRecord>(DemoTreeDataGridList)
        {
            Columns =
            {
                new TextColumn<DemoTreeDataGridRecord, int>("Id", x => x.Id),
                new TextColumn<DemoTreeDataGridRecord, string>("Order #", x => x.OrderNumber),
                new TextColumn<DemoTreeDataGridRecord, decimal>("Quantity", x => x.Quantity,options: new()
                        {
                            TextAlignment = Avalonia.Media.TextAlignment.Right,
                            StringFormat="{0:N2}"
                        }),
                new TextColumn<DemoTreeDataGridRecord, decimal>("Price", x => x.Price, options: new()
                        {
                            TextAlignment = Avalonia.Media.TextAlignment.Right,
                            StringFormat="{0:N2}"
                        }),
                new TextColumn<DemoTreeDataGridRecord, string>("SKU", x => x.Sku),
                new TextColumn<DemoTreeDataGridRecord, DateOnly>("Date", x => x.OrderDate),
                new TextColumn<DemoTreeDataGridRecord, string>("Distributor", x => x.DistributorName, new GridLength(1, GridUnitType.Star), new()
                        {
                            IsTextSearchEnabled = true
                        }),
            },

        };

        DemoTreeDataGridSource.RowSelection!.SelectionChanged += RowSelection_SelectionChanged;

    }

    private void RowSelection_SelectionChanged(object? sender, Avalonia.Controls.Selection.TreeSelectionModelSelectionChangedEventArgs<DemoTreeDataGridRecord> e)
    {
        if (sender == null)
            return;

        if (DemoTreeDataGridSource.RowSelection!.Count == 0) // na reload is count 0..
            return;

        var a = DemoTreeDataGridSource.RowSelection.SelectedItem!.Id;

        Console.WriteLine(a.ToString());
    }

    [RelayCommand]
    public void PopulateDemoTreeDataGrid()
    {
        DemoTreeDataGridList = new ObservableCollection<DemoTreeDataGridRecord>
        {
            new DemoTreeDataGridRecord(1, "Order 1", 100m, 100.00m, "SKU001", DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), "Distributor A"),
            new DemoTreeDataGridRecord(2, "Order 2", 2m, 200.00m, "SKU002", DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), "Distributor B"),
            new DemoTreeDataGridRecord(3, "Order 3", 30m, 150.00m, "SKU003", DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), "Distributor C"),
            new DemoTreeDataGridRecord(4, "Order 4", 40m, 250.00m, "SKU004", DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), "Distributor D"),
            new DemoTreeDataGridRecord(5, "Order 5", 5m, 300.00m, "SKU005", DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), "Distributor A"),
            new DemoTreeDataGridRecord(6, "Order 6", 66m, 400.00m, "SKU006", DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), "Distributor B"),
            new DemoTreeDataGridRecord(7, "Order 7", 7m, 500.00m, "SKU007", DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), "Distributor C"),
            new DemoTreeDataGridRecord(8, "Order 8", 8m,600.00m, "SKU008", DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), "Distributor D"),
            new DemoTreeDataGridRecord(9, "Order 9", 99, 700.00m, "SKU009", DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), "Distributor A")
        };

        DemoTreeDataGridSource.Items = DemoTreeDataGridList;
    }

    [RelayCommand]
    public void ClearDemoTreeDataGrid()
    {
        DemoTreeDataGridList.Clear();

    }
}
