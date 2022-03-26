using System.Collections.Generic;
using System.Linq;
using Core.UI.Dialogs;



namespace ZoneAssigner {
  public partial class Main {
    private ListSelection SelectionPrompt(IEnumerable<object> selectItems, string displayMember, string label) {
      ListSelection userSelect = new(selectItems.ToList(), displayMember, label);

      userSelect.ShowDialog(this);

      return userSelect;
    }

    private ListSelection SelectionPrompt(IEnumerable<object> selectItems, string label) {
      return SelectionPrompt(selectItems, "", label);
    }
  }
}
