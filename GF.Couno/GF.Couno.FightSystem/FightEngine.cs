using MediatR;

namespace GF.Couno.FightSystem
{
    public class FightEngine
    {
        internal FightEngine(IMediator mediator)
        {
            FightMediator = new FightMediator(mediator);
        }

        public FightMediator FightMediator { get; }

        /// <summary>
        ///     Restoring a previous state before start.
        /// </summary>
        /// <returns></returns>
        public static FightEngine CreateFightRuntime()
        {
            return new FightEngineFactory().CreateFightEngine();
        }
    }
}