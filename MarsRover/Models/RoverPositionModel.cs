using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.Models
{
    public class RoverPositionModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientations Orientation { get; set; }
    }
}