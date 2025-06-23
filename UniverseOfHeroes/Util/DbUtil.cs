using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseOfHeroes.Util
{
    internal static class DbUtil
    {
        // Pode ser expandida para múltiplas configurações no futuro
        public static string ConnectionString { get; } =
            "server=localhost;database=rev;uid=root;pwd=;";
    }
}
