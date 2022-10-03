namespace Commanders.Assets.Scripts.Game.Entities.Stats.Effects.Buffs {
    internal abstract class Buff : Effect {
        internal Buff(bool isUnique, bool active)
                   : base(EffectType.Buff, isUnique, active) { }
    }
}
