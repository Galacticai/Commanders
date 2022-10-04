namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects.Buffs {
    internal abstract class Buff : Effect {
        private protected Buff(bool isUnique, bool active)
                   : base(EffectType.Buff, isUnique, active) { }
    }
}
