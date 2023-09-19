using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
namespace Helper{
    public class RewardHandler : IRewardHandler
    {
        public void HandleReward(Agent agent, float amount){
            agent.AddReward(amount);
            //Debug.Log($"Reward Added {amount}");
        }
    }
}