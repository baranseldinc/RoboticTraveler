using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticTraveler
{
    class Surface
    {
        public int LastX { get; set; }  //Last Right Coordinate
        public int LastY { get; set; }  //Last Top Coordinate
        private string InputTopRight;

        public Surface(string _inputTopRight)
        {
            InputTopRight = _inputTopRight;
            TransformInput();
        }

        private void TransformInput()
        {
            string[] inputs = InputTopRight.Split(' ');
            if(inputs.Length != 2)
            {
                throw new InputException("The Surface Input must be like 'X Y' ");
            }
            else
            {
                try
                {
                    LastX = Convert.ToInt32(inputs[0]);
                    LastY = Convert.ToInt32(inputs[1]);
                }catch(Exception ex)
                {
                    throw new InputException("X, Y parameters should only be selected as integer", ex);
                }
            }
            
        }
    }
}
