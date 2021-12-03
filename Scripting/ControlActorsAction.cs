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