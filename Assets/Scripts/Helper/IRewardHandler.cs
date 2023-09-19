using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

namespace Helper{
    public interface IRewardHandler 
    {
        public void HandleReward(Agent agent,float amount);
    }
}