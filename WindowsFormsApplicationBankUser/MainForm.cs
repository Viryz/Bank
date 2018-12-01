using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationBankUser
{
    public partial class MainForm : Form
    {
        User user;
        Dictionary<int, string> operations;

        BinaryFormatter bf = new BinaryFormatter();

        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("operations.dat", FileMode.Open))
                {
                    operations = (Dictionary<int, string>)bf.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (KeyValuePair<int, string> item in operations)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.DisplayMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
