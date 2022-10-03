namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects.Debuffs {
    internal abstract class Debuff : Effect {
        public Debuff(bool isUnique, bool active)
                    : base(EffectType.Debuff, isUnique, active) { }
    }
}
