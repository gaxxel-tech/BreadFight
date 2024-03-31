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
using System.Threading.Tasks;
using FlatRedBall.Audio;
using BreadFight.GlobalData;


namespace BreadFight.Screens
{


    

    public partial class MainMenuScreen
    {

        void CustomInitialize()
        {
            InitializeShopScreen();
            

            AudioManager.PlaySong(LetsgoTheme, true, true);

            MainMenuScreenGum.MainMenuScreenComponentInstance.StartGameButton.Click += async (startbuttonclicked) => {

                BeginAnimation();
                await Task.Delay((int)(this.GumScreen.ScreenAnimationsInstance.FadeInAnimation.Length * 1000));
                this.MoveToScreen(typeof(Level1)); };

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

        void BeginAnimation()
        {
            this.GumScreen.ScreenAnimationsInstance.FadeInAnimation.Play();
            
        }

        void OpenShopMenu(IWindow window)
        {
            this.GumScreen.OpenMenuAnimation.Play();
            UpdateShopUI();
        }

        void CloseShopMenu(IWindow window)
        {
            this.GumScreen.CloseMenuAnimation.Play();
        }


        void InitializeShopScreen()
        {
            MainMenuScreenGum.MainMenuScreenComponentInstance.ShopBtn.Click += OpenShopMenu;
            MainMenuScreenGum.ShopMenuInstance.BackBtn.Click += CloseShopMenu;


            MainMenuScreenGum.ShopMenuInstance.HPUpgradeBtn.Click += (IncrementHP) =>
            {
                if(GlobalData.GlobalData.Coin < 5)
                {
                    return;
                }
                GlobalData.GlobalData.Coin -= 5;
                GlobalData.GlobalData.PlayerHPMax++;
                UpdateShopUI();
            };
            MainMenuScreenGum.ShopMenuInstance.AtkSpeedUpgradeBtn.Click += (IncrementAtkSpeed) =>
            {

                if (GlobalData.GlobalData.Coin < 20)
                {
                    return;
                }
                GlobalData.GlobalData.Coin -= 20;
                GlobalData.GlobalData.PlayerAtkSpeed -= 0.1f;
                UpdateShopUI();
            };

        }


        void UpdateShopUI()
        {
            MainMenuScreenGum.ShopMenuInstance.CurrentGold.Text = GlobalData.GlobalData.Coin.ToString();
            MainMenuScreenGum.ShopMenuInstance.HPValue.Text = GlobalData.GlobalData.PlayerHPMax.ToString();
            MainMenuScreenGum.ShopMenuInstance.AtkSpeedValue.Text = GlobalData.GlobalData.PlayerAtkSpeed.ToString();
            MainMenuScreenGum.ShopMenuInstance.RegenValue.Text = GlobalData.GlobalData.PlayerHPMax.ToString();
        }

    }
}
