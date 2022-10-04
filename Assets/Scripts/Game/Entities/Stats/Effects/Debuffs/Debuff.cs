namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects.Debuffs {
    internal abstract class Debuff : Effect {
        private protected Debuff(bool isUnique, bool active)
                    : base(EffectType.Debuff, isUnique, active) { }
    }
}
