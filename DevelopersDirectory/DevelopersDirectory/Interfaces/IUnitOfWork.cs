namespace DevelopersDirectory.Interfaces
{
    public interface IUnitOfWork
    {
        IDevelopersRepository DevelopersRepository { get; set; }
    }
}