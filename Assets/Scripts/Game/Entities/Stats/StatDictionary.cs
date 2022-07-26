﻿using System.Collections.Generic;
using static Assets.Scripts.Game.Entities.Stats.Stat;

namespace Assets.Scripts.Game.Entities.Stats {
    /// <summary> <see cref="Stat"/> dictionary with <see cref="Stat.statName"/> as key </summary>
    internal class StatDictionary : Dictionary<StatName, Stat> {

        //!? ==== HIDDEN ==========
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        internal void Add(StatName statName, Stat stat)
            => base.Add(statName, stat);
        internal bool TryAdd(StatName statName, Stat stat)
            => base.TryAdd(statName, stat);
        internal void Add(Stat stat)
            => this.Add(stat.statName, stat);
        internal bool TryAdd(Stat stat)
            => this.TryAdd(stat.statName, stat);
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        //!? ======================

        internal StatDictionary(params Stat[] stats) : base() {
            foreach (var stat in stats) this.Add(stat);
        }
        internal StatDictionary() : base() { }
    }
}
