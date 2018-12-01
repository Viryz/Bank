using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplicationBankUser
{
    public partial class Form1 : Form
    {
        List<User> userList;
        BinaryFormatter bf = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("users.dat", FileMode.Open))
                {
                    userList = (List<User>)bf.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Users not exist");
                userList = new List<User>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = userList.Find((u) => u.Name == textBox1.Text);
            if (user != null)
            {
                if (user.Password == textBox2.Text)
                {
                    MainForm mf = new MainForm(user);
                    mf.ShowDialog();
                }
                else MessageBox.Show("Wrong password");
            }
            else
            {
                MessageBox.Show("This user not exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm(userList);
            rf.ShowDialog();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, userList);
            }
            
        }
    }
}
