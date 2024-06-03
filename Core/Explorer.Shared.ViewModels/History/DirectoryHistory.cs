using System.Collections;

namespace Explorer.Shared.ViewModels.History;

internal class DirectoryHistory : IDirectoryHistory
{

    #region Private Fields 

    private DirectoryNode _head;

    #endregion

    #region Property

    public bool CanMoveBack => Current.PreviousNode != null;

    public bool CanMoveForward => Current.NextNode != null;

    public DirectoryNode Current { get; private set; }

    #endregion

    #region Events

    public event EventHandler HistoryChanged;

    #endregion


    #region Public Methods
    public void MoveBack()
    {

        var prev = Current.PreviousNode;

        Current = prev;

        RaiseHistoryChanged();
    }

    public void MoveForward()
    {

        var next = Current.NextNode;

        Current = next;

        RaiseHistoryChanged();
    }

    public void Add(string filePath, string name)
    {

        var node = new DirectoryNode(filePath, name);

        Current.NextNode = node;

        node.PreviousNode = Current;

        Current = node;

        RaiseHistoryChanged();
    }
    #endregion


    #region Constructor
    public DirectoryHistory(string DirectoryPath, string DirectoryPathName)
    {
        _head = new DirectoryNode(DirectoryPath, DirectoryPathName);

        Current = _head;
    }
    #endregion


    #region Enumerator

    IEnumerator<DirectoryNode> IEnumerable<DirectoryNode>.GetEnumerator()
    {
        yield return Current;
    }

    public IEnumerator GetEnumerator() => GetEnumerator();

    #endregion


    #region Private Methods

    private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);

    #endregion
}