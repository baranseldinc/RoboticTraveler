using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticTraveler
{
    class InputException : Exception  // Created to capture errors related to input
    {
        public InputException() { }

        public InputException(string message) : base(message) { }

        public InputException(string message, Exception exc) : base(message, exc) { }
    }
}
