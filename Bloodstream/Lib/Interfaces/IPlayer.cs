namespace Bloodstream.Interfaces
{
    public interface IPlayer : IUnit
    {
        bool IsAlive { get; }
        bool IsGhost { get; }
        uint Money { get; }
    }
}
