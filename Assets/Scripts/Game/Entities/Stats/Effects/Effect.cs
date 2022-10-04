
using Commanders.Assets.Scripts.Lib.Math.Numerics;

namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects {
    internal abstract class Effect {


        internal enum EffectType {
            Buff, Debuff
        }

        // /// <summary> Safely update <see cref="Effect"/> without breaking the functionality of <see cref="Active"/> flag </summary>
        //internal protected Func<Entity, Entity> UpdateEffect(Func<Entity, Entity> newEffect)
        //   => this.Effect = new((Entity entity) => {
        //       //? Redo the effect according to EntityEffect.Count
        //       for (int i = 0; i < this.Count; i++)
        //           newEntity = newEffect(entity);
        //       return newEntity;
        //   });


        internal bool Active => Count > 0;

        internal EffectType Type { get; }

        /// <summary> The function that will modify the <see cref="Stat"/> </summary>
        internal abstract dynamic Get<IStat>(IStat stat) where IStat : Stat;

        private int _Count = 0;
        /// <summary> Multiplier for <see cref="Effect"/> </summary>
        internal int Count {
            get => _Count;
            set {
                _Count = IsUnique ? value.AtOrBetween(0, 1) : value.Positive();
            }
        }
        internal bool IsUnique { get; }

        internal Effect(EffectType type, bool isUnique, bool active) {
            Type = type;
            IsUnique = isUnique;
            if (active) Count++;
        }
    }
}