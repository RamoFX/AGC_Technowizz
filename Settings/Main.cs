using Core;
using Core.UI;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Settings
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      LoadSettingsToTreeView();
    }

    private void treeView_settings_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (treeView_settings.SelectedNode.Parent != null)
        WriteToSettingsValueTextBox(treeView_settings.SelectedNode.Text);
      else
        HideSettingsWrite();
    }

    private void SubmitHandler(object sender, EventArgs e)
    {
      string selectedSetting = treeView_settings.SelectedNode.Parent.Tag.ToString();
      string value = settingsValue_TextBox.Text;
      DynamicSettings.WriteSettingsValue(selectedSetting, value);
      MessageBoxes.SettingsWriteSuccessful();
      HideSettingsWrite();
      LoadSettingsToTreeView();
    }

    void WriteToSettingsValueTextBox(string text)
    {
      settingsValue_TextBox.Text = text;
      settingsValue_TextBox.Enabled = true;
      settingsValue_TextBox.Visible = true;
      SubmitButtom.Enabled = true;
      SubmitButtom.Visible = true;
    }

    void HideSettingsWrite()
    {
      settingsValue_TextBox.Enabled = false;
      settingsValue_TextBox.Visible = false;
      SubmitButtom.Enabled = false;
      SubmitButtom.Visible = false;
    }

    void LoadSettingsToTreeView()
    {
      treeView_settings.Nodes.Clear();
      FieldInfo[] fields = typeof(DynamicSettings).GetFields(BindingFlags.Static | BindingFlags.Public);

      foreach (FieldInfo fi in fields)
      {
        string name = fi.Name;
        string value = (fi.GetValue(null) as Core.Helpers.DynamicSetting).Value;

        List<TreeNode> treeNodeValues = new List<TreeNode>();
        foreach (string text in value.Split(StaticSettings.SettingsSeparator))
        {
          treeNodeValues.Add(new TreeNode(text));
        }
        TreeNode treeNodeKey = new TreeNode(ToReadableString(name), treeNodeValues.ToArray());
        treeNodeKey.Tag = name;
        treeView_settings.Nodes.Add(treeNodeKey);
      }
    }

    string ToReadableString(string PropertyName)
    {
      switch (PropertyName)
      {
        case "ZA_StartupLayoutName":
          return "Název počátečního rozložení";

        case "ZA_HighlightTimeOn":
          return "Čas rozsvícení zóny (blikání)";

        case "ZA_HighlightTimeOff":
          return "Čas zhasnutí zóny (blikání)";

        case "ZA_TotalHighlightFlashes":
          return "Celkový počet rozsvícení zóny";

        case "ZA_LastHighlightOnOff":
          return "Nechat zónu rozsvícenou";

        case "LayoutColor":
          return "Barva okrajů";

        case "GridColor":
          return "Barva mřížky ";

        case "ZoneColor_Storage":
          return "Barva skladovácích prostorů";

        case "ZoneColor_Other":
          return "Barva ostatních prosotrů";

        case "CarBrandColor_Full":
          return "Barva plné zóny";

        case "CarBrandColor_AlmostFull":
          return "Barva skoro plné zóny";

        case "CarBrandColor_AboveHalf":
          return "Barva zóny zaplněné nad polovinu";

        case "CarBrandColor_BelowHalf":
          return "Barva zóny zaplněné do poloviny";

        case "CarBrandColor_AlmostEmpty":
          return "Barva skoro prázdné zóny";

        case "CarBrandColor_Empty":
          return "Barva prázdné zóny";
      }
      return "";
    }
  }
}
