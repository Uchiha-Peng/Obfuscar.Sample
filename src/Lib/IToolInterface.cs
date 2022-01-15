namespace Lib
{
    public interface IToolInterface
    {
        IEnumerable<int> RundomArray();

        Task DoTask(CancellationToken cancellationToken, int ms);
    }
}
