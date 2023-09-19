using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Movement;
using Zenject;
using Config;
using Control;
using Helper;
using Events;

namespace AI{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Timer))]
    public class Pet_1 : Agent,IController,ISubject
    {
        private IRewardHandler rewardHandler;
        private IConfig config;
        private Mover mover;
        private Jumper jumper;


        private Timer timer;
        private List<IObserver> observers = new List<IObserver>();
        
        [Inject]
        private void Init(IConfig config,IRewardHandler rewardHandler){
            this.config = config;
            this.rewardHandler = rewardHandler;
            
        }
        public override void Initialize()
        {
            mover = GetComponent<Mover>();
            jumper = GetComponent<Jumper>();
            timer = GetComponent<Timer>();
            
            base.Initialize();
        }

        

        public void Add(IObserver observer){
            observers.Add(observer);
        }
        public void Remove(IObserver observer){
            observers.Remove(observer);
        }

        private void Invoke(){
            foreach(IObserver observer in observers)
                observer.Notify();
            EndEpisode();
        }
        public override void OnEpisodeBegin()
        {
            ResetPosition();
            mover.ResetVelocity();
        }
        private void ResetPosition(){
           transform.localPosition = new Vector2(UnityEngine.Random.Range(-config.AgentSpawnRange,config.AgentSpawnRange) ,1);
        }
        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.localPosition); //2 floats
            sensor.AddObservation(mover.Velocity.normalized); //2 floats
        }
        public override void OnActionReceived(ActionBuffers actions)
        {
            float x = Mathf.Clamp(actions.ContinuousActions[0],-1,1);
            int jump = actions.DiscreteActions[0];


            Vector2 direction = new Vector2(x, 0);
            mover.Move(direction);
            jumper.Jump(jump);
            
            if(timer.Counter > config.MaxTrainingSteps){
                rewardHandler.HandleReward(this,-1);
                Invoke();
            }
                

            rewardHandler.HandleReward(this,config.ExistentialReward);
        }
        public override void Heuristic(in ActionBuffers actionsOut)
        {
            float x = Input.GetAxis("Horizontal");
            int jump= Input.GetMouseButton(0)? 1:0;

            Vector2 direction = new Vector2(x, 0);
            mover.Move(direction);
            jumper.Jump(jump);
        }

        private void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Collectable")){
                rewardHandler.HandleReward(this,config.CoinCollectReward);
            }
            else if(other.CompareTag("Zone")){
                rewardHandler.HandleReward(this,config.LevelCompleteReward);
                Invoke();
            }
                
        }
    }
}
