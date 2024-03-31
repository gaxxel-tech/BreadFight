using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using BreadFight.Entities;
using BreadFight.Screens;
using FlatRedBall.Entities;
namespace BreadFight.Screens
{
    public partial class GameScreen
    {

  
        void OnPlayerVsBaseEnemyCollisionOccurred (Entities.Player player, Entities.BaseEnemy baseEnemy) 
        {
            player.TakeDamage(baseEnemy.Damage);
        }
        void OnBaseWeaponVsBaseEnemyCollided (Entities.BaseWeapon baseWeapon, Entities.BaseEnemy baseEnemy) 
        {
            baseEnemy.TakeDamage(baseWeapon.Damage);

            Coin newCoin = Factories.CoinFactory.CreateNew(baseEnemy.Position.X, baseEnemy.Position.Y);
            newCoin.CoinQuantity = baseEnemy.CoinReward;



        }
        
    }
}
