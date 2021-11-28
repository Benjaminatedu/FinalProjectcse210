using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Background : Actor
    {
        public Background()
        {
            SetWidth(Constants.MAX_X);
            SetHeight(Constants.MAX_Y);
            SetPosition(new Point(Constants.MAX_X, Constants.MAX_Y));
            SetVelocity(new Point(0,0));
            SetImage(Constants.IMAGE_BACKGROUND);
        }
    }
}