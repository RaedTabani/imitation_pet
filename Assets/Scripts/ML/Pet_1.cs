using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Movement;
using Zenject;
using Config;
namespace AI{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Jumper))]
    public class Pet_1 : Agent
    {
        private IConfig config;
        private Mover mover;
        private Jumper jumper;
        
        [Inject]
        private void Init(IConfig config){
            this.config = config;
        }
        public override void Initialize()
        {
            mover = GetComponent<Mover>();
            jumper = GetComponent<Jumper>();

            base.Initialize();
        }

        public override void OnEpisodeBegin()
        {
            ResetPosition();
            // mover.ResetVelocity();
            // spawner.Spawn();
        }
        private void ResetPosition(){
           transform.localPosition = new Vector2(UnityEngine.Random.Range(-config.AgentSpawnRange,config.AgentSpawnRange) ,1);
        }
        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.localPosition);
            sensor.AddObservation(mover.Velocity.normalized);
        }
        public override void OnActionReceived(ActionBuffers actions)
        {
            ActionSegment<float> continuousActions = actions.ContinuousActions;
            float x = Mathf.Clamp(continuousActions[0],-1,1);
            int jump = actions.DiscreteActions[0];

            
            // Vector2 direction = new Vector2(x,0);
            // mover.Move(direction);
            // jumper.Jump(jump);
            // rewardPunishmentHandler.Handle(this,configuration.existantialReward);
        }
        public override void Heuristic(in ActionBuffers actionsOut)
        {
            float x = Input.GetAxis("Horizontal");
            int jump= Input.GetMouseButton(0)? 1:0;

            Vector2 direction = new Vector2(x, 0);
            mover.Move(direction);
            jumper.Jump(jump);
        }

        private void OnCollisionEnter(Collision other){
            
        }
    }
}
