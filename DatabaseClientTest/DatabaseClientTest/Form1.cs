using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetNumberOfArtists().ToString());
        }
        public int GetNumberOfArtists()
        {
            int numberOfArtists;
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mp3Database"].ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT count(*) from dbo.artist", sqlConnection))
                {
                    numberOfArtists = (int)command.ExecuteScalar();
                }
            }

            return numberOfArtists;
        }
    }
}
