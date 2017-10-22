using MySql.Data.MySqlClient;
using System.Configuration;

namespace InformationStabilityLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once InheritdocConsiderUsage
    public partial class MainWindow
    {
        private MySqlConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Connect();
        }

        private void Connect()
        {
            try
            {
                Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
                Connection.Open();
                LabelStatus.Content = "Connected successfully";
            }
            catch
            {
                Connection.Close();
                LabelStatus.Content = "Cannot connect";
            }
        }
    }
}
