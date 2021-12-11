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
        public List<List<Actor>> _roomList;
        public int _roomNum = 0;
        public MoveLocationAction(List<List<Actor>> roomList)
        {
            _roomList = roomList;
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if (cast["parasite"].Count > 0)
            {
                Actor parasite = cast["parasite"][0];

                if (parasite.GetX() >= Constants.MAX_X - 15)
                {
                    _roomNum ++;
                    if (_roomNum == 4)
                    {
                        _roomNum = 0;
                        cast["endscreen"].Add(new Endscreen());
                    }
                    parasite.SetPosition(new Point(20,parasite.GetY()));
                }

                if (parasite.GetX() < 15)
                {
                    if(_roomNum != 0)
                    {
                        _roomNum --;
                        parasite.SetPosition(new Point(Constants.MAX_X - 20,parasite.GetY()));
                    }
                }
                cast["enemies"] = _roomList[_roomNum];
            }
        }
    }
}