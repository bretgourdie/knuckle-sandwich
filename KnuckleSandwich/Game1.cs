using KnuckleSandwich.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace KnuckleSandwich
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Nez.Core
    {
        public Game1() : base(
            width: 800,
            height: 600,
            windowTitle: "Knuckle Sandwich")
        { }

        protected override void Initialize()
        {
            base.Initialize();

            var gameplayScene = new GameplayScene();

            Core.Scene = gameplayScene;
        }
    }
}
