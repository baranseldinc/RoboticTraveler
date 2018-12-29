using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticTraveler
{
    class RoboticTraveler
    {
        private string InputLocation { get; set; }
        public char OppWay { get; set; }    // Opposite Way
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Surface surface { get; set; }
        private readonly char[] ways = { 'N', 'E', 'S', 'W' };

        public RoboticTraveler(string _inputLocation, Surface _surface)
        {
            InputLocation = _inputLocation;
            surface = _surface;
            TransformInput();
        }

        private void TransformInput()
        {
            string[] inputItems = InputLocation.Split(' ');
            if (inputItems.Length != 3)
            {
                throw new InputException("The Input Location String should be like 'X Y W'"); //W : Way
            }
            else
            {
                try
                {
                    LocationX = Convert.ToInt32(inputItems[0]);
                    LocationY = Convert.ToInt32(inputItems[1]);
                }
                catch (Exception e)
                {
                    throw new InputException("X, Y parameters should only be selected as integer", e);
                }

                if (LocationX > surface.LastX || LocationX < 0 || LocationY > surface.LastY || LocationY < 0)
                    throw new InputException("The Location parameters of RoboticTraveler should be into the Surface Borders");

                try
                {
                    char c = Convert.ToChar(inputItems[2]);
                    if (!(c == 'N' || c == 'E' || c == 'S' || c == 'W'))
                    {
                        throw new InputException("The Way parameter should only be selected as N, E, S, W");
                    }
                    else
                    {
                        OppWay = c;
                    }
                }
                catch (Exception e)
                {
                    throw new InputException("Way parameter must be (N,E,S or W)", e);
                }

            }
        }

        public void TakeActions(string actions)
        {
            char[] actionArray = actions.ToCharArray();
            foreach (char action in actionArray)
            {
                if (!(action == 'L' || action == 'R' || action == 'M'))
                    throw new InputException("Actions string contains only L,R,M keys");
                if (action == 'L')
                    TurnLeft();
                else if (action == 'R')
                    TurnRight();
                else if (action == 'M')
                    Move();
            }
            CheckBorders();
        }

        private void Move()
        {
            if (OppWay == 'N') LocationY++;
            else if (OppWay == 'E') LocationX++;
            else if (OppWay == 'S') LocationY--;
            else if (OppWay == 'W') LocationX--;
        }

        private void TurnRight()
        {
            short wayIndex = CalculateWayIndex();
            wayIndex++;
            if (wayIndex > 3) wayIndex = 0;
            OppWay = ways[wayIndex];
        }

        private void TurnLeft()
        {
            short wayIndex = CalculateWayIndex();
            wayIndex--;
            if (wayIndex < 0) wayIndex = 3;
            OppWay = ways[wayIndex];
        }

        private void CheckBorders()
        {
            if (LocationX > surface.LastX)
                LocationX = surface.LastX;
            else if (LocationX < 0)
                LocationX = 0;

            if (LocationY > surface.LastY)
                LocationY = surface.LastY;
            else if (LocationY < 0)
                LocationY = 0;
        }

        private short CalculateWayIndex()
        {
            short wayIndex = 0;
            if (OppWay == 'N') wayIndex = 0;
            else if (OppWay == 'E') wayIndex = 1;
            else if (OppWay == 'S') wayIndex = 2;
            else if (OppWay == 'W') wayIndex = 3;
            return wayIndex;
        }

        public string GetOutputLocation()
        {
            return LocationX.ToString() + ' ' + LocationY.ToString() + ' ' + OppWay;
        }
    }
}
