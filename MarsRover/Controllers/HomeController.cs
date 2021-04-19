using MarsRover.IRepository;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarsRover.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){}
        readonly IRover Rover;
        public HomeController(IRover rover)
        {
            Rover = rover;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MoveRover(string position, string plateau, string commands)
        {
            position = position.ToUpper();
            commands = commands.ToUpper();
            RoverPositionModel finalPosition = new RoverPositionModel
            {
                X = Convert.ToInt32(position.Substring(0,1)),
                Y = Convert.ToInt32(position.Substring(1,1)),
                Orientation = position.Substring(2,1) == "N" ? Orientations.N : position.Substring(2, 1) == "E" ? Orientations.E : position.Substring(2, 1) == "S" ? Orientations.S : Orientations.W
            };
            PlateauModel plateauModel = new PlateauModel
            {
                X = Convert.ToInt32(plateau.Substring(0,1)),
                Y = Convert.ToInt32(plateau.Substring(1,1))
            };

            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        finalPosition.Orientation = Rover.TurnLeft(finalPosition.Orientation);
                        break;
                    case ('R'):
                        finalPosition.Orientation = Rover.TurnRight(finalPosition.Orientation);
                        break;
                    case ('M'):
                        finalPosition = Rover.Move(finalPosition);
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
            if (Rover.IsRoverInsidePlateau(finalPosition, plateauModel))
            {
                return View("Result",finalPosition);
            }
            ViewBag.Error = "Rover is out of plateau boundaries";
            return View("OutOfBoundaries");
        }
    }
}