using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Platform;
using Avalonia.Media.Imaging;
using System.IO;
using System.Globalization;
using System;
using Explorer.Shared.ViewModels.FileEntities;
using Avalonia.Media;
using Avalonia.Controls;
using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Avalonia.UI.ValueConverters;

public class FileEntityToImageConverters : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string str = "";

        if (value is FileEntityViewModel fileEntityViewModel) { 
            
            switch (fileEntityViewModel)
            {
                case DirectoryViewModel directoryViewModel:

                    return "/Assets/folder_icon.svg";
                    break;

                case FileViewModel fileViewModel:
                    return "/Assets/item_icon.svg";
                    break;
            }



        }


        return str;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

