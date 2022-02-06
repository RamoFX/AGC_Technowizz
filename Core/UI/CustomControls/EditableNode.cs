using System.ComponentModel;
using System.Windows.Forms;

namespace Core.UI.CustomControls
{
  public partial class EditableNode : UserControl
  {
    [Description("Label Title"), Category("Data")]
    public string LabelTitle
    {
      get => labelTitle.Text;
      set => labelTitle.Text = value;
    }

    [Description("Label"), Category("Data")]
    public string Label
    {
      get => label.Text;
      set => label.Text = value;
    }

    [Description("Value"), Category("Data")]
    public string Value
    {
      get => valueTextBox.Text;
      set => valueTextBox.Text = value;
    }
    public EditableNode()
    {
      InitializeComponent();
    }
  }

  public static class EditableNodeExtensions
  {
    public static void Add(this Panel panel, EditableNode node)
    {
      node.Location = new System.Drawing.Point(
        node.Location.X,
        (panel.Controls.Count) * node.Height
      );
      panel.Controls.Add(node);
    }
    public static void Remove(this Panel panel, EditableNode node)
    {
      panel.Controls.Remove(node);
    }
  }
}
