using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        public string Greet(params string[] name)
        {
            return $"Hello, {name[0]}.";
        }
    }
}
