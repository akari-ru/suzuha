using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace suzuha.moth
{
    class Account
    {
        public string Id { get; }
        public string Name { get; }
        public string Mail { get; }

        private bool IsMailValid()
        {
            if (Mail != null)
            {
                if (Mail.Contains("@"))
                    return true;
            }
            return false;
        }
        
        private bool IsNameValid()
        {
            if (Name.Length < 12)
            {
                return true;
            }
            return false;
        }
    }
}
