
namespace cse210_batter_csharp.Casting
{
    class Heart : Actor
    {
        public Heart(int x, int y)
        {
            SetImage(Constants.HEART_IMAGE);
            SetPosition(new Point(x,y));
            SetHeight(Constants.HEART_HEIGHT);
            SetWidth(Constants.HEART_WIDTH);
            SetVelocity(new Point(0,0));
        }
    }
}