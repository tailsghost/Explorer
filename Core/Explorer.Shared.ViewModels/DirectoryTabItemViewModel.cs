using System.Collections.ObjectModel;
using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using Explorer.Shared.ViewModels.FileEntities;
using Explorer.Shared.ViewModels.FileEntities.Base;
using Explorer.Shared.ViewModels.History;

namespace Explorer.Shared.ViewModels;

public class DirectoryTabItemViewModel : BaseViewModel
{

    #region Private Fields
    private IDirectoryHistory _history;
    #endregion



    #region Public Properties
    public string MainDiskName { get; set; }

    public string FilePath { get; set; }

    public string Name { get; set; }

    public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new();

    public FileEntityViewModel SelectedFileEntity { get; set; }

    #endregion

    #region Commands
    public DelegateCommand OpenCommand { get; }

    public DelegateCommand MoveBackCommand { get; }

    public DelegateCommand MoveForwardCommand { get; }

    #endregion


    #region Constructor
    public DirectoryTabItemViewModel()
    {

        _history = new DirectoryHistory("Мой компьютер", "Мой компьютер");


        OpenCommand = new DelegateCommand(Open);

        MoveBackCommand = new DelegateCommand(OnMoveBack, OnCanMoveBack);

        MoveForwardCommand = new DelegateCommand(OnMoveForward, OnCanMoveForward);

        Name = _history.Current.DerictoryPathName;

        FilePath = _history.Current.DerictoryPath;

        OpenDirectory();

        _history.HistoryChanged += _history_HistoryChanged;

    }
    #endregion

    #region Commands Method

    private void Open(object parameter)
    {
        if (parameter is DirectoryViewModel directoryViewModel)
        {
            FilePath = directoryViewModel.FullName;

            Name = directoryViewModel.Name;

            _history.Add(FilePath, Name);

            OpenDirectory();
        }
    }

    private void OnMoveBack(object obj)
    {
        _history.MoveBack();

        var current = _history.Current;

        FilePath = current.DerictoryPath;

        Name = current.DerictoryPathName;

        OpenDirectory();
    }

    private bool OnCanMoveBack(object obj) => _history.CanMoveBack;

    private void OnMoveForward(object obj)
    {
        _history.MoveForward();

        var current = _history.Current;

        FilePath = current.DerictoryPath;

        Name = current.DerictoryPathName;

        OpenDirectory();
    }

    private bool OnCanMoveForward(object obj) => _history.CanMoveForward;

    #endregion

    #region Private Methods

    private void OpenDirectory()
    {

        DirectoriesAndFiles.Clear();

        if (Name == "Мой компьютер")
        {
            foreach (var logicalDrive in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
            
            return;
        }

        var directoryInfo = new DirectoryInfo(FilePath);

        foreach (var directory in directoryInfo.GetDirectories())
        {
            DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
        }

        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            DirectoriesAndFiles.Add(new FileViewModel(fileInfo));
        }
    }

    private void _history_HistoryChanged(object? sender, EventArgs e)
    {
        MoveBackCommand?.RaiseCanExecuteChanged();
        MoveForwardCommand?.RaiseCanExecuteChanged();
    }

    #endregion
}
