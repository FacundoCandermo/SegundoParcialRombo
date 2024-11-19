using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {
        private Repositorio? repositorio;
        private int cantidadRegistros;
        private List<Rombo>? rombo;
        public frmRombos()
        {
            InitializeComponent();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
        }


        private void tsbBorrar_Click(object sender, EventArgs e)
        {
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
        }


        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(Contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }


        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);
            cantidadRegistros = repositorio!.GetCantidad();
            if (cantidadRegistros > 0)
            {
                rombo = repositorio.ObtenerRombo();
                MostrarDatosGrilla();
                MostrarCantidadRegistros();
            }
        }
        private void MostrarDatosGrilla()
        {
            LimpiarGrilla(dgvDatos);
            foreach (var item in rombo!)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r, dgvDatos);
            }
        }

        private void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }
        public void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        public void SetearFila(DataGridViewRow r, Rombo obj)
        {
            r.Cells[0].Value = obj.DiagonalMayor;
            r.Cells[1].Value = obj.DiagonalMenor;
            r.Cells[2].Value = obj.contornos.ToString();
            r.Cells[3].Value = obj.CalcularArea().ToString("N2");
            r.Cells[5].Value = obj.CalcularPerimetro().ToString("N2");

            r.Tag = obj;
        }
        public DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }
        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            frmRomboAE frm = new frmRomboAE() { Text = "Agregar Rombo" };
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                if (!repositorio!.Existe(rombo))
                {
                    repositorio.AgregarRombo(rombo!);
                    DataGridViewRow r = ConstruirFila(dgvDatos);
                    SetearFila(r, rombo!);
                    AgregarFila(r, dgvDatos);
                    MessageBox.Show("Registro agregado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("Registro existente!!!", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
                 catch (Exception)
            {

                MessageBox.Show("Algún error!!!", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbSalir_Click_1(object sender, EventArgs e)
        {
            repositorio.GuardarDatos();
            MessageBox.Show("Fin del Programa", "Mensaje",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
        public List<Rombo> ObtenerRombo()
        {
            return new List<Rombo>(rombo);
        }

        private void MostrarCantidadRegistros()
        {
            txtCantidad.Text = cantidadRegistros.ToString();
        }
    }
}
