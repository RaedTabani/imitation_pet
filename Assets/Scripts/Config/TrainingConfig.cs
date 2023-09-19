using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Config{
    public class TrainingConfig : IConfig
    {
        public float AgentSpawnRange{get=>3;}
        public int MaxTrainingSteps{get=>5000;}
        public float LevelCompleteReward{get=>1;}
        public float CoinCollectReward{get=>.1f;}
        public float ExistentialReward{get=>-.005f;}

    }
}