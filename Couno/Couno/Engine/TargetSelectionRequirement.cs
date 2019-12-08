namespace Couno.Engine
{
    internal enum TargetSelectionRequirement
    {
        NoTargetRequired = 0,
        EnemyTargetSelectionRequired = 1,
        FriendlyTargetSelectionRequired = 2,
        AutoSelectionPossible = 3
    }
}