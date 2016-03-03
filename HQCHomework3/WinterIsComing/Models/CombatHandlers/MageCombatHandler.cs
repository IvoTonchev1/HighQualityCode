namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Spells;

    public class MageCombatHandler : ICombatHandler
    {
        private bool isBlizzardNext;

        public MageCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = candidateTargets.OrderByDescending(t => t.HealthPoints).ThenBy(t => t.Name).Take(3);

            return targets;
        }

        public ISpell GenerateAttack()
        {
            if (this.isBlizzardNext)
            {
                var blizzard = new Blizzard(this.Unit.AttackPoints * 2);

                Validator.HasEnoughEnergy(this.Unit, blizzard);

                this.isBlizzardNext = false;
                this.Unit.EnergyPoints -= blizzard.EnergyCost;

                return blizzard;
            }
            else
            {
                var fireBreath = new FireBreath(this.Unit.AttackPoints);

                Validator.HasEnoughEnergy(this.Unit, fireBreath);

                this.isBlizzardNext = true;
                this.Unit.EnergyPoints -= fireBreath.EnergyCost;

                return fireBreath;
            }
        }
    }
}
