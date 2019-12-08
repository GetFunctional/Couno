namespace Couno.Engine
{
    public interface ICounoFightEnvironment
    {
        Player Player { get; }

        Enemy Enemy { get; }
    }
}