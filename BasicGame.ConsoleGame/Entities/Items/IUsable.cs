using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGame.ConsoleGame.Entities.Items
{
    internal interface IUsable
    {
        void Use(Creature creature);
    }
}
