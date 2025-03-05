namespace Exemplo2_Console_Forms
{
    public class Calculadora2 : Form
    {
        private Button Button2;
        private Label labelMensagem;

        public Calculadora2()
        {
            this.Text = "Segunda Tela - Calculadora";
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.BackColor = System.Drawing.Color.MediumPurple; // Cor de fundo
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Criando o label com a mensagem
            this.labelMensagem = new Label();
            this.labelMensagem.Text = "Não há nada aqui";
            this.labelMensagem.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.labelMensagem.ForeColor = System.Drawing.Color.DarkRed;
            this.labelMensagem.Size = new System.Drawing.Size(200, 30);
            this.labelMensagem.Location = new System.Drawing.Point(200, 50); // Localização do label

            // Criando o botão
            this.Button2 = new Button();
            this.Button2.Text = "Voltar";
            this.Button2.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Button2.Size = new System.Drawing.Size(100, 40);
            this.Button2.Location = new System.Drawing.Point(200, 130); // Localização do botão
            this.Button2.BackColor = System.Drawing.Color.BlueViolet; // Cor de fundo do botão
            this.Button2.ForeColor = System.Drawing.Color.White; // Cor do texto
            this.Button2.FlatStyle = FlatStyle.Flat; // Estilo do botão
            this.Button2.FlatAppearance.BorderSize = 0; // Remove a borda do botão
            this.Button2.Click += Button2_Click;

            // Adicionando os controles ao formulário
            this.Controls.Add(this.labelMensagem);
            this.Controls.Add(this.Button2);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
