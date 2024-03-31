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
using FlatRedBall.Audio;

namespace BreadFight.Entities
{
    public partial class BaseEnemy
    {

        public event Action<BaseEnemy> OnDie;
        

        private int direction = 0;
        private float movementSpeed = 60f;
        private int damage = 0;
        public int Damage { get { return damage; } set { damage = value; } }
        private int coinReward = 0;
        public int CoinReward { get { return coinReward; } set { coinReward = value; } }
        private int healthPoints = 1;
        public int HealthPoints { get { return healthPoints; } set { healthPoints = value; } }


        private void CustomInitialize()
        {

        }

        private void CustomActivity()
        {
            HandleMovement();
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }


        private void HandleMovement()
        {
            XVelocity = direction * movementSpeed;
        }

        public void SetDirection(int direction)
        {
            if (direction > 0)
            {
                SpriteInstance.FlipHorizontal = true;
            }
            else if (direction < 0)
            {
                SpriteInstance.FlipHorizontal = false;
            }
            this.direction = direction;
        }

        public void TakeDamage(int damage)
        {
            if(damage >= healthPoints)
            {
                healthPoints = 0;
                Die();
                return;

            }

            healthPoints -= damage;
        }

        public void Die()
        {
            
            AudioManager.Play(RetroBlopDeadSound);
            OnDie.Invoke(this);
            Destroy();
        }

    }
}
