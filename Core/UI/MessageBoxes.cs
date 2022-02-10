using System.Windows.Forms;



namespace Core.UI {
  static public class MessageBoxes {
    // Errors
    static public void StartupLayoutCorruptedOrDoesntExist() {
      MessageBox.Show("Spouštěcí rozvržení je poškozené nebo neexistuje.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NoLayoutsExist() {
      MessageBox.Show("Rozvržení nenalezeny. Zkuste nejprve vytvořit nové rozvržení.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NoSettingsExist() {
      MessageBox.Show("Žadná nastavení nenalezena. Zkuste nejprve spustit ostatní aplikace.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void LayoutInvalid(string name) {
      MessageBox.Show($"Rozvržení \"{ name }\" je poškozené.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }



    // Warnings
    static public void NameCannotBeEmpty() {
      MessageBox.Show("Textová hodnota nesmí být prázdná.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void TextFieldCannotContainInvalidChars() {
      MessageBox.Show("Textové pole nesmí obsahovat zakázané znaky.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void NameAlreadyInUse() {
      MessageBox.Show("Použijte prosím jiný název, tento se již používá.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void CantBeOutOfBounds() {
      MessageBox.Show("Nesmí být mimo okraje.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void CantIntersect() {
      MessageBox.Show("Nesmí mít společnou plochu s jinými položkami.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void AreaFull() {
      MessageBox.Show("Nedostačující volná plocha.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void NoAvailableZone() {
      MessageBox.Show("Nejsou dostupné žádné zóny určené pro ukládání palet.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void VerticalCapacityGreaterThanZero() {
      MessageBox.Show("Vertikální kapacita musí být větší jak 0.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void VerticalCapacityMustBeZero() {
      MessageBox.Show("Vertikální kapacita musí být 0, protože zóna není určena pro ukládání palet.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void InvalidSize() {
      MessageBox.Show("Každej rozměr musí být větší jak 0.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }




    // Confirmation
    static public DialogResult SaveUnsavedLayout() {
      return MessageBox.Show("Rozvržení obsahuje změny a není uloženo, přejete si ho uložit?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    static public DialogResult UndoableDeletion(string name) {
      return MessageBox.Show($"Rozvržení \"{ name }\" bude odstraněno a tuto operaci nebude možné vrátit zpět. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    static public DialogResult SettingsReset() {
      return MessageBox.Show("Opravdu chcete vrátit základní nastavení?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
  }
}
