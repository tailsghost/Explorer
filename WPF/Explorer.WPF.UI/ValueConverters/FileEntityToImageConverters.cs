using Explorer.Shared.ViewModels.FileEntities;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Explorer.WPF.UI.ValueConverters;

public class FileEntityToImageConverters : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var dravingImage = new DrawingImage();

        if (value is DirectoryViewModel directoryVm)
        {
            var resourse = Application.Current.TryFindResource("FolderIconImage");

            if (resourse is ImageSource directoryImageSource)
                return directoryImageSource;
        }
        else if (value is FileViewModel fileVm)
        {
            var resourse = Application.Current.TryFindResource("FileIconImage");

            if (resourse is ImageSource fileImageSource)
                return fileImageSource;
        }

        return dravingImage;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

