namespace Explorer.Shared.ViewModels.History;

internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
{
    bool CanMoveBack { get; }
    bool CanMoveForward { get; }

    event EventHandler HistoryChanged;

    DirectoryNode Current {  get; }

    void MoveBack();

    void MoveForward();

    void Add(string filePath, string name);
}

internal class DirectoryNode
{

    public DirectoryNode PreviousNode { get; set; }

    public DirectoryNode NextNode { get; set; }

    public string DerictoryPath { get; }
    public string? DerictoryPathName { get; }

    public DirectoryNode(string directoryPath, string directoryPathName)
    {
        DerictoryPath = directoryPath;
        DerictoryPathName = directoryPathName;
    }
}
