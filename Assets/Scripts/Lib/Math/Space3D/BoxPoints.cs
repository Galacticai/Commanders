namespace Assets.Scripts.Lib.Math.Space3D {
    public class BoxPoints {
        public Point o { get; }
        public Point ox { get; }
        public Point oy { get; }
        public Point oz { get; }
        public Point oxy { get; }
        public Point oxz { get; }
        public Point oyz { get; }
        public Point oxyz { get; }
        public BoxPoints(Box box) {
            //? (x, y, z)
            this.o = new(box.x, box.y, box.z);
            //? (x+w, y, z)
            this.ox = new(box.x + box.xLength, box.y, box.z);
            //? (x, y+h, z)
            this.oy = new(box.x, box.y + box.yLength, box.z);
            //? (x, y, z+d)
            this.oz = new(box.x, box.y, box.z + box.zLength);
            //? (x+w, y+h, z)
            this.oxy = new(box.x + box.xLength, box.y + box.yLength, box.z);
            //? (x+w, y, z+d)
            this.oxz = new(box.x + box.xLength, box.y, box.z + box.zLength);
            //? (x, y+h, z+d)
            this.oyz = new(box.x, box.y + box.yLength, box.z + box.zLength);
            //? (x+w, y+h, z+d)
            this.oxyz = new(box.x + box.xLength, box.y + box.yLength, box.z + box.zLength);
        }
    }
}
