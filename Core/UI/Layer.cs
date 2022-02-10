using System.Drawing;


namespace Core.UI {
  public class Layer {
    public Bitmap Bitmap { get; set; }

    public Point Location { get; }

    public Size Size { get; }

    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }



    public Layer(Bitmap bitmap, Point location, Size size) {
      this.Bitmap = bitmap;
      this.Location = location;
      this.Size = size;
    }

    public Layer(Bitmap bitmap, Rectangle rectangle) : this(bitmap, rectangle.Location, rectangle.Size) { }
  }
}
