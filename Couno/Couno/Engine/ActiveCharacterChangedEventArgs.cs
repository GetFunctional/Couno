namespace Couno.Engine
{
    public class ActiveCharacterChangedEventArgs
    {
        public ActiveCharacterChangedEventArgs(Character newActiveCharacter, Character previousCharacter)
        {
            NewActiveCharacter = newActiveCharacter;
            PreviousCharacter = previousCharacter;
        }

        public Character NewActiveCharacter { get; }

        public Character PreviousCharacter { get;  }
    }
}