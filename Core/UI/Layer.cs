using System.Drawing;
using System.Linq;



namespace Core.UI {
  public class Layer {
    public Point Location { get; }

    public Size Size { get; }

    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    public Bitmap Bitmap { get; set; }



    public Layer(Point location, Size size) {
      this.Location = location;
      this.Size = size;
      this.Bitmap = new(size.Width, size.Height);
    }

    public Layer(Rectangle rectangle) : this(rectangle.Location, rectangle.Size) { }

    public Layer(Layer from) : this(from.Rectangle) { }
  }
}
