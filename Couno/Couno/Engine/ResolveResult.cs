namespace Couno.Engine
{
    internal class ResolveResult
    {
        public ResolveResult(string logMessage)
        {
            this.LogMessage = logMessage;
        }

        public string LogMessage { get; }
    }
}