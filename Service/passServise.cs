using System;
using System.Collections.Generic;
using System.Text;


namespace Service
{
    public class passServise : IpassServise
    {
        public int Post(string pass)
        {
            return Zxcvbn.Core.EvaluatePassword(pass).Score;
            
        }
    }
}
