using System;
using UnityEngine;

namespace Assets.TestArea.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {

        private Rigidbody2D PlayerBody;
        public Rigidbody2D bullet;
        public float Speed { get; set; } = 100;
        public float JumpModifier = 10;
        private bool _isRolling = false;
        private bool _isShooting = false;

        private DateTime? _timeWhenWasLastDodge;
        private readonly double _maxQuantityOfSecondsBetweenDodges = 5;
        public double TotalMilisecondsToWaitForAnotherDodge;

        // Start is called before the first frame update
        void Start()
        {
            PlayerBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && TotalMilisecondsToWaitForAnotherDodge <= 0)
            {
                _isRolling = true;
            }

            if (Input.GetButton("Fire1"))
            {

                _isShooting = true;
            }

            if (_timeWhenWasLastDodge != null)
            {
                TotalMilisecondsToWaitForAnotherDodge = (_timeWhenWasLastDodge.Value - DateTime.Now).TotalMilliseconds;
            }

        }
        
        void DodgeRoll(Vector2 movement)
        {
            

            // measure time between last dodges, if it is 1st dodge of the game then
            // the value is equal to minimum of time to make dodge
            TotalMilisecondsToWaitForAnotherDodge = _timeWhenWasLastDodge != null
                ? (_timeWhenWasLastDodge.Value - DateTime.Now).TotalMilliseconds
                : 0;

            // allow user to make dodge only when the time which
            // passed between 2 dodges is bigger than max quantity of seconds
            if (TotalMilisecondsToWaitForAnotherDodge <= 0)
            {
                PlayerBody.AddForce(movement * JumpModifier);
                _timeWhenWasLastDodge = DateTime.Now.AddSeconds(_maxQuantityOfSecondsBetweenDodges);
                _isRolling = false;
            }
        }

        void handleMovement(Vector2 movement)
        {
            PlayerBody.AddForce(movement);
        }

        void ShootBullet(Vector2 movement)
        {
            Rigidbody2D bulletInstance =
                Instantiate(bullet, transform.position, Quaternion.Euler(new Vector2(0, 1))) as Rigidbody2D;
            _isShooting = false;
 
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);

            handleMovement(movement*Speed);

            if(_isRolling) DodgeRoll(movement*Speed);
            if (_isShooting) ShootBullet(movement * Speed);
        }
    }
}
