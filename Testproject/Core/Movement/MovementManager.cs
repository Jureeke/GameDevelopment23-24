using GameDevProject.Core.Movement;
using Microsoft.Xna.Framework;
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

            movable.Direction = direction;

            if (direction.Y < 0)
            {
                movable.Jump();
            }

            var distance = direction * movable.Speed;
            movable.Position += new Vector2(distance.X, 0);
        }
    }
}
