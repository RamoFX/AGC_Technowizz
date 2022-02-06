﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.UI.Dialogs
{
  public partial class Help : Form
  {
    public Help()
    {
      InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e)
    {
      Color100_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_Full.Value);
      Color99_75_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AlmostFull.Value);
      Color74_50_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AboveHalf.Value);
      Color49_25_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_BelowHalf.Value);
      Color24_1_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AlmostEmpty.Value);
      Color0_PictureBox.BackColor = Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_Empty.Value);
    }
  }
}
