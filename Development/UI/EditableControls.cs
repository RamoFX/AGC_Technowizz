using System;
using System.Windows.Forms;

using Core.UI.CustomControls;

namespace Development.UI
{
  public partial class EditableControls : Form
  {
    public EditableControls()
    {
      InitializeComponent();
    }

    EditableNode EditableNode = new EditableNode
    {
      LabelTitle = "Label Title",
      Label = "Label",
      DefaultValue = "Default Value",
      ValueValidation = text => !string.IsNullOrEmpty(text)
    };

    private void button1_Click(object sender, EventArgs e)
    {
      panel1.Add(EditableNode);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      panel1.Remove(EditableNode);
    }
  }
}
