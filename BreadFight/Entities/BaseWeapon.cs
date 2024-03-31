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
using FlatRedBall.Gui;
using StateInterpolationPlugin;

namespace BreadFight.Entities
{
    public partial class BaseWeapon
    {

        public Player player;
        private int damage = 1;
        public int Damage { get { return damage; } set { damage = value; } }

        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {

        }

        private void CustomDestroy()
        {

            
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        

        public async void Attack(int direction)
        {
            player.IsAttacking = true;
            float endPos = 1.57f;
            

            if (direction > 0)
            {

                this.Tween(
                    property: "RelativeRotationZ",
                    -endPos,
                    player.AttackSpeed,
                    interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Linear,
                    easing: FlatRedBall.Glue.StateInterpolation.Easing.InOut);

                await TimeManager.DelaySeconds(player.AttackSpeed + 0.1);
            }
            else if(direction < 0)
            {


                this.Tween(
                    property: "RelativeRotationZ",
                    endPos,
                    player.AttackSpeed,
                    interpolation: FlatRedBall.Glue.StateInterpolation.InterpolationType.Linear,
                    easing: FlatRedBall.Glue.StateInterpolation.Easing.InOut);

                await TimeManager.DelaySeconds(player.AttackSpeed + 0.1);
            }

            RelativeRotationZ = 0;
            player.IsAttacking = false;
        }

        public void Move(float positionX, float positionY)
        {
            RelativeX = positionX;
            RelativeY = positionY;
            
        }

    }
}
