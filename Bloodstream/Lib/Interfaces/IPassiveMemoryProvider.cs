namespace Bloodstream.Interfaces
{
    public interface IPassiveMemoryProvider
    {
        T Read<T>(params uint[] Addresses);
        byte[] ReadBytes(uint Address, int Count);
        TDest[] ConvertArray<TDest>(uint Address, int Count) where TDest : struct;
    }
}