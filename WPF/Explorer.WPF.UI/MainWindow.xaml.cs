using Explorer.Shared.ViewModels;
using System.Windows;

namespace Explorer.WPF.UI;

public partial class MainWindow : Window
{

    private readonly MainViewModel _mainVm;

    public MainWindow()
    {
        InitializeComponent();

        _mainVm = new MainViewModel();

        DataContext = _mainVm;
    }

    private void CloseButton_OnClick(object sender, System.Windows.RoutedEventArgs e)
    {

        _mainVm.ApplicationClising();

        Application.Current.Shutdown();
    }

    private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            this.WindowState = WindowState.Maximized;
        }
        else if (WindowState == WindowState.Maximized) {
            this.WindowState = WindowState.Normal;
        }
    }

    private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
}