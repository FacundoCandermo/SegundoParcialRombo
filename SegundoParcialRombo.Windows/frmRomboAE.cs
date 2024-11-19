using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {

        private Rombo? rombo;
        private readonly Repositorio? _repo;
        public frmRomboAE(Repositorio? repo)
        {
            InitializeComponent();
            _repo = repo;
        }
        public frmRomboAE()
        {
            InitializeComponent();
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (rombo is null)
            {
                rombo = new Rombo();
            }
            rombo.DiagonalMayor = int.Parse(txtDiagonalMayor.Text);
            rombo.DiagonalMenor = int.Parse(txtDiagonalMenor.Text);
            if (rbtSolido.Checked)
                rombo.contornos = Contorno.Solido;
            else if (rbtPunteado.Checked)
                rombo.contornos = Contorno.Punteado;
            else if (rbtRayado.Checked)
                rombo.contornos = Contorno.Rayado;
            else
                rombo.contornos = Contorno.Doble;
            DialogResult = DialogResult.OK;
        }

        private void frmRomboAE_Load(object sender, EventArgs e)
        {

        }
    }
}
