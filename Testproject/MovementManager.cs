using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.inputReader.Readinput();

            movable.Direction = movable.inputReader.Readinput();

            var afstand = direction * movable.Speed;
            movable.Position += afstand;
        }
    }
}
