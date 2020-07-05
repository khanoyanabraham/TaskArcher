using TaskArcher.Prototype.Actions;
using UnityEngine;

namespace TaskArcher.Prototype
{
    public abstract class UnitBase<TMovement, TShooting, TCollision, THealth> : MonoBehaviour
        where TMovement : IMovement where TShooting : IShooting
        where TCollision : ICollision where THealth : IHealth
    {
        protected ActionSigContainer ActioSigStorage = new ActionSigContainer();
        protected TMovement Movement;
        protected TShooting Shooting;
        protected TCollision Collision;
        protected THealth Health;


        public void Start()
        {
            Initialize();
            ActionSigReg();
        }
        public virtual void ActionSigReg()
        {
            ActionSigRegistration();

        }
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        protected virtual void Update()
        {

        }
        protected virtual void FixedUpdate()
        {

        }

        protected virtual void Init(TMovement move, TShooting shoot, THealth health, TCollision col)
        {
            Movement = move;
            Shooting = shoot;
            Health = health;
            Collision = col;
        }

        protected abstract void ActionSigRegistration();
        protected abstract void Initialize();
        protected virtual void OnCollisionEnter(Collision collision)
        {

        }
       
        public void Destory()
        {
            Destroy(this.gameObject);
        }
    }
}
