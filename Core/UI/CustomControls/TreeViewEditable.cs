using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Core.UI.CustomControls
{
  public partial class TreeViewEditable : UserControl
  {
    public IEnumerable<EditableNode> EditableNodes { get; private set; }

    public TreeViewEditable()
    {
      InitializeComponent();
      this.Controls.AddRange((Control[])this.EditableNodes);
    }

    public void Add(EditableNode item)
    {
      EditableNodes.Append(item);
    }

    public void Insert(EditableNode item, int index)
    {
      this.EditableNodes = this.EditableNodes
                            .Take(index)
                            .Append(item)
                            .Concat(this.EditableNodes.Skip(index));
    }

    public void Remove(EditableNode item)
    {
      this.EditableNodes = this.EditableNodes.SkipWhile(editableNode => editableNode == item);
    }

    public void RemoveAt(int index)
    {
      this.EditableNodes = this.EditableNodes.SkipWhile(node => this.EditableNodes.ElementAt(index) == node);
    }
  }
}
