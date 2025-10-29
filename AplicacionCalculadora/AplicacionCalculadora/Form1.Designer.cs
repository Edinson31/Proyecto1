namespace AplicacionCalculadora
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnC, btnCE, btnPlusMinus, btnDot;
        private System.Windows.Forms.Button btnAdd, btnSubtract, btnMultiply, btnDivide;
        private System.Windows.Forms.Button btnEquals;
        private System.Windows.Forms.Button btnSquare, btnSqrt, btnPower, btnPercent;
        private System.Windows.Forms.Button btnShowCalculations;
        private System.Windows.Forms.Button[] digitButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnC = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnPlusMinus = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnSqrt = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.btnShowCalculations = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtDisplay
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(336, 50);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // btnC
            this.btnC.Text = "C";
            this.btnC.Location = new System.Drawing.Point(12, 70);
            this.btnC.Size = new System.Drawing.Size(75, 40);
            this.btnC.Click += new System.EventHandler(this.BtnC_Click);

            // btnCE
            this.btnCE.Text = "CE";
            this.btnCE.Location = new System.Drawing.Point(93, 70);
            this.btnCE.Size = new System.Drawing.Size(75, 40);
            this.btnCE.Click += new System.EventHandler(this.BtnCE_Click);

            // btnSquare
            this.btnSquare.Text = "x²";
            this.btnSquare.Location = new System.Drawing.Point(174, 70);
            this.btnSquare.Size = new System.Drawing.Size(75, 40);
            this.btnSquare.Click += new System.EventHandler(this.BtnSquare_Click);

            // btnSqrt
            this.btnSqrt.Text = "√";
            this.btnSqrt.Location = new System.Drawing.Point(255, 70);
            this.btnSqrt.Size = new System.Drawing.Size(75, 40);
            this.btnSqrt.Click += new System.EventHandler(this.BtnSqrt_Click);

            // Crear botones numéricos
            this.digitButtons = new System.Windows.Forms.Button[10];
            int startX = 12, startY = 116, w = 75, h = 50, gap = 6;

            int n = 1;
            for (int row = 2; row >= 0; row--)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button();
                    btn.Text = n.ToString();
                    btn.Size = new System.Drawing.Size(w, h);
                    btn.Location = new System.Drawing.Point(startX + col * (w + gap), startY + row * (h + gap));
                    btn.Click += new System.EventHandler(this.Digit_Click);
                    this.digitButtons[n] = btn;
                    this.Controls.Add(btn);
                    n++;
                }
            }

            // Botón 0
            this.digitButtons[0] = new Button();
            this.digitButtons[0].Text = "0";
            this.digitButtons[0].Size = new System.Drawing.Size(w * 2 + gap, h);
            this.digitButtons[0].Location = new System.Drawing.Point(startX, startY + 3 * (h + gap));
            this.digitButtons[0].Click += new System.EventHandler(this.Digit_Click);
            this.Controls.Add(this.digitButtons[0]);

            // Punto
            this.btnDot.Text = ".";
            this.btnDot.Size = new System.Drawing.Size(w, h);
            this.btnDot.Location = new System.Drawing.Point(startX + 2 * (w + gap), startY + 3 * (h + gap));
            this.btnDot.Click += new System.EventHandler(this.Digit_Click);

            // Signo
            this.btnPlusMinus.Text = "±";
            this.btnPlusMinus.Size = new System.Drawing.Size(w, h);
            this.btnPlusMinus.Location = new System.Drawing.Point(startX + (w + gap), startY + 3 * (h + gap));
            this.btnPlusMinus.Click += new System.EventHandler(this.BtnToggleSign_Click);

            // Operadores básicos
            this.btnDivide.Text = "÷";
            this.btnDivide.Tag = "/";
            this.btnDivide.Location = new System.Drawing.Point(255, 116);
            this.btnDivide.Size = new System.Drawing.Size(w, h);
            this.btnDivide.Click += new System.EventHandler(this.Operator_Click);

            this.btnMultiply.Text = "×";
            this.btnMultiply.Tag = "*";
            this.btnMultiply.Location = new System.Drawing.Point(255, 116 + (h + gap));
            this.btnMultiply.Size = new System.Drawing.Size(w, h);
            this.btnMultiply.Click += new System.EventHandler(this.Operator_Click);

            this.btnSubtract.Text = "-";
            this.btnSubtract.Tag = "-";
            this.btnSubtract.Location = new System.Drawing.Point(255, 116 + 2 * (h + gap));
            this.btnSubtract.Size = new System.Drawing.Size(w, h);
            this.btnSubtract.Click += new System.EventHandler(this.Operator_Click);

            this.btnAdd.Text = "+";
            this.btnAdd.Tag = "+";
            this.btnAdd.Location = new System.Drawing.Point(255, 116 + 3 * (h + gap));
            this.btnAdd.Size = new System.Drawing.Size(w, h);
            this.btnAdd.Click += new System.EventHandler(this.Operator_Click);

            // ===== BOTÓN IGUAL =====
            this.btnEquals.Text = "=";
            this.btnEquals.Location = new System.Drawing.Point(174, 116 + 3 * (h + gap));
            this.btnEquals.Size = new System.Drawing.Size(w, h);
            this.btnEquals.Click += new System.EventHandler(this.BtnEquals_Click);

            // Opcionales: potencia y porcentaje
            this.btnPower.Text = "x^y";
            this.btnPower.Tag = "POW";
            this.btnPower.Location = new System.Drawing.Point(12, 116 + 4 * (h + gap));
            this.btnPower.Size = new System.Drawing.Size(75, 40);
            this.btnPower.Click += new System.EventHandler(this.Operator_Click);

            this.btnPercent.Text = "%";
            this.btnPercent.Tag = "PCT";
            this.btnPercent.Location = new System.Drawing.Point(93, 116 + 4 * (h + gap));
            this.btnPercent.Size = new System.Drawing.Size(75, 40);
            this.btnPercent.Click += new System.EventHandler(this.Operator_Click);

            // Mostrar cálculos
            this.btnShowCalculations.Text = "Mostrar cálculos";
            this.btnShowCalculations.Location = new System.Drawing.Point(12, 116 + 5 * (h + gap));
            this.btnShowCalculations.Size = new System.Drawing.Size(318, 40);
            this.btnShowCalculations.Click += new System.EventHandler(this.BtnShowCalculations_Click);

            // Añadir controles
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnSquare);
            this.Controls.Add(this.btnSqrt);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnPlusMinus);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnPercent);
            this.Controls.Add(this.btnShowCalculations);

            // Configuración del formulario
            this.ClientSize = new System.Drawing.Size(360, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Calculadora - Proyecto DS4";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
