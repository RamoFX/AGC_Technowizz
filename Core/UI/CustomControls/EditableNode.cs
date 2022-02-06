using System.ComponentModel;
using System.Windows.Forms;
using System;

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
      if (!panel.Controls.Contains(node))
      {
        node.Location = new System.Drawing.Point(
          node.Location.X,
          (panel.Controls.Count) * node.Height
        );
        panel.Controls.Add(node);
      }
    }
    public static bool Remove(this Panel panel, EditableNode node)
    {
      if (panel.Controls.Contains(node)) { 
        panel.Controls.Remove(node); 
        return true; 
      } return false;
    }
  }
}
