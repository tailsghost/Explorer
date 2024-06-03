using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using Explorer.Shared.ViewModels;

namespace Explorer.Avalonia.UI.Views
{
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        private MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();

            mainViewModel = new MainViewModel();

            DataContext = mainViewModel;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {

            mainViewModel.ApplicationClising();

            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime classicDesktop)
            {
                classicDesktop.Shutdown();
            }
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}