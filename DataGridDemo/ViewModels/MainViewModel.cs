using CommunityToolkit.Mvvm.ComponentModel;

namespace DataGridDemo.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private DemoDataGridViewModel _dataGridVM;
    [ObservableProperty] private DemoTreeDataGridViewModel _treeDataGridVM;

    public MainViewModel(DemoDataGridViewModel dataGridVM, DemoTreeDataGridViewModel treeDataGridVM)
    {
        DataGridVM = dataGridVM;
        TreeDataGridVM = treeDataGridVM;
    }
}

