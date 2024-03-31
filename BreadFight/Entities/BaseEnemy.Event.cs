using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using BreadFight.Entities;
using BreadFight.Entities.Enemies;
using BreadFight.Screens;
namespace BreadFight.Entities
{
    public partial class BaseEnemy
    {
        void OnAfterMobInfoSet (object sender, EventArgs e) 
        {
            this.CoinReward = (int)this.MobInfo.reward;
            this.Damage = (int)this.MobInfo.damage;
            
        }

    }
}
