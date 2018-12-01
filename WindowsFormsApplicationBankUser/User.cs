using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationBankUser
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Password { get; private set; }

        private string password;
        private float balance;

        public User(string name, string password)
        {
            this.Name = name;
            this.password = password;
        }

    }
}
