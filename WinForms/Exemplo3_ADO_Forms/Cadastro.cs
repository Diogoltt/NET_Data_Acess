using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo3_ADO_Forms
{
    public class Cadastro : Form
    {
        private Label label1, label2, label3;
        private TextBox txtId, txtNome, txtEmail;
        private Button btnInserir, btnListar, btnAtualizar, btnDeletar;
        private ListBox lstUsuarios;
        private CRUD crud;

        public Cadastro()
        {
            crud = new CRUD();

            this.Size = new Size(500, 500);
            this.Text = "Cadastro de Usuários";
            this.BackColor = Color.White;

            var fontePadrao = new Font("Arial", 12, FontStyle.Bold);
            var fonteAlternativa = new Font("Italic", 12, FontStyle.Bold);

            label1 = new Label { Text = "ID:", Location = new Point(20, 10), Font = fontePadrao, ForeColor = Color.Blue };
            label2 = new Label { Text = "Nome:", Location = new Point(20, 60), Font = fontePadrao, ForeColor = Color.Blue };
            label3 = new Label { Text = "Email:", Location = new Point(20, 110), Font = fontePadrao, ForeColor = Color.Blue };

            txtId = new TextBox { Location = new Point(20, 30), Width = 220, Font = fonteAlternativa };
            txtNome = new TextBox { Location = new Point(20, 80), Width = 220, Font = fonteAlternativa };
            txtEmail = new TextBox { Location = new Point(20, 130), Width = 220, Font = fonteAlternativa };

            btnInserir = CriarBotao("Inserir", new Point(270, 30), Color.LightGreen);
            btnListar = CriarBotao("Listar", new Point(270, 60), Color.LightGreen);
            btnAtualizar = CriarBotao("Atualizar", new Point(270, 90), Color.LightGreen);
            btnDeletar= CriarBotao("Deletar", new Point(270, 120), Color.LightGreen);

            btnInserir.Click += new EventHandler(ButtonInserir_Click);
            btnListar.Click += new EventHandler(ButtonListar_Click);
            btnAtualizar.Click += new EventHandler(ButtonAtualizar_Click);
            btnDeletar.Click += new EventHandler(ButtonDeletar_Click);

            lstUsuarios = new ListBox
            {
                Location = new Point(20, 180),
                Width = 500,
                Height = 150,
                BackColor = Color.White,
                ForeColor = Color.Blue
            };

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnListar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnDeletar);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(lstUsuarios);

        }

        private Button CriarBotao(string texto, Point localizacao, Color cor)
        {
            return new Button
            {
                Text = texto,
                Location = localizacao,
                Width = 100,
                Height = 30,
                BackColor = Color.LightYellow,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
        }

        private void ButtonInserir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.InserirUsuario(id, nome, email);
                MessageBox.Show("Usuário inserido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                crud.AtualizarUsuario(id, nome);
                MessageBox.Show("Usuário atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonListar_Click(object sender, EventArgs e)
        {
            try
            {
                lstUsuarios.Items.Clear();

                List<string> usuarios = crud.ListarUsuarios();
                if (usuarios.Count > 0)
                {
                    foreach (var usuario in usuarios)
                    {
                        lstUsuarios.Items.Add(usuario);
                    }
                }
                else
                {
                    lstUsuarios.Items.Add("Nenhum usuário encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                crud.DeletarUsuario(id);
                MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao deletar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
        }

    }
}