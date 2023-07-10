using GeradorDeTestes.Dominio.ModuloTeste;

namespace gerador.WinApp.ModuloTeste
{
    public partial class TelaGerarPdfTesteForm : Form
    {
        public TelaGerarPdfTesteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarComboBoxes();
        }

        public void CarregarComboBoxes()
        {
            cmbTestes.Items.Add(TipoTesteEnum.Prova);
            cmbTestes.Items.Add(TipoTesteEnum.Gabarito);
            cmbTestes.SelectedIndex = 0;
        }

        public TipoTesteEnum ObterTipoTeste()
        {
            return (TipoTesteEnum)cmbTestes.SelectedItem;
        }
    }
}
