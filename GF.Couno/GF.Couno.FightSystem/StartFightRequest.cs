using MediatR;

namespace GF.Couno.FightSystem
{
    public class StartFightRequest : IRequest<FightInfoResult>
    {
        public FighterId Player { get; }

        public StartFightRequest(FighterId player)
        {
            Player = player;
        }
    }
}