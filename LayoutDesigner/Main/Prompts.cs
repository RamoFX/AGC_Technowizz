using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Core;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    private ListSelection GetSelect(IEnumerable<object> selectItems, string displayMember, string label) {
      ListSelection userSelect = new(selectItems.ToList(), displayMember, label);

      userSelect.ShowDialog(this);

      return userSelect;
    }



    private ListSelection GetSelect(IEnumerable<object> selectItems, string label) {
      return GetSelect(selectItems, "", label);
    }



    private TextInput GetNewName() {
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



    private ObjectEditor CreateNewLayout() {
      Func<object, bool> validator = obj => {
        Layout.Entity layout = (Layout.Entity) obj;



        bool isNameEmpty = layout.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = Core.Layout.FileSystem.Exists(layout.Name);

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

      Layout.Entity initialLayout = new();

      ObjectEditor newLayout = new(validator, initialLayout, "Nová zóna");

      newLayout.ShowDialog(this);

      return newLayout;
    }



    private ObjectEditor CreateNewZone() {
      Func<object, bool> validator = obj => {
        Zone.Entity zone = (Zone.Entity) obj;



        bool isNameEmpty = zone.Name.Trim().Length == 0;

        bool isNameAlreadyInUse = this.CurrentLayout.Zones.Any(currentZone => currentZone.Name == zone.Name);

        bool isVerticalCapacityNegative = zone.VerticalCapacity < 0;

        bool isOutOfBounds = !this.CurrentLayout.Rectangle.Contains(zone.Rectangle);

        bool doesIntersectWithOtherZone = this.CurrentLayout.Zones.Any(currentZone => zone.Rectangle.IntersectsWith(currentZone.Rectangle));

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

      Core.Zone.Entity initialZone = new();

      ObjectEditor newZone = new(validator, initialZone, "Nová zóna");

      newZone.ShowDialog(this);

      return newZone;
    }
  }
}
