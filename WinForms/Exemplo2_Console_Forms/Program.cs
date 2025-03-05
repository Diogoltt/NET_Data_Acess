namespace Exemplo2_Console_Forms
{
    public class Program
    {
        [STAThread] /* Atributo que indica que o método Main é um 
        Método de thread de nível de app que é executado em um único thread
        de aplicativo*/

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
        
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Calculadora());
        }
    }

    public class MeuFormulario : Form
    {
        public MeuFormulario()
        {
            this.Text = "Meu Formulário";
            this.Size = new Size(300, 300);

            Label label = new Label();
            label.Text = "Hello World";
            label.Location = new Point(100, 100);
            this.AutoSize = true;

            this.Controls.Add(label);
        }
    }
}
