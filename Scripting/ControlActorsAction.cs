using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to get user input and update actors accordingly.
    /// </summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;
        private int _ammoCount = 6;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor parasite = cast["parasite"][0];

            Point velocity = direction.Scale(Constants.PARASITE_SPEED);
            parasite.SetVelocity(velocity);

            if (_inputService.IsFReleased() && _ammoCount != 0)
            {
                cast["projectiles"].Add(new Projectile(parasite.GetX(),parasite.GetY(), 25));
                _ammoCount --;
                cast["ammo"][0].SetText($"Ammo: {_ammoCount}");
            }

            if (cast["lives"].Count == 0)
            {
                if (_inputService.IsEnterPressed())
                {
                    cast["parasite"].Clear();
                }
            }
             if (parasite.GetVelocity().GetX() == - Constants.PARASITE_SPEED)
             {
                 parasite.SetImage(Constants.IMAGE_PARASITE_FLIPPED);
             }
             if (parasite.GetVelocity().GetX() == Constants.PARASITE_SPEED)
             {
                 parasite.SetImage(Constants.IMAGE_PARASITE);
             }
        }
    }
}