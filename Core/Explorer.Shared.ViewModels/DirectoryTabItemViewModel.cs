﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Explorer.Shared.ViewModels.Commands;
using Explorer.Shared.ViewModels.Core;
using Explorer.Shared.ViewModels.FileEntities;
using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Shared.ViewModels;

public class DirectoryTabItemViewModel : BaseViewModel
{
    #region Public Properties
    public string MainDiskName { get; set; }

    public string FilePath { get; set; }

    public string Name { get; set; }

    public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = new();

    public FileEntityViewModel SelectedFileEntity { get; set; }

    #endregion

    #region Commands
    public ICommand OpenCommand { get; }

    public ICommand CloseCommand { get; }
    #endregion

    #region Events

    public event EventHandler Closed;

    #endregion

    #region Constructor
    public DirectoryTabItemViewModel()
    {
        Name = "Мой компьютер";

        OpenCommand = new DelegateCommand(Open);
        CloseCommand = new DelegateCommand(OnClose);

        foreach (var logicalDrive in Directory.GetLogicalDrives())
        {
            DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
        }
    }
    #endregion

    #region Commands Method

    private void Open(object parameter)
    {
        if (parameter is DirectoryViewModel directoryViewModel)
        {
            FilePath = directoryViewModel.FullName;

            Name = directoryViewModel.Name;

            DirectoriesAndFiles.Clear();

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
    }

    private void OnClose(object obj)
    {
        Closed?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
