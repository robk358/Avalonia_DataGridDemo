using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace DataGridDemo.ViewModels;

public partial class DemoDataGridViewModel : ViewModelBase
{
    [ObservableObject]
    public record DemoDataGridRecord(int Id, string ProjectName, decimal UsedParts, int ProjectRuns, DateOnly LastRunDate, bool ProjectClosed, DateOnly ProjectDate);

    [ObservableProperty]
    private ObservableCollection<DemoDataGridRecord> _demoDataGridList = new ObservableCollection<DemoDataGridRecord>(); // List to hold project history records

    public DemoDataGridViewModel()
    {

    }

    [RelayCommand]
    public void PopulateDemoDataGrid()
    {
        DemoDataGridList = new ObservableCollection<DemoDataGridRecord>
            {
                new DemoDataGridRecord(1, "Project 1", 100m, 5, DateOnly.FromDateTime( DateTime.Now.AddDays(-10)), false, DateOnly.FromDateTime(DateTime.Now.AddDays(-10))),
                new DemoDataGridRecord(2, "Project 2", 200m, 3, DateOnly.FromDateTime( DateTime.Now.AddDays(-5)), true, DateOnly.FromDateTime(DateTime.Now.AddDays(-5))),
                new DemoDataGridRecord(3, "Project 3", 150m, 4, DateOnly.FromDateTime( DateTime.Now.AddDays(-2)), false, DateOnly.FromDateTime(DateTime.Now.AddDays(-2))),
                new DemoDataGridRecord(4, "Project 4", 250m, 6, DateOnly.FromDateTime( DateTime.Now.AddDays(-1)), true, DateOnly.FromDateTime(DateTime.Now.AddDays(-1))),
                new DemoDataGridRecord(5, "Project 5", 300m, 2, DateOnly.FromDateTime( DateTime.Now.AddDays(-3)), false, DateOnly.FromDateTime(DateTime.Now.AddDays(-3))),
                new DemoDataGridRecord(6, "Project 6", 400m, 8, DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), true, DateOnly.FromDateTime(DateTime.Now.AddDays(-7))),
                new DemoDataGridRecord(7, "Project 7", 500m, 1, DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), false, DateOnly.FromDateTime(DateTime.Now.AddDays(-4))),
                new DemoDataGridRecord(8, "Project 8", 600m, 9, DateOnly.FromDateTime( DateTime.Now.AddDays(-6)), true, DateOnly.FromDateTime(DateTime.Now.AddDays(-6))),
                new DemoDataGridRecord(9, "Project 9", 700m, 10, DateOnly.FromDateTime( DateTime.Now.AddDays(-8)), false, DateOnly.FromDateTime(DateTime.Now.AddDays(-8)))
            };
    }

    [RelayCommand]
    public void ClearDemoDataGrid()
    {
        DemoDataGridList.Clear();
    }
}
