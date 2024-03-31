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

namespace BreadFight.Entities
{
    public partial class CameraMan
    {
        
        Player player;
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

        public void FollowEntity(Player player)
        {
            this.player = player;
            CameraControllingEntityInstance.Target = player;
        }
    }
}