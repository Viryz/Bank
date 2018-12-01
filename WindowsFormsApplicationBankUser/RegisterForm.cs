using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplicationBankUser
{
    public partial class RegisterForm : Form
    {
        List<User> users;
        BinaryFormatter bf = new BinaryFormatter();

        public RegisterForm(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            users.Add(new User(textBox1.Text, textBox2.Text));
            this.Close();
        }
    }
}
