namespace GF.Couno.FightSystem
{
    public class FighterInfo
    {
        public FighterInfo(FighterId fighterId, int health, int shield)
        {
            FighterId = fighterId;
            Health = health;
            Shield = shield;
        }

        public FighterId FighterId { get; set; }

        public int Health { get; set; }

        public int Shield { get; set; }
    }
}