using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineManager.Services
{
    public class EmailConfirmacao
    {
        //definidos nos comandos do user secret manager do powershell
        public string UserSendGrid { get; set; }
        public string KeySendGrid { get; set; }
    }
}
