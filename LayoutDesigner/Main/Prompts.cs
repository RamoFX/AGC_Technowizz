using System.Collections.Generic;
using System.IO;
using System.Linq;

using Core;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    private ListSelection SelectionPrompt(IEnumerable<object> selectItems, string displayMember, string label) {
      ListSelection userSelect = new(selectItems.ToList(), displayMember, label);

      userSelect.ShowDialog(this);

      return userSelect;
    }

    private ListSelection SelectionPrompt(IEnumerable<object> selectItems, string label) {
      return SelectionPrompt(selectItems, "", label);
    }

    private TextInput TextPrompt(string initialValue) {
      Validator<string> valueValidator = name => {
        name = name.Trim();
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        bool isEmpty = name.Length == 0;
        bool newNameContainsInvalidChars = name.ToCharArray().Any(newNameChar => invalidFileNameChars.Contains(newNameChar));
        bool nameAlreadyTaken = Core.Layout.FileSystem.Exists(name);

        if (isEmpty) {
          MessageBoxes.TextValueCannotBeEmpty();
          return false;
        } else if (newNameContainsInvalidChars) {
          MessageBoxes.TextFieldCannotContainInvalidChars();
          return false;
        } else if (nameAlreadyTaken) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else
          return true;
      };

      TextInput userTextInput = new(valueValidator, "Nový název rozložení", initialValue);

      userTextInput.ShowDialog(this);

      return userTextInput;
    }



    // Base object prompt
    private ObjectEditor LayoutEditorPrompt(string title, Layout.Entity layout, IEnumerable<string> otherNames) {
      Validator<object> validator = obj => {
        Layout.Entity layout = (Layout.Entity) obj;

        layout.Name = layout.Name.Trim();

        bool isNameEmpty = layout.Name.Length == 0;
        bool doesNameContainsDot = layout.Name.Contains('.');
        bool isNameAlreadyInUse = otherNames.Contains(layout.Name);
        bool hasInvalidSize = layout.Size.Width < 1 || layout.Size.Height < 1;

        if (isNameEmpty) {
          MessageBoxes.TextValueCannotBeEmpty();
          return false;
        }

        if (doesNameContainsDot) {
          MessageBoxes.NameCantContainADot();
          return false;
        }

        if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        }

        if (hasInvalidSize) {
          MessageBoxes.InvalidSize();
          return false;
        }

        return true;
      };

      ObjectEditor layoutEditor = new(validator, layout, title);

      layoutEditor.ShowDialog(this);

      return layoutEditor;
    }

    private ObjectEditor ZoneEditorPrompt(string title, Zone.Entity zone, IEnumerable<Zone.Entity> otherZones) {
      Validator<object> validator = obj => {
        Zone.Entity newZone = (Zone.Entity) obj;

        newZone.Name = newZone.Name.Trim();
        newZone.CarBrand = newZone.CarBrand.Trim();

        bool isNameEmpty = newZone.Name.Length == 0;
        bool isNameAlreadyInUse = otherZones.Select(someZone => someZone.Name).Contains(newZone.Name);
        bool isVerticalCapacityNegative = newZone.VerticalCapacity < 0;
        bool isOutOfBounds = !CurrentLayout.Rectangle.Contains(newZone.Rectangle);
        bool doesIntersectWithOtherZone = otherZones.Any(someZone => newZone.Rectangle.IntersectsWith(someZone.Rectangle));
        bool hasInvalidSize = newZone.Size.Width < 1 || newZone.Size.Height < 1;

        bool isValidRegularZone = newZone.CarBrand.Length > 0 && newZone.VerticalCapacity > 0;
        bool isValidOtherZone = newZone.CarBrand.Length == 0 && newZone.VerticalCapacity == 0;
        bool isInvalidRegularOrOtherZone = !( isValidRegularZone || isValidOtherZone );

        if (isNameEmpty) {
          MessageBoxes.TextValueCannotBeEmpty();
          return false;
        } else if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else if (isVerticalCapacityNegative) {
          MessageBoxes.VerticalCapacityGreaterThanZero();
          return false;
        } else if (isOutOfBounds) {
          MessageBoxes.CantBeOutOfBounds();
          return false;
        } else if (doesIntersectWithOtherZone) {
          MessageBoxes.CantIntersect();
          return false;
        } else if (hasInvalidSize) {
          MessageBoxes.InvalidSize();
          return false;
        } else if (isInvalidRegularOrOtherZone) {
          MessageBoxes.InvalidRegularOrOtherZone();
          return false;
        } else
          return true;
      };

      ObjectEditor zoneEditor = new(validator, zone, title);

      zoneEditor.ShowDialog(this);

      return zoneEditor;
    }



    // Object creation
    private ObjectEditor NewLayoutPrompt() {
      return LayoutEditorPrompt(
        "Nové rozložení",
        new(),
        Core.Layout.FileSystem.GetFilesNames()
      );
    }

    private ObjectEditor NewZonePrompt(Zone.Entity initialZone) {
      return ZoneEditorPrompt(
        "Nová zóna",
        initialZone,
        CurrentLayout.Zones
      );
    }
  }
}
