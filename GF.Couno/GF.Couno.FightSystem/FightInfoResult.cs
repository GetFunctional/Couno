using GF.Couno.FightSystem.Entities;

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

        public FighterInfo PlayerFighterInfo { get; }

        public FighterInfo EnemyFighterInfo { get; }
        public FighterId CurrentTurnFighterId { get; }
    }
}