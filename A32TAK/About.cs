using System.Reflection;

namespace A32TAK
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        private void About_Load(object sender, EventArgs e)
        {
            lblVersionV.Text = Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.ToString();
        }
    }
}