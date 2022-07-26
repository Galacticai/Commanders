namespace Assets.Scripts.Lib.Math.Space2D {
    public class RectanglePoints {
        public Point o { get; }
        public Point ox { get; }
        public Point oy { get; }
        public Point oxy { get; }
        public RectanglePoints(Rectangle rectangle) {
            //? (x, y)
            this.o = new(rectangle.x, rectangle.y);
            //? (x+w, y)
            this.ox = new(rectangle.x + rectangle.xLength, rectangle.y);
            //? (x, y+h)
            this.oy = new(rectangle.x, rectangle.y + rectangle.yLength);
            //? (x+w, y+h)
            this.oxy = new(rectangle.x + rectangle.xLength, rectangle.y + rectangle.yLength);
        }
    }
}
