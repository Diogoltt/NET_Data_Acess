namespace Exemplo1_Winforms_IDE;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label label1; // Criação com tipo de uma classe específica para texto
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Button button1;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container(); // Inicializa novo container de componentes
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Ajuste automático do form
        this.ClientSize = new System.Drawing.Size(800, 450); // Define tamanho do form
        this.Text = "Iniciar"; // Define o texto do formulário

        this.label1 = new System.Windows.Forms.Label();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();

        this.label1.AutoSize = true; // Ajusta tamanho do label de acordo com o texto
        this.label1.Location = new System.Drawing.Point(30, 30); // Posição do label
        this.label1.Name = "label1"; // Define o tamanho do label
        this.label1.Size = new System.Drawing.Size(90, 20);
        this.label1.Text = "Digite dois números: ";

        this.textBox1.Location = new System.Drawing.Point(30, 60);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(100, 20);

        this.textBox2.Location = new System.Drawing.Point(30, 90); // Alterar a posição de textBox2
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(100, 20);


        this.button1.Location = new System.Drawing.Point(30, 120);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(100, 20);
        this.button1.Text = "Clique aqui";
        this.button1.Click += new System.EventHandler(this.button1_Click);

        this.Controls.Add(this.label1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.button1);
    }

    #endregion
}
