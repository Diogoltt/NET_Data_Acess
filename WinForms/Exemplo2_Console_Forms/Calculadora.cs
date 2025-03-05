namespace Exemplo2_Console_Forms
{
    public class Calculadora : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Button Button1;

        public Calculadora()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Text = "Calculadora";

            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();

            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(30, 30);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(150, 20);
            this.Label1.Text = "Digite os números:";
            this.Label1.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.DarkBlue;

            this.TextBox1.Location = new System.Drawing.Point(30, 60);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(200, 27);
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10);
            this.TextBox1.BackColor = System.Drawing.Color.White;
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.BorderStyle = BorderStyle.FixedSingle;

            this.TextBox2.Location = new System.Drawing.Point(30, 100);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(200, 27);
            this.TextBox2.Font = new System.Drawing.Font("Arial", 10);
            this.TextBox2.BackColor = System.Drawing.Color.White;
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.BorderStyle = BorderStyle.FixedSingle;

            this.Button1.Location = new System.Drawing.Point(30, 140);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(100, 40);
            this.Button1.Text = "Calcular";
            this.Button1.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Button1.BackColor = System.Drawing.Color.DarkCyan;
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.FlatStyle = FlatStyle.Flat;
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);

            this.Button1.MouseEnter += new System.EventHandler(this.Button1_MouseEnter);
            this.Button1.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);

            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.Button1);
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            this.Button1.BackColor = System.Drawing.Color.Teal;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            this.Button1.BackColor = System.Drawing.Color.DarkCyan;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = Convert.ToInt32(TextBox1.Text);
                num2 = Convert.ToInt32(TextBox2.Text);

                MessageBox.Show($"A soma dos números é: {num1 + num2}\n" +
                                $"A subtração dos números é: {num1 - num2}\n" +
                                $"A multiplicação dos números é: {num1 * num2}\n" +
                                $"A divisão dos números é: {(num2 != 0 ? (num1 / num2).ToString() : "Erro: Divisão por zero")}");
            }
            catch (FormatException)
            {
                // Caso não consiga converter os valores para inteiros
                MessageBox.Show("Digite apenas números inteiros.");
            }
        }
    }
}
