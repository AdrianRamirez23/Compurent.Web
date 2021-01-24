using Compurent.ADO.Masters.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compurent.ADO.Masters.Models
{
    internal class UserAdminBL
    {
        internal UserAdmin ValidarSesion(string User, string Password)
        {
            return new UserAdminADO().ValidarSesion(User, Password);
        }
        internal string RegistrarUsuario(UserAdmin ussr)
        {
            return new UserAdminADO().RegistrarUsuario(ussr);
        }
    }
}
