using System.Windows.Forms;



namespace Core.UI {
  static public class MessageBoxes {
    // Errors
    static public void StartupLayoutCorruptedOrDoesntExist() {
      MessageBox.Show("Spoučtěcí rozvržení je poškozené nebo neexistuje.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NoLayoutsExist() {
      MessageBox.Show("Rozvržení nenalezeny. Zkuste nejprve vytvořit nové rozvržení.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void LayoutInvalid(string name) {
      MessageBox.Show($"Rozvržení \"{ name }\" je poškozené.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }



    // Warnings
    static public void TextFieldCannotBeEmpty() {
      MessageBox.Show("Textové pole nesmí být prázdné.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void TextFieldCannotContainInvalidChars() {
      MessageBox.Show("Textové pole nesmí obsahovat zakázané znaky.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void LayoutNameAlreadyExist() {
      MessageBox.Show("Použijte prosím jiný název, tento se již používá.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }



    // Confirmation
    static public DialogResult SaveUnsavedLayout() {
      return MessageBox.Show("Rozvržení obsahuje změny a není uloženo, přejete si ho uložit?", "Jste si jistí!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
    }

    static public DialogResult UndoableDeletion(string name) {
      return MessageBox.Show($"Rozvržení \"{ name }\" bude odstraněno a tuto operaci nebude možné vrátit zpět. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
    }
  }
}
