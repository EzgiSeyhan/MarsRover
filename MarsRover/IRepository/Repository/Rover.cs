using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.IRepository.Repository
{
    public class Rover : IRover
    {
        public Orientations TurnLeft(Orientations RoverOrientation)
        {
            RoverOrientation = (RoverOrientation - 1) < Orientations.N ? Orientations.W : (RoverOrientation - 1);
            return RoverOrientation;
        }

        public Orientations TurnRight(Orientations RoverOrientation)
        {
            RoverOrientation = (RoverOrientation + 1) > Orientations.W ? Orientations.N : RoverOrientation + 1;
            return RoverOrientation;
        }

        public RoverPositionModel Move(RoverPositionModel roverPosition)
        {
            if (roverPosition.Orientation == Orientations.N)
            {
                roverPosition.Y++;
            }
            else if (roverPosition.Orientation == Orientations.E)
            {
                roverPosition.X++;
            }
            else if (roverPosition.Orientation == Orientations.S)
            {
                roverPosition.Y--;
            }
            else if (roverPosition.Orientation == Orientations.W)
            {
                roverPosition.X--;
            }
            return new RoverPositionModel
            {
                X = roverPosition.X,
                Y = roverPosition.Y,
                Orientation = roverPosition.Orientation
            };
        }

        public bool IsRoverInsidePlateau(RoverPositionModel roverPosition, PlateauModel plateau)
        {
            bool isInside = false;
            if (roverPosition.X < plateau.X || roverPosition.Y < plateau.Y)
                isInside = true;
            return isInside;
        }
    }
}