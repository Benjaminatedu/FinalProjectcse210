namespace cse210_batter_csharp.Casting
{
    class Projectile : Actor
    {
        public Projectile(int x, int y, int xVel)
        {
            SetImage(Constants.PROJECTILE_IMAGE);
            SetPosition(new Point(x,y));
            SetHeight(10);
            SetWidth(10);
            SetVelocity(new Point(xVel,0));
        }
    }
}