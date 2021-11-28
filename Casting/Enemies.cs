using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    class Enemies : Actor
    {
        public Enemies(int x, int y)
        {
            Random rnd = new Random();
            //SetImage(Constants.IMAGE_ZOMBIE);
            SetHeight(Constants.ZOMBIE_HEIGHT);
            SetWidth(Constants.ZOMBIE_WIDTH);
            SetPosition(new Point(x, y));
            SetVelocity(new Point(0, 10));
        }
    }
}