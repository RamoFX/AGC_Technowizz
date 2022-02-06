using System.Drawing;



namespace Core.Storage {
  public interface IVisualizable {
    public Point Location { get; set; }

    public Size Size { get; set; }

    public Rectangle Rectangle { get; }

    public Color Color { get; }
  }
}
