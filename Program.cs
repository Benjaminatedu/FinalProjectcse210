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
            List<Dictionary<string,List<Actor>>> roomStructures = new List<Dictionary<string, List<Actor>>>();

            //Create Cast List
            Dictionary<string,List<Actor>> cast = new Dictionary<string, List<Actor>>();

            //Create Background
            cast["backgrounds"] = new List<Actor>();

            //Add Backgrounds
            cast["backgrounds"].Add(new Background());

            //Create Parasite
            cast["parasite"] = new List<Actor>();

            //Add Parasite
            cast["parasite"].Add(new Parasite());

            //Create Buildings
            cast["buildings"] = new List<Actor>();

            //Create Enemies
            cast["enemies"] = new List<Actor>();

            //Add Enemies
            cast["enemies"].Add(new Enemies(Constants.MAX_X/2,Constants.CABIN_1_HEIGHT + 10));

 
 
 
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

            MoveLocationAction moveLocationAction = new MoveLocationAction(cast);
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
