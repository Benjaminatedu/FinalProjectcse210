using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    class Buildings : Actor
    {
        public Buildings(int x, int y)
        {
            SetHeight(Constants.CABIN_1_HEIGHT);
            SetWidth(Constants.CABIN_1_WIDTH);
            SetPosition(new Point(x * Constants.CABIN_1_WIDTH + 5,y));
        }
    }
}