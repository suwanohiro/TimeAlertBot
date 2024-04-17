using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Collections.Generic;

namespace TimeAlertBot
{
    public class Application
    {
        public static void Main(string[] args)
        {
            string token = FileAction.Read("token.swn");
        }
    }
}
