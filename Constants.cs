using System;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 1000;
        public const int MAX_Y = 900;
        public const int FRAME_RATE = 30;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;
        public const string IMAGE_TWO_BARRELS = "./Assets/two-barrels.png";
        public const string IMAGE_CABIN_1 = "./Assets/cabin1-png.png";
        public const string IMAGE_BARREL_GROUP = "./Assets/barrel-group.png";

        public const string IMAGE_PARASITE = "./Assets/parasite.png";
        public const string IMAGE_PARASITE_FLIPPED = "./Assets/parasite-flipped.png";
        public const string IMAGE_ZOMBIE = "./Assets/zombie.png";
        public const string IMAGE_ZOMBIE_BACK = "./Assets/zombie-back.png";
        public const string IMAGE_BACKGROUND = "./Assets/brick-background.png";

        public const string SOUND_START = "./Assets/start.wav";
        public const string SOUND_BOUNCE = "./Assets/boing.wav";
        public const string SOUND_OVER = "./Assets/over.wav";

        public const int PARASITE = MAX_X / 2;
        public const int PARASITE_Y = MAX_Y - 25;

        public const int TWO_BARREL_WIDTH = 96;
        public const int TWO_BARREL_HEIGHT = 64;

        public const int BARREL_GROUP_WIDTH = 225;
        public const int BARREL_GROUP_HEIGHT = 113;

        public const int CABIN_1_WIDTH = 180;
        public const int CABIN_1_HEIGHT = 180;

        public const int BRICK_SPACE = 5;

        public const int PADDLE_SPEED = 15;

        public const int PARASITE_WIDTH = 73;
        public const int PARASITE_HEIGHT = 40;

        public const int ZOMBIE_WIDTH = 55;
        public const int ZOMBIE_HEIGHT = 88;
    }

}