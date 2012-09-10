using System.Reflection;
namespace Bloodstream.Interfaces
{
    [Obfuscation]
    public interface IStuckHandler
    {
        bool Next();
        int Remaining { get; }
        int Total { get; }
    }
}