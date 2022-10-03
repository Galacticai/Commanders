﻿/// —————————————————————————————————————————————
//? 
//!? 📜 BoxPoints.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: 
//      + (Galacticai) Math/Space3D/Box.cs
//? 
/// —————————————————————————————————————————————


namespace Commanders.Assets.Scripts.Lib.Math.Space3D {
    public class BoxPoints {
        public Point O { get; }
        public Point OX { get; }
        public Point OY { get; }
        public Point OZ { get; }
        public Point OXY { get; }
        public Point OXZ { get; }
        public Point OYZ { get; }
        public Point OXYZ { get; }
        public BoxPoints(Box box) {
            //? (x, y, z)
            O = new(box.X, box.Y, box.Z);
            //? (x+w, y, z)
            OX = new(box.X + box.XLength, box.Y, box.Z);
            //? (x, y+h, z)
            OY = new(box.X, box.Y + box.YLength, box.Z);
            //? (x, y, z+d)
            OZ = new(box.X, box.Y, box.Z + box.ZLength);
            //? (x+w, y+h, z)
            OXY = new(box.X + box.XLength, box.Y + box.YLength, box.Z);
            //? (x+w, y, z+d)
            OXZ = new(box.X + box.XLength, box.Y, box.Z + box.ZLength);
            //? (x, y+h, z+d)
            OYZ = new(box.X, box.Y + box.YLength, box.Z + box.ZLength);
            //? (x+w, y+h, z+d)
            OXYZ = new(box.X + box.XLength, box.Y + box.YLength, box.Z + box.ZLength);
        }
    }
}
