using System.Collections.ObjectModel;
using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;

namespace Explorer.Shared.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    #region Public Properties

    public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new();

    public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

    #endregion

    #region Commands

    public DelegateCommand AddTabItemCommand {  get; }

    #endregion

    #region Constructor
    public MainViewModel()
    {

        AddTabItemCommand = new DelegateCommand(OnAddTabItem);

        AddTabItemViewModel();
        AddTabItemViewModel();
    }

    #endregion

    #region Commands Method

    private void OnAddTabItem(object obj)
    {
        AddTabItemViewModel();
    }

    #endregion

    #region Private Methods

    private void AddTabItemViewModel()
    {
        var vm = new DirectoryTabItemViewModel();

        vm.Closed += Vm_Closed;

        DirectoryTabItems.Add(vm);

        CurrentDirectoryTabItem = vm;
    }

    private void Vm_Closed(object sender, EventArgs e)
    {
        if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            CloseTab(directoryTabItemViewModel);
        }
    }

    private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
    {
        directoryTabItemViewModel.Closed -= Vm_Closed;

        DirectoryTabItems.Remove(directoryTabItemViewModel);

        CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
    }
    #endregion
}

