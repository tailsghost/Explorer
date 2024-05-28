using Explorer.Shared.ViewModels.FileEntities.Base;

namespace Explorer.Shared.ViewModels.FileEntities;

public sealed class DirectoryViewModel : FileEntityViewModel
{

    public DirectoryViewModel(string DirectoryName) : base(DirectoryName)
    {
        FullName = DirectoryName;
    }

    public DirectoryViewModel(DirectoryInfo directory) : base(directory.Name)
    {
        FullName = directory.FullName;
    }
}
