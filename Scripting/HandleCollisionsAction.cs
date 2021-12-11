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
            audioService.PlaySound(Constants.SOUND_BOUNCE);
            
        }

        public void BounceX(Actor actor)
        {
            actor.SetVelocity(new Point(-actor.GetVelocity().GetX(), actor.GetVelocity().GetY()));
            audioService.PlaySound(Constants.SOUND_BOUNCE);
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> deadZombie = new List<Actor>();
            List<Actor> deadPro = new List<Actor>();
            Actor parasite = cast["parasite"][0];

            List<Actor> oldStructure = new List<Actor>();

            foreach(Actor zombie in cast["enemies"])
            {
            
                if (zombie.GetBottomEdge() >= Constants.MAX_Y)
                {                    
                    BounceY(zombie);
                    zombie.SetImage(Constants.IMAGE_ZOMBIE_BACK);
                }

                if(zombie.GetTopEdge() <= 0)
                {
                    BounceY(zombie);
                    zombie.SetImage(Constants.IMAGE_ZOMBIE);
                }
                
                if (_physicsService.IsCollision(zombie,parasite))
                {
                    if (cast["lives"].Count != 0)
                    {
                        cast["lives"].RemoveAt(cast["lives"].Count - 1);
                        parasite.SetPosition(new Point(parasite.GetX() - 50, parasite.GetY()));
                    }
                        
                    if (cast["lives"].Count == 0)
                    {
                        cast["endscreen"] = new List<Actor>();
                        cast["endscreen"].Add(new Endscreen());
                        cast["endscreen"][0].SetImage(Constants.LOSE_SCREEN_IMAGE);
                    }
                }

                foreach(Actor projectile in cast["projectiles"])
                {
                    if(_physicsService.IsCollision(projectile,zombie))
                    {
                        deadPro.Add(projectile);
                        deadZombie.Add(zombie);
                    }

                    else if (projectile.GetX() >= Constants.MAX_X - 50)
                    {
                        deadPro.Add(projectile);
                    }
                }
            }
            foreach(Actor projectile in deadPro)
            {
                cast["projectiles"].Remove(projectile);
            }
            foreach(Actor zombie in deadZombie)
            {
                cast["enemies"].Remove(zombie);
            }
        }
    }
}
