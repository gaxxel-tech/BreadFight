using FlatRedBall.Glue.StateInterpolation;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StateInterpolationPlugin;
using FlatRedBall;
using FlatRedBall.Math;
using FlatRedBall.Screens;
using BreadFight.Screens;

namespace BreadFight.GumRuntimes
{
    public partial class CoinEntityGumRuntime
    {
        public event Action UpdateUI;

        public Vector3 Target;
        public int reward = 0;
        partial void CustomInitialize () 
        {
            Level1 screen = (Level1)ScreenManager.CurrentScreen;
            UpdateUI += screen.CoinUIUpdate;
            
        }

        public async void animate(float targetPosX, float targetPosY)
        {

            TweenerManager.Self.TweenAsync(
              owner: this,
              assignmentAction: (newValue) => Y = newValue,
              from: Y,
              to: targetPosX,
              during: 1, // seconds
              interpolation: InterpolationType.Quadratic,
              easing: Easing.Out);
            await TweenerManager.Self.TweenAsync(
              owner: this,
              assignmentAction: (newValue) => X = newValue,
              from: X,
              to: targetPosY,
              during: 1, // seconds
              interpolation: InterpolationType.Quadratic,
              easing: Easing.Out);
            GlobalData.GlobalData.Coin += reward;
            UpdateUI?.Invoke();
            Level1 screen = (Level1)ScreenManager.CurrentScreen;
            UpdateUI -= screen.CoinUIUpdate;
            this.RemoveFromManagers();
            Destroy();
        }


    }
}
