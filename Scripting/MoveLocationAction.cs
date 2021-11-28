using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to appropriately handle any collisions in the game.
    /// </summary>
    public class MoveLocationAction : Action
    {
        private int level = 0;
        private Actor _parasite;
        private Actor _prevEnemy;
        private Dictionary<string,List<Actor>> _cast;
        public MoveLocationAction(Dictionary<string,List<Actor>> cast)
        {
            _parasite = cast["parasite"][0];
            _cast = cast;
            _prevEnemy = cast["enemies"][0];
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if(_parasite.GetRightEdge() >= Constants.MAX_X - 15)
            {
                if(level == 0)
                {
                    cast["enemies"].Add(new Enemies(_prevEnemy.GetX() - Constants.ZOMBIE_WIDTH,Constants.MAX_Y / 2));
                    _parasite.SetPosition(new Point(0,_parasite.GetY()));
                    level++;
                }
                else if(level == 1)
                {
                    cast["enemies"].Add(new Enemies(_prevEnemy.GetX() - Constants.ZOMBIE_WIDTH,Constants.MAX_Y / 2));
                    _parasite.SetPosition(new Point(0,_parasite.GetY()));
                }
            }
        }
    }
}