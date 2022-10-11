using Commanders.Assets.Scripts.Lib.Math.Numerics;
using System;
using System.Threading;

namespace Commanders.Assets.Scripts.Game.Entities.Attributes {
    internal class Health : Attribute {
        #region Shortcuts

        /// <summary> Maximum value for <see cref="Amount"/> </summary>
        internal double Total => Amount.Range.Max;
        internal bool IsImmortal => Math.Abs(Defence - 1) < 0.000001f;
        /// <summary> <see cref="Amount"/> &lt; <see cref="Total"/> </summary>
        internal bool IsDamaged => Amount < Total;
        /// <summary> <see cref="Amount"/> == <see cref="Total"/> </summary>
        internal bool IsHealed => Amount == Total;
        /// <summary> Ratio of <see cref="Amount"/> relative to <see cref="Total"/> (0~1) </summary>
        internal double Health_Ratio => Amount / Total;
        /// <summary> Precentage of <see cref="Amount"/> relative to <see cref="Total"/> (0~100) </summary>
        internal double Health_Percent => Health_Ratio * 100;

        #endregion
        #region Methods
        private Amount _Health_Delta(double delta) {
            if (IsImmortal || delta == 0) return Amount;

            double health_new = Amount + delta;

            //! Never let health be negative or above total
            // to avoid any unexpected behavior
            if (health_new > Total) Restore();
            else if (health_new <= 0) Kill();

            Amount.Value += delta;
            return Amount;
        }


        /// <summary> Increase <see cref="Amount"/> directly using the <paramref name="amount"/> specified </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount Heal(double amount)
            => _Health_Delta(amount.Positive());

        /// <summary> Decrease <see cref="Amount"/> directly using the <paramref name="amount"/> specified </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount Hurt(double amount, double piercing = 0) {
            //? piercing 0�1
            double piercing01 = piercing.AtOrBetween(0, 1);
            //? pierced defence
            double piercedDefence = (Defence - piercing01).Positive();
            //? Calculate how much of the hurting amount has been defended
            double amountDefended = amount * piercedDefence;
            //? Reduce the original hurting amount using the amount that has been defended
            double amountFinal = amount - amountDefended;
            return _Health_Delta(amountFinal);
        }

        /// <summary> Decrease <see cref="Amount"/> using the <see cref="Damage"/> specified </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount HurtBy(Damage damage)
            => Hurt(damage.Amount, damage.Piercing);
        /// <summary> Decrease <see cref="Amount"/> using the <see cref="Weapon"/> specified </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount HurtBy(Weapon weapon)
            => HurtBy(weapon.Damage);

        /// <summary> Decrease <see cref="Amount"/> using <see cref="Entity"/>.damage (if present) </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount HurtBy(Entity entity) {
            var weapon = entity.Stats.Get<Weapon>();
            if (weapon != null) HurtBy(weapon);
            return Amount;
        }

        /// <summary> Set <see cref="Amount"/> to the the maximum <see cref="Total"/> </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount Restore() {
            Amount.Value = Total;
            return Amount;
        }

        /// <summary> Set <see cref="Amount"/> to 0 </summary>
        /// <returns> Final <see cref="Amount"/> </returns>
        internal Amount Kill() {
            Amount.Value = 0;
            return Amount;
        }
        internal void MakeImmortal()
            => Defence = 1;
        internal void MakeImmortal_Period(int timeMS) {
            double currentDefence = Defence;
            _ = new Timer(
                (object originalDefence)
                    => Defence = Convert.ToSingle(originalDefence),
                currentDefence,
                Timeout.Infinite,
                timeMS);
        }

        #endregion


        private Amount _Amount;
        internal Amount Amount {
            get => _Amount;
            set {
                if (value.Range.Min < 0)
                    _Amount = new(value.Value, new(0, value.Range.Max));
                else _Amount = value;
            }
        }

        private double _Defence;
        internal double Defence {
            get => _Defence;
            set => _Defence = value.AtOrBetween(0, 1);
        }

        internal Health(Entity parent_Entity, Amount amount, double defence = 0)
                    : base(parent_Entity) {
            Amount = amount;
            Defence = defence;
        }

        internal static Health Immortal(Entity parent_Entity)
            => new(parent_Entity, new Amount(1), defence: 1);
    }
}
