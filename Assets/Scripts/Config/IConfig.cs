using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Config{
    public interface IConfig
    {
        public float AgentSpawnRange{get;}
        public int MaxTrainingSteps{get;}

        public float LevelCompleteReward{get;}
        public float CoinCollectReward{get;}
        public float ExistentialReward{get;}

    }
}