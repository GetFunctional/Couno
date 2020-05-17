using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GF.Couno.FightSystem
{
    internal class StartFightRequestHandler : IRequestHandler<StartFightRequest, FightInfoResult>
    {
        public Task<FightInfoResult> Handle(StartFightRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FightInfoResult(new FightId(), new FighterInfo(request.Player, 30, 0),
                new FighterInfo(new FighterId(), 40, 0)));
        }
    }
}