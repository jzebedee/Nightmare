namespace Bloodstream.Interfaces
{
    public interface IMemoryProvider : IPassiveMemoryProvider
    {
        bool Write<T>(uint Address, T Value);
        uint Allocate(int Size);
        bool Free(uint Address);
    }
}