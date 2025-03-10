using Microsoft.EntityFrameworkCore;

namespace EF_Forms_Exercise
{
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

        private void ConfigurarAbaSoftwares()
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

        private void BtnInserirSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoftwareId.Text) || string.IsNullOrEmpty(txtProduto.Text))
                {
                    MessageBox.Show("ID e Produto são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtSoftwareId.Text);
                string produto = txtProduto.Text;
                int hardDisk = int.Parse(txtHardDiskSoftware.Text);
                int memoriaRam = int.Parse(txtMemoriaRamSoftware.Text);
                int maquinaId = string.IsNullOrEmpty(txtMaquinaIdSoftware.Text) ? 0 : int.Parse(txtMaquinaIdSoftware.Text);

                crud.InserirSoftware(id, produto, hardDisk, memoriaRam, maquinaId);
                MessageBox.Show("Software inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCamposSoftware();
                BtnListarSoftwares_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir software: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListarSoftwares_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Ligacao())
                {
                    var softwares = db.Softwares.Include(s => s.Maquina).ToList();
                    lstSoftwares.Items.Clear();
                    foreach (var s in softwares)
                    {
                        lstSoftwares.Items.Add($"ID: {s.Id}, Produto: {s.Produto}, Máquina: {(s.Maquina != null ? s.Maquina.Tipo : "Nenhuma")}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar softwares: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoftwareId.Text))
                {
                    MessageBox.Show("ID é obrigatório para atualização!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtSoftwareId.Text);

                using (var db = new Ligacao())
                {
                    var software = db.Softwares.Find(id);
                    if (software != null)
                    {
                        if (!string.IsNullOrEmpty(txtProduto.Text))
                            software.Produto = txtProduto.Text;
                        if (!string.IsNullOrEmpty(txtHardDiskSoftware.Text))
                            software.HardDisk = int.Parse(txtHardDiskSoftware.Text);
                        if (!string.IsNullOrEmpty(txtMemoriaRamSoftware.Text))
                            software.MemoriaRam = int.Parse(txtMemoriaRamSoftware.Text);
                        if (!string.IsNullOrEmpty(txtMaquinaIdSoftware.Text))
                            software.MaquinaId = int.Parse(txtMaquinaIdSoftware.Text);

                        db.SaveChanges();
                        MessageBox.Show("Software atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCamposSoftware();
                        BtnListarSoftwares_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Software não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar software: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSoftwareId.Text))
                {
                    MessageBox.Show("ID é obrigatório para exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtSoftwareId.Text);

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este software?",
                                                   "Confirmar Exclusão",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    crud.DeletarSoftware(id);
                    MessageBox.Show("Software excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCamposSoftware();
                    BtnListarSoftwares_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir software: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCamposSoftware()
        {
            txtSoftwareId.Clear();
            txtProduto.Clear();
            txtHardDiskSoftware.Clear();
            txtMemoriaRamSoftware.Clear();
            txtMaquinaIdSoftware.Clear();
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

        private void BtnListarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Ligacao())
                {
                    var usuarios = db.Usuarios.ToList();
                    lstUsuarios.Items.Clear();
                    foreach (var u in usuarios)
                    {
                        lstUsuarios.Items.Add($"ID: {u.Id}, Nome: {u.NomeUsuario}, Ramal: {u.Ramal}, Especialidade: {u.Especialidade}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInserirMaquina_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaquinaId.Text) || string.IsNullOrEmpty(txtTipo.Text))
                {
                    MessageBox.Show("ID e Tipo são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtMaquinaId.Text);
                string tipo = txtTipo.Text;
                int velocidade = int.Parse(txtVelocidade.Text);
                int hardDisk = int.Parse(txtHardDisk.Text);
                int placaRede = int.Parse(txtPlacaRede.Text);
                int memoriaRam = int.Parse(txtMemoriaRam.Text);
                int usuarioId = string.IsNullOrEmpty(txtUsuarioIdMaquina.Text) ? 0 : int.Parse(txtUsuarioIdMaquina.Text);

                crud.InserirMaquina(id, tipo, velocidade, hardDisk, placaRede, memoriaRam, usuarioId);
                MessageBox.Show("Máquina inserida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCamposMaquina();
                BtnListarMaquinas_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir máquina: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListarMaquinas_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Ligacao())
                {
                    var maquinas = db.Maquinas.Include(m => m.Usuario).ToList();
                    lstMaquinas.Items.Clear();
                    foreach (var m in maquinas)
                    {
                        lstMaquinas.Items.Add($"ID: {m.Id}, Tipo: {m.Tipo}, Usuário: {(m.Usuario != null ? m.Usuario.NomeUsuario : "Nenhum")}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar máquinas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarMaquina_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaquinaId.Text))
                {
                    MessageBox.Show("ID é obrigatório para atualização!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtMaquinaId.Text);

                using (var db = new Ligacao())
                {
                    var maquina = db.Maquinas.Find(id);
                    if (maquina != null)
                    {
                        if (!string.IsNullOrEmpty(txtTipo.Text))
                            maquina.Tipo = txtTipo.Text;
                        if (!string.IsNullOrEmpty(txtVelocidade.Text))
                            maquina.Velocidade = int.Parse(txtVelocidade.Text);
                        if (!string.IsNullOrEmpty(txtHardDisk.Text))
                            maquina.HardDisk = int.Parse(txtHardDisk.Text);
                        if (!string.IsNullOrEmpty(txtPlacaRede.Text))
                            maquina.PlacaRede = int.Parse(txtPlacaRede.Text);
                        if (!string.IsNullOrEmpty(txtMemoriaRam.Text))
                            maquina.MemoriaRam = int.Parse(txtMemoriaRam.Text);
                        if (!string.IsNullOrEmpty(txtUsuarioIdMaquina.Text))
                            maquina.UsuarioId = int.Parse(txtUsuarioIdMaquina.Text);

                        db.SaveChanges();
                        MessageBox.Show("Máquina atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCamposMaquina();
                        BtnListarMaquinas_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Máquina não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar máquina: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarMaquina_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaquinaId.Text))
                {
                    MessageBox.Show("ID é obrigatório para exclusão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(txtMaquinaId.Text);

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir esta máquina?",
                                                   "Confirmar Exclusão",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    crud.DeletarMaquina(id);
                    MessageBox.Show("Máquina excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCamposMaquina();
                    BtnListarMaquinas_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir máquina: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCamposMaquina()
        {
            txtMaquinaId.Clear();
            txtTipo.Clear();
            txtVelocidade.Clear();
            txtHardDisk.Clear();
            txtPlacaRede.Clear();
            txtMemoriaRam.Clear();
            txtUsuarioIdMaquina.Clear();
        }
        private void LimparCamposUsuario()
        {
            txtUsuarioId.Clear();
            txtNomeUsuario.Clear();
            txtPassword.Clear();
            txtRamal.Clear();
            txtEspecialidade.Clear();
        }
    }
}