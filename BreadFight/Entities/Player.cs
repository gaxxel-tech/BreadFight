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
    public partial class Player
    {
        public event Action<Player> die;
        public event Action<int> updateUI;


        private BaseWeapon BaseWeaponInstance;

        private int playerHealthPoints = 20;



        private float attackSpeed = 1f;
        public float AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }
        private bool isAttacking;

        //Getters and setters
        public bool IsAttacking
        {
            get
            {
                return isAttacking;
            }
            set
            {
                isAttacking = value;
            }
        }


        private void CustomInitialize()
        {
            InitializeStats();
            updateUI += HealthBarRuntimeInstance.OnUpdateUI;
            updateUI?.Invoke(playerHealthPoints);
            BaseWeapon newWeapon = Factories.BaseWeaponFactory.CreateNew(WeaponContainer.Position.X, WeaponContainer.Position.Y, WeaponContainer.Z);
            BaseWeaponInstance = newWeapon;
            BaseWeaponInstance.AttachTo(WeaponContainer);
            BaseWeaponInstance.player = this;
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
            int inputDirection = GetKeyJustPressed();

            if(inputDirection > 0)
            {
                
                AttackRight();
                
            }
            else if( inputDirection < 0)
            {
                
                AttackLeft();
            }
            
        }

        private void AttackRight()
        {
            if (!IsAttacking)
            {
                CharacterSkin.FlipHorizontal = false;
                WeaponContainer.Position.Y = -8;
                WeaponContainer.RelativeX = 16;
                BaseWeaponInstance.Attack(GetKeyJustPressed());
            }
            
        }

        private void AttackLeft()
        {
            if (!IsAttacking)
            {
                CharacterSkin.FlipHorizontal = true;
                WeaponContainer.Position.Y = -8;
                WeaponContainer.RelativeX = -16;
                BaseWeaponInstance.Attack(GetKeyJustPressed());
            }
            
        }


        private int GetKeyJustPressed()
        {
            int newInputDirection = 0;

            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                newInputDirection = -1;
            }
            else if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                newInputDirection = 1;
            }

            return newInputDirection;
        }


        public void TakeDamage(int damage)
        {
            if(damage >= playerHealthPoints)
            {
                playerHealthPoints = 0;
                Die();
            }else
            {
                playerHealthPoints -= damage;
            }

            updateUI?.Invoke(playerHealthPoints);
            
        }


        public void Die()
        {
            die.Invoke(this);
            Destroy();
        }

        public void showUI(bool value)
        {
            HealthBarRuntimeInstance.Visible = value;
        }


        private void InitializeStats()
        {
            playerHealthPoints = GlobalData.GlobalData.PlayerHPMax;
            AttackSpeed = GlobalData.GlobalData.PlayerAtkSpeed;
        }

    }
}
