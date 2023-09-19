using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Config;
using AI;
using Zenject;
namespace Helper{
    [RequireComponent(typeof(Pet_1))]
    public class Collector : MonoBehaviour
    {
        private Pet_1 agent;
        private IConfig config;
        private IRewardHandler rewardHandler; 
        
        [Inject]
        private void Init(IConfig config,IRewardHandler rewardHandler){
            this.config = config;
            this.rewardHandler = rewardHandler;
        }
        void Start(){
            agent = GetComponent<Pet_1>();
        }
        private void OnTriggerEnter2D(Collider2D other) {
            ICollectable collectable = other.GetComponent<ICollectable>();
            if(collectable == null) return;
            rewardHandler.HandleReward(agent,config.CoinCollectReward);
            collectable.Collect();
        }
    }
}