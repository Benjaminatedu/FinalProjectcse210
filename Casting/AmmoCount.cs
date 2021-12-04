namespace cse210_batter_csharp.Casting
{
    class Ammo : Actor
    {
        public Ammo(int text)
        {
            SetPosition(new Point(Constants.MAX_X - Constants.AMMO_WIDTH,0));
            SetHeight(Constants.AMMO_HEIGHT);
            SetWidth(Constants.AMMO_WIDTH);
            SetText($"Press F to fire Ammo: {text}");
            SetVelocity(new Point(0,0));
        }
    }
}