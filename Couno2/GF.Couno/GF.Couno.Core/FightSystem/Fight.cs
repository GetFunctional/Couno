namespace GF.Couno.Core.FightSystem
{
    public class Fight
    {
        public Fight( IFightParticipant player, IFightParticipant enemy)
        {
            this.Enemy = enemy;
            this.Player = player;
            this.TurnNumber = 1;
        }

        public int TurnNumber { get; }

        public IFightParticipant Player { get; }

        public IFightParticipant Enemy { get; }
    }
}