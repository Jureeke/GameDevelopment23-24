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

            // Handle jumping
            if (direction.Y < 0)
            {
                movable.Jump();
            }

            // Move only horizontally based on input
            if (direction.X != 0)
            {
                var distance = direction * movable.Speed;
                movable.Position += new Vector2(distance.X, 0);
            }
        }
    }
}
