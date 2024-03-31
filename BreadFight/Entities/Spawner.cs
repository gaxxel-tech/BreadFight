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
using BreadFight.Screens;
using FlatRedBall.Utilities;
using BreadFight.Entities.Enemies;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace BreadFight.Entities
{
    public partial class Spawner
    {

        


        //private List<BaseEnemyType> enemyTypes = new List<BaseEnemyType>();
        private List<BaseEnemyType> enemyForSpawn = new List<BaseEnemyType>();
        private SpawnPointLocation[] spawnNodes = new SpawnPointLocation[2];
        private Player player;

        private int currentWaveLevel = 1;
        public int CurrentWaveLevel { get { return currentWaveLevel; } set { currentWaveLevel = value; } }
        
        private int enemiesToNextLevel = 5;
        public int EnemiesToNextLevel { get { return enemiesToNextLevel; } set { enemiesToNextLevel = value; } }

        private string currentEnemyToNextLevel = null;
        public string CurrentEnemyToNextLevel { get { return currentEnemyToNextLevel; } set { currentEnemyToNextLevel = value; } }

        private double time = 0f;
        private bool isTimeToSpawn
        {
            get
            {
                float spawnFrequency = 1 / SpawnMobRate;
                return TimeManager.CurrentScreenSecondsSince(time) > spawnFrequency;
            }
        }

        private void CustomInitialize()
        {
            InitializeEnemyList();

        }

        private void CustomActivity()
        {
           
            if(isTimeToSpawn)
            {
                
                PerformSpawn();
            }

        }

        private void CustomDestroy()
        {
            

        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void PerformSpawn()
        {
            Vector3 position = SelectSpawnPoint();
            int direction = 0;

            if(position.X > player.Position.X)
            {
                direction = -1;
            }
            else if(position.X < player.Position.X)
            {
                direction = 1;
            }

            
            var random = FlatRedBallServices.Random.In(enemyForSpawn);

            var newEnemy = random.CreateNew();
            newEnemy.Position = position;
            newEnemy.SetDirection(direction);

            time = TimeManager.CurrentScreenTime;
            SpawnMobRate += SpawnRateIncreasing;
            newEnemy.OnDie += OnMobDeath;
            
            
        }


        private Vector3 SelectSpawnPoint()
        {
            Vector3 position = new Vector3();
            int index = FlatRedBallServices.Random.Next(0, spawnNodes.Length);
            position = spawnNodes[index].Position;
            position.Z = 1;
            return position;
        } 


        public void SetSpawnNodes(int indexPosition, SpawnPointLocation spawnNode)
        {
            this.spawnNodes[indexPosition] = spawnNode; 
        }


        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void InitializeEnemyList()
        {
            AddNewEnemyForSpawn();

        }


        //Get all enemies and select and add those to add for the current lvl spawnable
        private void AddNewEnemyForSpawn()
        {
            List<BaseEnemyType> enemyList = new List<BaseEnemyType>();
            enemyList = BaseEnemyType.All;
            foreach(BaseEnemyType enemy in enemyList)
            {
                if (enemy.MobInfo.enemyLevel == CurrentWaveLevel)
                {
                    enemyForSpawn.Add(enemy);
                    currentEnemyToNextLevel = enemy.MobInfo.ID;
                }
            }
        }

        private void LevelUpSpawn()
        {
            CurrentWaveLevel++;
            AddNewEnemyForSpawn();
        }

        private void CheckLevel()
        {
            if(enemiesToNextLevel <= 0)
            {
                LevelUpSpawn();
                EnemiesToNextLevel = 5;
            }
        }

        private void OnMobDeath(BaseEnemy mob)
        {
            if(mob.MobInfo.ID == CurrentEnemyToNextLevel)
            {
                EnemiesToNextLevel--;
                CheckLevel();
                
            }

            mob.OnDie -= OnMobDeath;

        }
    }
}
