using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplicacionCalculadora
{
    public class CalculationsViewerForm : Form
    {
        private TextBox txtList;

        public CalculationsViewerForm(List<CalculationRecord> items)
        {
            this.Text = "Cálculos guardados";
            this.Width = 600;
            this.Height = 400;
            txtList = new TextBox { Multiline = true, ReadOnly = true, Dock = DockStyle.Fill, ScrollBars = ScrollBars.Both, Font = new System.Drawing.Font("Consolas", 10) };
            this.Controls.Add(txtList);
            foreach (var r in items)
            {
                txtList.AppendText($"{r.DatePerformed:yyyy-MM-dd HH:mm:ss} | {r.Expression} = {r.Result}{Environment.NewLine}");
            }
        }
    }
}
