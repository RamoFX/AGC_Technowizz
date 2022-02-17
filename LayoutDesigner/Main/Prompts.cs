using System;
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

    private TextInput TextPrompt() {
      Func<string, bool> valueValidator = newName => {
        newName = newName.Trim();
        char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        bool isEmpty = newName.Length == 0;
        bool newNameContainsInvalidChars = newName.ToCharArray().Any(newNameChar => invalidFileNameChars.Contains(newNameChar));
        bool nameAlreadyTaken = Core.Layout.FileSystem.Exists(newName);

        if (isEmpty) {
          MessageBoxes.NameCannotBeEmpty();
          return false;
        } else if (newNameContainsInvalidChars) {
          MessageBoxes.TextFieldCannotContainInvalidChars();
          return false;
        } else if (nameAlreadyTaken) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        } else {
          return true;
        }
      };

      TextInput userTextInput = new(valueValidator, "Nový název rozložení");

      userTextInput.ShowDialog(this);

      return userTextInput;
    }



    // Base object prompt
    private ObjectEditor LayoutEditorPrompt(string title, Layout.Entity layout, IEnumerable<string> otherNames) {
      Func<object, bool> validator = obj => {
        Layout.Entity layout = (Layout.Entity) obj;

        layout.Name = layout.Name.Trim();

        bool isNameEmpty = layout.Name.Length == 0;
        bool isNameAlreadyInUse = otherNames.Contains(layout.Name);
        bool hasInvalidSize = layout.Size.Width < 1 || layout.Size.Height < 1;

        if (isNameEmpty) {
          MessageBoxes.NameCannotBeEmpty();
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
      Func<object, bool> validator = obj => {
        Zone.Entity zone = (Zone.Entity) obj;

        zone.Name = zone.Name.Trim();

        bool isNameEmpty = zone.Name.Length == 0;
        bool isNameAlreadyInUse = otherZones.Any(currentZone => currentZone.Name == zone.Name);
        bool isVerticalCapacityNegative = zone.VerticalCapacity < 0;
        bool isOutOfBounds = !this.CurrentLayout.Rectangle.Contains(zone.Rectangle);
        bool doesIntersectWithOtherZone = otherZones.Any(someZone => zone.Rectangle.IntersectsWith(someZone.Rectangle));
        bool hasInvalidSize = zone.Size.Width < 1 || zone.Size.Height < 1;

        if (isNameEmpty) {
          MessageBoxes.NameCannotBeEmpty();
          return false;
        }

        if (isNameAlreadyInUse) {
          MessageBoxes.NameAlreadyInUse();
          return false;
        }

        if (isVerticalCapacityNegative) {
          MessageBoxes.VerticalCapacityGreaterThanZero();
          return false;
        }

        if (isOutOfBounds) {
          MessageBoxes.CantBeOutOfBounds();
          return false;
        }

        if (doesIntersectWithOtherZone) {
          MessageBoxes.CantIntersect();
          return false;
        }

        if (hasInvalidSize) {
          MessageBoxes.InvalidSize();
          return false;
        }

        return true;
      };

      ObjectEditor zoneEditor = new(validator, zone, title);

      zoneEditor.ShowDialog(this);

      return zoneEditor;
    }



    // Object creation
    private ObjectEditor NewLayoutPrompt() {
      return this.LayoutEditorPrompt(
        "Nové rozložení",
        new(),
        Core.Layout.FileSystem.GetFilesNames()
      );
    }

    private ObjectEditor NewZonePrompt() {
      return this.ZoneEditorPrompt(
        "Nová zóna",
        new(),
        this.CurrentLayout.Zones
      );
    }
  }
}
