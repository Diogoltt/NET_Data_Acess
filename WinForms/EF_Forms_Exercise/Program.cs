using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using EF_Forms_Exercise.Models;

namespace EF_Forms_Exercise
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CadastroForm());
        }
    }

    public class CadastroForm : Form
    {
        // Abas para cada entidade
        private TabControl tabControl;
        private TabPage tabUsuarios;
        private TabPage tabMaquinas;
        private TabPage tabSoftwares;

        // Controles para a aba Usuários
        private Label lblUsuarioId, lblNomeUsuario, lblPassword, lblRamal, lblEspecialidade;
        private TextBox txtUsuarioId, txtNomeUsuario, txtPassword, txtRamal, txtEspecialidade;
        private Button btnInserirUsuario, btnListarUsuarios, btnAtualizarUsuario, btnDeletarUsuario;
        private ListBox lstUsuarios;

        // Controles para a aba Máquinas
        private Label lblMaquinaId, lblTipo, lblVelocidade, lblHardDisk, lblPlacaRede, lblMemoriaRam, lblUsuarioIdMaquina;
        private TextBox txtMaquinaId, txtTipo, txtVelocidade, txtHardDisk, txtPlacaRede, txtMemoriaRam, txtUsuarioIdMaquina;
        private Button btnInserirMaquina, btnListarMaquinas, btnAtualizarMaquina, btnDeletarMaquina;
        private ListBox lstMaquinas;

        // Controles para a aba Softwares
        private Label lblSoftwareId, lblProduto, lblHardDiskSoftware, lblMemoriaRamSoftware, lblMaquinaIdSoftware;
        private TextBox txtSoftwareId, txtProduto, txtHardDiskSoftware, txtMemoriaRamSoftware, txtMaquinaIdSoftware;
        private Button btnInserirSoftware, btnListarSoftwares, btnAtualizarSoftware, btnDeletarSoftware;
        private ListBox lstSoftwares;

        private Crud crud;

        public CadastroForm()
        {
            // Inicializar o objeto CRUD
            crud = new Crud();

            // Configurar o formulário
            this.Size = new Size(800, 600);
            this.Text = "Sistema de Gerenciamento";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Criar o TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10)
            };

            // Criar as abas
            tabUsuarios = new TabPage("Usuários");
            tabMaquinas = new TabPage("Máquinas");
            tabSoftwares = new TabPage("Softwares");

            // Configurar a aba de Usuários
            ConfigurarAbaUsuarios();

            // Configurar a aba de Máquinas
            ConfigurarAbaMaquinas();

            // Configurar a aba de Softwares
            ConfigurarAbaSoftwares();

            // Adicionar as abas ao TabControl
            tabControl.TabPages.Add(tabUsuarios);
            tabControl.TabPages.Add(tabMaquinas);
            tabControl.TabPages.Add(tabSoftwares);

            // Adicionar o TabControl ao formulário
            this.Controls.Add(tabControl);
        }

        private void ConfigurarAbaUsuarios()
        {
            Font fontePadrao = new Font("Arial", 10, FontStyle.Bold);
            Font fonteAlternativa = new Font("Arial", 10);

            // Labels
            lblUsuarioId = new Label { Text = "ID:", Location = new Point(20, 20), Font = fontePadrao, ForeColor = Color.Navy };
            lblNomeUsuario = new Label { Text = "Nome:", Location = new Point(20, 70), Font = fontePadrao, ForeColor = Color.Navy };
            lblPassword = new Label { Text = "Senha:", Location = new Point(20, 120), Font = fontePadrao, ForeColor = Color.Navy };
            lblRamal = new Label { Text = "Ramal:", Location = new Point(20, 170), Font = fontePadrao, ForeColor = Color.Navy };
            lblEspecialidade = new Label { Text = "Especialidade:", Location = new Point(20, 220), Font = fontePadrao, ForeColor = Color.Navy };

            // TextBoxes
            txtUsuarioId = new TextBox { Location = new Point(150, 20), Width = 200, Font = fonteAlternativa };
            txtNomeUsuario = new TextBox { Location = new Point(150, 70), Width = 200, Font = fonteAlternativa };
            txtPassword = new TextBox { Location = new Point(150, 120), Width = 200, Font = fonteAlternativa, PasswordChar = '*' };
            txtRamal = new TextBox { Location = new Point(150, 170), Width = 200, Font = fonteAlternativa };
            txtEspecialidade = new TextBox { Location = new Point(150, 220), Width = 200, Font = fonteAlternativa };

            // Botões
            btnInserirUsuario = CriarBotao("Inserir", new Point(400, 20), Color.ForestGreen);
            btnListarUsuarios = CriarBotao("Listar", new Point(400, 70), Color.RoyalBlue);
            btnAtualizarUsuario = CriarBotao("Atualizar", new Point(400, 120), Color.Orange);
            btnDeletarUsuario = CriarBotao("Deletar", new Point(400, 170), Color.Crimson);

            // ListBox
            lstUsuarios = new ListBox
            {
                Location = new Point(20, 270),
                Width = 700,
                Height = 200,
                Font = fonteAlternativa
            };

            // Eventos dos botões
            btnInserirUsuario.Click += new EventHandler(BtnInserirUsuario_Click);
            btnListarUsuarios.Click += new EventHandler(BtnListarUsuarios_Click);
            btnAtualizarUsuario.Click += new EventHandler(BtnAtualizarUsuario_Click);
            btnDeletarUsuario.Click += new EventHandler(BtnDeletarUsuario_Click);

            // Adicionar controles à aba
            tabUsuarios.Controls.Add(lblUsuarioId);
            tabUsuarios.Controls.Add(lblNomeUsuario);
            tabUsuarios.Controls.Add(lblPassword);
            tabUsuarios.Controls.Add(lblRamal);
            tabUsuarios.Controls.Add(lblEspecialidade);
            tabUsuarios.Controls.Add(txtUsuarioId);
            tabUsuarios.Controls.Add(txtNomeUsuario);
            tabUsuarios.Controls.Add(txtPassword);
            tabUsuarios.Controls.Add(txtRamal);
            tabUsuarios.Controls.Add(txtEspecialidade);
            tabUsuarios.Controls.Add(btnInserirUsuario);
            tabUsuarios.Controls.Add(btnListarUsuarios);
            tabUsuarios.Controls.Add(btnAtualizarUsuario);
            tabUsuarios.Controls.Add(btnDeletarUsuario);
            tabUsuarios.Controls.Add(lstUsuarios);
        }

        private void ConfigurarAbaMaquinas()
        {
            Font fontePadrao = new Font("Arial", 10, FontStyle.Bold);
            Font fonteAlternativa = new Font("Arial", 10);

            // Labels
            lblMaquinaId = new Label { Text = "ID:", Location = new Point(20, 20), Font = fontePadrao, ForeColor = Color.Navy };
            lblTipo = new Label { Text = "Tipo:", Location = new Point(20, 70), Font = fontePadrao, ForeColor = Color.Navy };
            lblVelocidade = new Label { Text = "Velocidade:", Location = new Point(20, 120), Font = fontePadrao, ForeColor = Color.Navy };
            lblHardDisk = new Label { Text = "Hard Disk:", Location = new Point(20, 170), Font = fontePadrao, ForeColor = Color.Navy };
            lblPlacaRede = new Label { Text = "Placa de Rede:", Location = new Point(20, 220), Font = fontePadrao, ForeColor = Color.Navy };
            lblMemoriaRam = new Label { Text = "Memória RAM:", Location = new Point(350, 20), Font = fontePadrao, ForeColor = Color.Navy };
            lblUsuarioIdMaquina = new Label { Text = "ID do Usuário:", Location = new Point(350, 70), Font = fontePadrao, ForeColor = Color.Navy };

            // TextBoxes
            txtMaquinaId = new TextBox { Location = new Point(150, 20), Width = 180, Font = fonteAlternativa };
            txtTipo = new TextBox { Location = new Point(150, 70), Width = 180, Font = fonteAlternativa };
            txtVelocidade = new TextBox { Location = new Point(150, 120), Width = 180, Font = fonteAlternativa };
            txtHardDisk = new TextBox { Location = new Point(150, 170), Width = 180, Font = fonteAlternativa };
            txtPlacaRede = new TextBox { Location = new Point(150, 220), Width = 180, Font = fonteAlternativa };
            txtMemoriaRam = new TextBox { Location = new Point(470, 20), Width = 180, Font = fonteAlternativa };
            txtUsuarioIdMaquina = new TextBox { Location = new Point(470, 70), Width = 180, Font = fonteAlternativa };

            // Botões
            btnInserirMaquina = CriarBotao("Inserir", new Point(350, 120), Color.ForestGreen);
            btnListarMaquinas = CriarBotao("Listar", new Point(350, 170), Color.RoyalBlue);
            btnAtualizarMaquina = CriarBotao("Atualizar", new Point(470, 120), Color.Orange);
            btnDeletarMaquina = CriarBotao("Deletar", new Point(470, 170), Color.Crimson);

            // ListBox
            lstMaquinas = new ListBox
            {
                Location = new Point(20, 270),
                Width = 700,
                Height = 200,
                Font = fonteAlternativa
            };

            // Eventos dos botões
            btnInserirMaquina.Click += new EventHandler(BtnInserirMaquina_Click);
            btnListarMaquinas.Click += new EventHandler(BtnListarMaquinas_Click);
            btnAtualizarMaquina.Click += new EventHandler(BtnAtualizarMaquina_Click);
            btnDeletarMaquina.Click += new EventHandler(BtnDeletarMaquina_Click);

            // Adicionar controles à aba
            tabMaquinas.Controls.Add(lblMaquinaId);
            tabMaquinas.Controls.Add(lblTipo);
            tabMaquinas.Controls.Add(lblVelocidade);
            tabMaquinas.Controls.Add(lblHardDisk);
            tabMaquinas.Controls.Add(lblPlacaRede);
            tabMaquinas.Controls.Add(lblMemoriaRam);
            tabMaquinas.Controls.Add(lblUsuarioIdMaquina);
            tabMaquinas.Controls.Add(txtMaquinaId);
            tabMaquinas.Controls.Add(txtTipo);
            tabMaquinas.Controls.Add(txtVelocidade);
            tabMaquinas.Controls.Add(txtHardDisk);
            tabMaquinas.Controls.Add(txtPlacaRede);
            tabMaquinas.Controls.Add(txtMemoriaRam);
            tabMaquinas.Controls.Add(txtUsuarioIdMaquina);
            tabMaquinas.Controls.Add(btnInserirMaquina);
            tabMaquinas.Controls.Add(btnListarMaquinas);
            tabMaquinas.Controls.Add(btnAtualizarMaquina);
            tabMaquinas.Controls.Add(btnDeletarMaquina);
            tabMaquinas.Controls.Add(lstMaquinas);
        }
    }
}

/* private void ConfigurarAbaSoftwares()
{
    Font fontePadrao = new Font("Arial", 10, FontStyle.Bold);
    Font fonteAlternativa = new Font("Arial", 10);

    // Labels
    lblSoftwareId = new Label { Text = "ID:", Location = new Point(20, 20), Font = fontePadrao, ForeColor = Color.Navy };
    lblProduto = new Label { Text = "Produto:", Location = new Point(20, 70), Font = fontePadrao, ForeColor = Color.Navy };
    lblHardDiskSoftware = new Label { Text = "Hard Disk:", Location = new Point(20, 120), Font = fontePadrao, ForeColor = Color.Navy };
    lblMemoriaRamSoftware = new Label { Text = "Memória RAM:", Location = new Point(20, 170), Font = fontePadrao, ForeColor = Color.Navy };
    lblMaquinaIdSoftware = new Label { Text = "ID da Máquina:", Location = new Point(20, 220), Font = fontePadrao, ForeColor = Color.Navy };

    // TextBoxes
    txtSoftwareId = new TextBox { Location = new Point(150, 20), Width = 200, Font = fonteAlternativa };
    txtProduto = new TextBox { Location = new Point(150, 70), Width = 200, Font = fonteAlternativa };
    txtHardDiskSoftware = new TextBox { Location = new Point(150, 120), Width = 200, Font = fonteAlternativa };
    txtMemoriaRamSoftware = new TextBox { Location = new Point(150, 170), Width = 200, Font = fonteAlternativa };
    txtMaquinaIdSoftware = new TextBox { Location = new Point(150, 220), Width = 200, Font = fonteAlternativa };

    // Botões
    btnInserirSoftware = CriarBotao("Inserir", new Point(400, 20), Color.ForestGreen);
    btnListarSoftwares = CriarBotao("Listar", new Point(400, 70), Color.RoyalBlue);
    btnAtualizarSoftware = CriarBotao("Atualizar", new Point(400, 120), Color.Orange);
    btnDeletarSoftware = CriarBotao("Deletar", new Point(400, 170), Color.Crimson);

    // ListBox
    lstSoftwares = new ListBox
    {
        Location = new Point(20, 270),
        Width = 700,
        Height = 200,
        Font = fonteAlternativa
    };

    // Eventos dos botões
    btnInserirSoftware.Click += new EventHandler(BtnInserirSoftware_Click);
    btnListarSoftwares.Click += new EventHandler(BtnListarSoftwares_Click);
    btnAtualizarSoftware.Click += new EventHandler(BtnAtualizarSoftware_Click);
    btnDeletarSoftware.Click += new EventHandler(BtnDeletarSoftware_Click);

    // Adicionar controles à aba
    tabSoftwares.Controls.Add(lblSoftwareId);
    tabSoftwares.Controls.Add(lblProduto);
    tabSoftwares.Controls.Add(lblHardDiskSoftware);
    tabSoftwares.Controls.Add(lblMemoriaRamSoftware);
    tabSoftwares.Controls.Add(lblMaquinaIdSoftware);
    tabSoftwares.Controls.Add(txtSoftwareId);
    tabSoftwares.Controls.Add(txtProduto);
    tabSoftwares.Controls.Add(txtHardDiskSoftware);
    tabSoftwares.Controls.Add(txtMemoriaRamSoftware);
    tabSoftwares.Controls.Add(txtMaquinaIdSoftware);
    tabSoftwares.Controls.Add(btnInserirSoftware);
    tabSoftwares.Controls.Add(btnListarSoftwares);
    tabSoftwares.Controls.Add(btnAtualizarSoftware);
    tabSoftwares.Controls.Add(btnDeletarSoftware);
    tabSoftwares.Controls.Add(lstSoftwares);
}

private Button CriarBotao(string texto, Point localizacao, Color cor)
{
    return new Button
    {
        Text = texto,
        Location = localizacao,
        Width = 100,
        Height = 30,
        BackColor = cor,
        ForeColor = Color.White,
        Font = new Font("Arial", 10, FontStyle.Bold),
        FlatStyle = FlatStyle.Flat
    };
}

// Eventos para Usuários
private void BtnInserirUsuario_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrEmpty(txtUsuarioId.Text) || string.IsNullOrEmpty(txtNomeUsuario.Text) ||
            string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtRamal.Text) ||
            string.IsNullOrEmpty(txtEspecialidade.Text))
        {
            MessageBox.Show("Todos os campos devem ser preenchidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = int.Parse(txtUsuarioId.Text);
        string nomeUsuario = txtNomeUsuario.Text;
        string password = txtPassword.Text;
        int ramal = int.Parse(txtRamal.Text);
        string especialidade = txtEspecialidade.Text;

        crud.InserirUsuario(id, nomeUsuario, password, ramal, especialidade);
        MessageBox.Show("Usuário inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LimparCamposUsuario();
        BtnListarUsuarios_Click(sender, e);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

    private void BtnAtualizarUsuario_Click(object sender, EventArgs e)
{
try
{
    if (string.IsNullOrEmpty(txtUsuarioId.Text) || string.IsNullOrEmpty(txtNomeUsuario.Text))
    {
        MessageBox.Show("ID e Nome são obrigatórios para atualização!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    int id = int.Parse(txtUsuarioId.Text);
    string nomeUsuario = txtNomeUsuario.Text;

    using (var db = new Ligacao())
    {
        var usuario = db.Usuarios.Find(id);
        if (usuario != null)
        {
            usuario.NomeUsuario = nomeUsuario;

            if (!string.IsNullOrEmpty(txtPassword.Text))
                usuario.Password = txtPassword.Text;

            if (!string.IsNullOrEmpty(txtRamal.Text))
                usuario.Ramal = int.Parse(txtRamal.Text);

            if (!string.IsNullOrEmpty(txtEspecialidade.Text))
                usuario.Especialidade = txtEspecialidade.Text;

            db.SaveChanges();
            MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCamposUsuario();
            BtnListarUsuarios_Click(sender, e);
        }
        else
        {
            MessageBox.Show("Usuário não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
catch (Exception ex)
{
    MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

private void BtnDeletarUsuario_Click(object sender, EventArgs e)
{
try
{
    if (string.IsNullOrEmpty(txtUsuarioId.Text))
    {
        MessageBox.Show("ID é obrigatório para exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    int id = int.Parse(txtUsuarioId.Text);

    var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este usuário?", 
                                       "Confirmar Exclusão",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

    if (confirmResult == DialogResult.Yes)
    {
        crud.DeletarUsuario(id);
        MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LimparCamposUsuario();
        BtnListarUsuarios_Click(sender, e);
    }
}
catch (Exception ex)
{
    MessageBox.Show("Erro ao excluir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

private void LimparCamposUsuario()
{
txtUsuarioId.Clear();
txtNomeUsuario.Clear();
txtPassword.Clear();
txtRamal.Clear();
txtEspecialidade.Clear();
}

private void BtnAtualizarUsuario_Click(object sender, EventArgs e)
{
try
{
if (string.IsNullOrEmpty(txtUsuarioId.Text) || string.IsNullOrEmpty(txtNomeUsuario.Text))
{
    MessageBox.Show("ID e Nome são obrigatórios para atualização!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

int id = int.Parse(txtUsuarioId.Text);
string nomeUsuario = txtNomeUsuario.Text;

using (var db = new Ligacao())
{
    var usuario = db.Usuarios.Find(id);
    if (usuario != null)
    {
        usuario.NomeUsuario = nomeUsuario;

        if (!string.IsNullOrEmpty(txtPassword.Text))
            usuario.Password = txtPassword.Text;

        if (!string.IsNullOrEmpty(txtRamal.Text))
            usuario.Ramal = int.Parse(txtRamal.Text);

        if (!string.IsNullOrEmpty(txtEspecialidade.Text))
            usuario.Especialidade = txtEspecialidade.Text;

        db.SaveChanges();
        MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        LimparCamposUsuario();
        BtnListarUsuarios_Click(sender, e);
    }
    else
    {
        MessageBox.Show("Usuário não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
}
catch (Exception ex)
{
MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

private void BtnDeletarUsuario_Click(object sender, EventArgs e)
{
try
{
if (string.IsNullOrEmpty(txtUsuarioId.Text))
{
    MessageBox.Show("ID é obrigatório para exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

int id = int.Parse(txtUsuarioId.Text);

var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este usuário?", 
                                   "Confirmar Exclusão",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

if (confirmResult == DialogResult.Yes)
{
    crud.DeletarUsuario(id);
    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    LimparCamposUsuario();
    BtnListarUsuarios_Click(sender, e);
}
}
catch (Exception ex)
{
MessageBox.Show("Erro ao excluir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}

private void LimparCamposUsuario()
{
txtUsuarioId.Clear();
txtNomeUsuario.Clear();
txtPassword.Clear();
txtRamal.Clear();
txtEspecialidade.Clear();
}
*/