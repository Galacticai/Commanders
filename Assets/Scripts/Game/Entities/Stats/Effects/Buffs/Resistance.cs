//using Assets.Scripts.Game.Entities.Stats;

//namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects.Buffs {
//    /// <summary> Resist <see cref="Assets.Scripts.Game.Entities.Stats.Damage"/> </summary>
//    internal class Resistance : Buff {
//        internal struct Modified {
//            internal class Health : Stats.Health {
//                internal float Resistance_Ratio { get; set; }
//                internal override float Hurt(float amount) {
//                    amount *= this.Resistance_Ratio;
//                    return base.Hurt(amount);
//                }
//                internal Health(Stats.Health original, float resistance_Ratio)
//                            : base(original.Total) {
//                    this.Resistance_Ratio = resistance_Ratio;
//                }
//            }
//        }
//        internal override void Apply() {

//        }
//        internal override void Remove() {

//        }
//        protected override Entity _Effect() {
//            if (base.TargetEntity.Stats.Contains<Health>()) {
//                Health originalHealth = base.TargetEntity.Stats.TryGetValue<Health>();
//                Modified.Health modifiedHealth = new(originalHealth, this.Ratio);
//                base.TargetEntity.Stats.Add(modifiedHealth);
//            }
//            return this.TargetEntity;
//        }

//        internal float Ratio { get; set; }
//        /// <summary> Resist a part of the <see cref="Damage"/> received </summary>
//        internal Resistance(float ratio, bool active = true)
//                            : base(active) {
//            this.Ratio = ratio;
//        }
//    }
//}
