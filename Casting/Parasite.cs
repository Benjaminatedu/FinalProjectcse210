using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp
{
    public class Parasite : Actor
    {
        public Parasite()
        {
            SetWidth(Constants.PARASITE_WIDTH);
            SetHeight(Constants.PARASITE_HEIGHT);
            SetPosition(new Point(25,Constants.MAX_Y/2));
            SetImage(Constants.IMAGE_PARASITE);
        }
    }
}