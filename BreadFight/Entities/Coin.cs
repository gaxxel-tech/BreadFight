using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using FlatRedBall.Screens;
using BreadFight.Screens;
using StateInterpolationPlugin;
using FlatRedBall.Math;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using RenderingLibrary;
using BreadFight.GumRuntimes;

namespace BreadFight.Entities
{
    public partial class Coin
    {

        private int coinQuantity = 0;
        public int CoinQuantity { get { return coinQuantity; } set { coinQuantity = value; } }

        private async void CustomInitialize()
        { 
            
            await Task.Delay(2000);
            CreateGumCoin();
            
        }

        private void CustomActivity()
        {
            

        }

        private void CustomDestroy()
        {
            


            this.RemoveFromManagers();
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {
            

        }

        public Vector2 GetGumCoordinates(float worldX, float worldY)
        {
            var camera = FlatRedBall.Camera.Main;
            camera.WorldToScreen(worldX, worldY, 1, out int screenX, out int screenY);
            var gumZoom = SystemManagers.Default.Renderer.Camera.Zoom;
            return new Vector2(screenX, screenY) / gumZoom;
        }

        public void CreateGumCoin()
        {
            Level1 screen = (Level1)ScreenManager.CurrentScreen;


            var worldCoordinatesX = Position.X;
            var worldCoordinatesY = Position.Y;

            var gumCoordinates = GetGumCoordinates(worldCoordinatesX, worldCoordinatesY);

            var coinGum = new CoinEntityGumRuntime();
            coinGum.X = gumCoordinates.X;
            coinGum.Y = gumCoordinates.Y;
            coinGum.Target = new Vector3(19, 17, 1);
            coinGum.reward = CoinQuantity;
            coinGum.AddToManagers();
            coinGum.animate(coinGum.Target.X, coinGum.Target.Y);
            Destroy();
        }

    }
}
