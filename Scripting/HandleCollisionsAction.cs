using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to appropriately handle any collisions in the game.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        AudioService audioService = new AudioService();
        PhysicsService _physicsService = new PhysicsService();

        public HandleCollisionsAction(PhysicsService physicsService,Dictionary<string,List<Actor>> cast)
        {
            _physicsService = physicsService;
        }

        public void BounceY(Actor ball)
        {
            ball.SetVelocity(new Point(ball.GetVelocity().GetX(), - ball.GetVelocity().GetY()));
            
        }

        public void BounceX(Actor ball)
        {
            ball.SetVelocity(new Point(-ball.GetVelocity().GetX(), ball.GetVelocity().GetY()));
            audioService.PlaySound(Constants.SOUND_BOUNCE);
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor parasite = cast["parasite"][0];

            List<Actor> oldStructure = new List<Actor>();

            foreach(Actor enemy in cast["enemies"])
            {
                if (_physicsService.IsCollision(parasite,enemy))
                {
                    cast["parasite"].Remove(parasite);
                }
            
                if (enemy.GetBottomEdge() >= Constants.MAX_Y)
                {                    
                    BounceY(enemy);
                }

                if(enemy.GetTopEdge() <= 0)
                {
                    BounceY(enemy);
                }
            }
        }
    }
}