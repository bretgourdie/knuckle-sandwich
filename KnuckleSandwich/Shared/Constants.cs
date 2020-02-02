using Nez.Sprites;

namespace KnuckleSandwich.Shared
{
    class Constants
    {
        public const int Height = 600;
        public const int Width = 800;
        public static readonly float Floor = Height - 80;
        public static float FighterOnFloor(SpriteRenderer sprite)
            => FighterOnFloor(sprite.Height);
        public static float FighterOnFloor(float height)
            => Height - 80 - height / 2;
        public const float MoveSpeed = 350f;
    }
}
