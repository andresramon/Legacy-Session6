using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IMap
    {
        bool IsNotLimitEast(int x);

        bool IsNotLimitWest(int x);

        bool IsNotLimitNorth(int y);

        bool IsNotLimitSouth(int y);

    }
}