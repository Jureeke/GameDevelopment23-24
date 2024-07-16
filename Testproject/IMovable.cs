using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testproject.Input;

namespace Testproject
{
    internal interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Direction { get; set; }
        public IInputReader inputReader { get; set; }
    }
}
