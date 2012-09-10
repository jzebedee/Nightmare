namespace Bloodstream.Interfaces
{
    public interface IGameObject : IWowObject
    {
        bool CanInteract { get; }
        bool ContainsLoot { get; }
        Bloodstream.Interfaces.IUnit Creator { get; }
        ulong CreatorGUID { get; }
        Bloodstream.Lib.Faction Faction { get; }
        Bloodstream.Patchables.GameObjectFlags Flags { get; }
        Bloodstream.Patchables.WoWGameObjectType GameObjectType { get; }
        bool Harvestable { get; }
        bool HasRequiredSkillLevel { get; }
        bool IsBobbing { get; }
        bool IsHerb { get; }
        bool IsMineral { get; }
        uint Level { get; }
        int RequiredSkillLevel { get; }
    }
}
