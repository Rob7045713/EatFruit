using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace EatFruit
{
    class LevelManager : Sprite
    {
        int level;
        ArrayList barriers;


        public ArrayList getBarriers()
        {
            return barriers;
        }
    }
}
