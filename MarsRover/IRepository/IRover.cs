using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MarsRover.IRepository
{
    public interface IRover
    {
        Orientations TurnLeft(Orientations RoverOrientation);
        Orientations TurnRight(Orientations RoverOrientation);
        RoverPositionModel Move(RoverPositionModel roverPosition);
        bool IsRoverInsidePlateau(RoverPositionModel roverPosition,PlateauModel plateau);

    }
}
