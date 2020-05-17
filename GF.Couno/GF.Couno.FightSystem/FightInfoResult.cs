namespace GF.Couno.FightSystem
{
    public class FightInfoResult
    {
        public FightInfoResult(FightId fightId, FighterInfo playerFighterInfo, FighterInfo enemyFighterInfo)
        {
            FightId = fightId;
            PlayerFighterInfo = playerFighterInfo;
            EnemyFighterInfo = enemyFighterInfo;
        }

        public FightId FightId { get; }

        public FighterInfo PlayerFighterInfo { get; set; }

        public FighterInfo EnemyFighterInfo { get; set; }
    }
}