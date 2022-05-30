using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGame.ConsoleGame.Entities.Creatures
{
    internal class Goblin : Creature
    {
        public Goblin(Cell cell, int maxHealth) : base(cell, "G ", maxHealth)
        {
            Damage = 15;
            Color = ConsoleColor.DarkBlue;
        }
    } 
    
    internal class Orc : Creature
    {
        public Orc(Cell cell, int maxHealth) : base(cell, "O ", maxHealth)
        {
            Damage = 40;
            Color = ConsoleColor.DarkGreen;
        }
    }
    
    internal class Troll : Creature
    {
        public Troll(Cell cell, int maxHealth) : base(cell, "T ", maxHealth)
        {
            Damage = 30;
            Color = ConsoleColor.DarkYellow;
        }
    }
}
