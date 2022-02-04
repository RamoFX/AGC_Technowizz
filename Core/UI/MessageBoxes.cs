using System.Windows.Forms;



namespace Core.UI {
  static public class MessageBoxes {
    static public void StartupLayoutCorruptedOrDoesntExist() {
      MessageBox.Show("Spoučtěcí rozvržení neexistuje nebo je poškozené.", "Pozor!");
    }

    static public void NoLayoutsExist() {
      MessageBox.Show("Rozvržení nenalezeny. Zkuste nejprve vytvořit nové rozvržení.", "Chyba!");
    }

    static public void LayoutInvalid(string name) {
      MessageBox.Show($"Rozvržení \"{ name }\" je poškozené.", "Chyba!");
    }

    static public void TextFieldCannotBeEmpty() {
      MessageBox.Show("Textové pole nesmí být prázdné.");
    }

    static public void TextFieldCannotContainInvalidChars() {
      MessageBox.Show("Textové pole nesmí obsahovat zakázané znaky.");
    }

    static public void LayoutNameAlreadyExist() {
      MessageBox.Show("Rozvržení, které se použilo minule nebo je standartní, neexistuje, načetlo se první dostupné.", "Pozor!");
    }

    static public DialogResult SaveUnsavedLayoutConfirmation() {
      return MessageBox.Show("Rozvržení, které se použilo minule nebo je standartní, neexistuje, načetlo se první dostupné.", "Pozor!");
    }

    static public DialogResult UndoableDeletionConfirmation(string name) {
      return MessageBox.Show($"Rozvržení \"{ name }\" bude odstraněno a tuto operaci nebude možné vrátit zpět. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo);
    }
  }
}
