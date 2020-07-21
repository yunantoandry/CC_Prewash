namespace Common.Services.System.Dto
{
    /// <summary>
    /// States that a class has the properties stating where XMLs are to be
    /// saved in the local server.
    /// </summary>
    public interface IHasFoldersToStoreXmlLocally
    {
        string FolderForPoLockXmls { get; }
        string FolderForDistributorOrderXmls { get; }
        string FolderForAsnXmls { get; }
    }
}
