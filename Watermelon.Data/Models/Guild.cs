using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Data.Models
{
    public class Guild
    {
        public ulong Id { get; set; }
        public string Prefix { get; set; } = "!";
    }
}
