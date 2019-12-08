namespace Couno.Engine
{
    public sealed class Ability
    {
        public Ability(string name, AbilityType abilityType, int amount)
        {
            this.Name = name;
            this.AbilityType = abilityType;
            this.Amount = amount;
        }

        public int Amount { get; }

        public string Name { get; }

        public AbilityType AbilityType { get; }

        public override string ToString()
        {
            return $"{Name} > {this.AbilityType} > ({this.Amount})";
        }
    }
}