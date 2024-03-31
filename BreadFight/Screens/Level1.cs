using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Gui;
using FlatRedBall.Math;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework;
using BreadFight.Entities;
using BreadFight.GumRuntimes;
using System.Threading.Tasks;
using FlatRedBall.Screens;
using RenderingLibrary;




namespace BreadFight.Screens
{
    public partial class Level1
    {


        public event Action<bool> showUI;


        async void CustomInitialize()
        {
            //camera set
            FlatRedBall.Camera.Main.X = Map.Width / 2.0f;
            FlatRedBall.Camera.Main.Y = -Map.Height / 2.0f;

            
            

            //CameraControllingEntityInstance.Target = PlayerList[0];

            await Task.Delay((int)(1000f));

            Level1Gum.ScreenAnimationsInstance.FadeOutAnimation.Play();

            await Task.Delay((int)(Level1Gum.ScreenAnimationsInstance.FadeOutAnimation.Length * 1000f));

            InitilizeEntitys();
            SetSpawnerLocations();
            SetPlayerToSpawner();
        }

        void CustomActivity(bool firstTimeCalled)
        {


        }

        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }


        private void InitilizeEntitys()
        {
            //Player
            foreach(Player player in PlayerList)
            {
                showUI += player.showUI;

                player.die += OnPlayerDies;
            }
            showUI.Invoke(true);
        }




        private void OnPlayerDies(Player player)
        {
            showUI -= player.showUI;

            GameOver();

        }


        private async void GameOver()
        {

            this.GumScreen.ScreenAnimationsInstance.FadeInAnimation.Play();
            await Task.Delay((int)(GumScreen.ScreenAnimationsInstance.FadeInAnimation.Length * 1000f));

            ScreenManager.MoveToScreen(typeof(MainMenuScreen));
        }


        private void SetSpawnerLocations()
        {
            int index = 0;
            foreach(SpawnPointLocation i in SpawnPointLocationList)
            {
                Spawner.SetSpawnNodes(index, i);
                index++;
            }

            
        }

        public Vector3 GetUICoordinates()
        {
            
            var worldPos = new Vector3();
            
            //Getting GoldUI Pos
            var coinX = Level1Gum.GoldUI.AbsoluteX;
            var coinY = Level1Gum.GoldUI.AbsoluteY;

            MathFunctions.WindowToAbsolute((int)coinX, (int)coinY, ref worldPos);
            
            return worldPos;
        }

        private void SetPlayerToSpawner()
        {
            Spawner.SetPlayer(PlayerList[0]);
        }

        public void CoinUIUpdate()
        {
            Level1Gum.Quantity.Text = GlobalData.GlobalData.Coin.ToString();
        }

    }
}
