using System.Globalization;

namespace Exemplo3_ADO_Forms
{
    public class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Cadastro());
        }
    }
}