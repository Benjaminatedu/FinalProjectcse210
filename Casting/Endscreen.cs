namespace cse210_batter_csharp.Casting
{
    class Endscreen : Actor
    {
        public Endscreen()
        {
            SetPosition(new Point(0,0));
            SetHeight(Constants.MAX_X);
            SetWidth(Constants.MAX_Y);
            SetImage(Constants.END_SCREEN_IMAGE);
        }
    }
}