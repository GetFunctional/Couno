namespace GF.Couno.FightSystem.Ecs
{
    internal interface IEntity
    {
        IExternalComponentRepository Components
        {
            get;
        }
    }
}