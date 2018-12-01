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

namespace WindowsFormsApplicationAdmin
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> operations = new Dictionary<int, string>();
        BinaryFormatter bf = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox1.Text);
                operations.Add(number, textBox2.Text);
                dataGridView1.Rows.Add(operations[number], number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("operations.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, operations);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("operations.dat", FileMode.Open))
                {
                    operations = (Dictionary<int, string>)bf.Deserialize(fs);
                    dataGridView1.Rows.Clear();
                    foreach (KeyValuePair<int, string> item in operations)
                    {
                        dataGridView1.Rows.Add(item.Value, item.Key);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
