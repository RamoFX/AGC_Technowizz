using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

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
      private set => valueTextBox.Text = value;
    }

    [Description("Default Value"), Category("Data")]
    public string DefaultValue
    {
      get => valueTextBox.Text;
      set => valueTextBox.Text = value;
    }

    [Description("Validation function"), Category("Data")]
    public Func<string, bool> ValueValidation { get; set; }

    public EditableNode()
    {
      InitializeComponent();
    }

    private void Submit(object sender, EventArgs e)
    {
      if (ValueValidation(valueTextBox.Text))
        Value = valueTextBox.Text;
      else
        Value = DefaultValue;
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

    public static IEnumerable<EditableNode> GetAllEditableNodes(this Panel panel)
    {
      foreach (Control control in panel.Controls)
      {
        if (control is EditableNode) yield return (EditableNode)control;
      }
    }
  }
}
