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
      string selectedSetting = treeView_settings.SelectedNode.Parent.Text;
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
        TreeNode treeNodeKey = new TreeNode(name, treeNodeValues.ToArray());
        treeView_settings.Nodes.Add(treeNodeKey);
      }
    }
  }
}
