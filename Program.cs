using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create List of Rooms
            List<List<Actor>> roomStructures = new List<List<Actor>>();

            List<List<Actor>> roomEnemies = new List<List<Actor>>();

            //Create Cast List
            Dictionary<string,List<Actor>> cast = new Dictionary<string, List<Actor>>();

            //Create Background
            cast["backgrounds"] = new List<Actor>();

            //Add Backgrounds
            cast["backgrounds"].Add(new Background());

            //Create Lives
            cast["lives"] = new List<Actor>();

            //Add Lives
            for (int i = 0; i < 3; i++)
                cast["lives"].Add(new Heart(i * Constants.HEART_WIDTH, 0));

            //Create Parasite
            cast["parasite"] = new List<Actor>();

            //Add Parasite
            cast["parasite"].Add(new Parasite());

            //Create Enemies
            cast["enemies"] = new List<Actor>();

            //Add Enemies
            for (int i = 0; i < 4; i++)
            {
                roomEnemies.Add(new List<Actor>());
                for (int n = 0; n < 8; n++)
                {
                    Random rnd = new Random();
                    roomEnemies[i].Add(new Enemies(rnd.Next(100, Constants.MAX_X - 100), rnd.Next(100, Constants.MAX_Y - 100)));
                }
            }
            cast["enemies"] = roomEnemies[0];

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(new PhysicsService(),cast);
            script["update"].Add(handleCollisionsAction);

            MoveLocationAction moveLocationAction = new MoveLocationAction(roomEnemies);
            script["update"].Add(moveLocationAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
