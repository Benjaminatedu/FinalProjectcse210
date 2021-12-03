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

        public void BounceY(Actor actor)
        {
            actor.SetVelocity(new Point(actor.GetVelocity().GetX(), - actor.GetVelocity().GetY()));
            
        }

        public void BounceX(Actor actor)
        {
            actor.SetVelocity(new Point(-actor.GetVelocity().GetX(), actor.GetVelocity().GetY()));
            audioService.PlaySound(Constants.SOUND_BOUNCE);
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor parasite = cast["parasite"][0];

            List<Actor> oldStructure = new List<Actor>();

            foreach(Actor enemy in cast["enemies"])
            {
            
                if (enemy.GetBottomEdge() >= Constants.MAX_Y)
                {                    
                    BounceY(enemy);
                    enemy.SetImage(Constants.IMAGE_ZOMBIE_BACK);
                }

                if(enemy.GetTopEdge() <= 0)
                {
                    BounceY(enemy);
                    enemy.SetImage(Constants.IMAGE_ZOMBIE);
                }
                
                foreach(Actor zombie in cast["enemies"])
                {
                    if (_physicsService.IsCollision(zombie,parasite))
                    {
                        cast["lives"].RemoveAt(cast["lives"].Count - 1);
                        parasite.SetPosition(new Point(parasite.GetX() - 50, parasite.GetY()));
                        
                        if (cast["lives"].Count == 0)
                        {
                            cast["parasite"].Clear();
                        }
                    }
                }
            }
        }
    }
}