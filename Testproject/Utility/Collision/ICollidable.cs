using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testproject.Utility.Collision
{
    public interface ICollidable
    {
        public Rectangle HitBox { get; set; }
    }
}
