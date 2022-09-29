using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class FlyerRover : IRover
    {
        private IRover Rover;
        public FlyerRover(IRover rover)
        {
            this.Rover = rover;
        }
        public string ProcessMovement(string movements)
        {
            return $"{Rover.ProcessMovement(movements)} Flying";
        }
    }
}