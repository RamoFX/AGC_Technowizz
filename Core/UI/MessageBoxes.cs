using System.Windows.Forms;



namespace Core.UI {
  static public class MessageBoxes {
    // Errors
    static public void StartupLayoutCorruptedOrDoesntExist() {
      MessageBox.Show("Spouštěcí rozložení je poškozené nebo neexistuje.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NoLayoutsExist() {
      MessageBox.Show("Rozložení nenalezeny. Zkuste nejprve vytvořit nové rozložení.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NotANumber() {
      MessageBox.Show("Číslo je neplatné nebo není číslo.", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    static public void NoSuitableZone(string carBrand) {
      MessageBox.Show($"Nenašla se žádná zóna, která by měla místo pro paletu a zároveň je určena pro uskladnění značky \"{ carBrand }\".", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }



    // Warnings
    static public void TextValueCannotBeEmpty() {
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
      MessageBox.Show("Každý rozměr musí být větší jak 0.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    static public void InvalidRegularOrOtherZone() {
      MessageBox.Show("Zóna musí obsahovat značku auta a zároveň mít kladnou vertikální kapacitu nebo značka auta musí být prázdná a zároveň vertikální kapacita musí být nula.", "Pozor!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }



    // Confirmation
    static public DialogResult SaveUnsavedLayout() {
      return MessageBox.Show("Rozložení obsahuje změny a není uloženo. Přejete si ho uložit?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    static public DialogResult DeleteConfirmation() {
      return MessageBox.Show("Tato položka bude odstraněna a tuto operaci nelze vrátit zpět. Pokračovat?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    static public DialogResult SettingsReset() {
      return MessageBox.Show("Opravdu chcete vrátit základní nastavení?", "Jste si jistí?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
  }
}
