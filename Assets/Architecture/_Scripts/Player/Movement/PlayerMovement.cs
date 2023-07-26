using UnityEngine;
using Despair.Assets.Architecture._Scripts.Player;
using System.Data;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerMovement
    {
        private PlayerModel _playerModel;
        private PlayerInputSystem _playerInputSystem;

        private float _horizontalVelocity;

        public bool IsWalk { get; private set; }
        public bool IsRun { get; private set; }
        public float HorizontalVelocity => _horizontalVelocity;

        public PlayerMovement(PlayerModel playerModel, PlayerInputSystem playerInputSystem)
        {
            _playerModel = playerModel;
            _playerInputSystem = playerInputSystem;
        }
        public void FixedUpdateMovement()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsRun = true;
                IsWalk = false;
            }
            else
            {
                IsRun = false;
                IsWalk = true;
            }



            Movement();
            HorizontalFlip();        
        }
        private void Movement()
        {
            if (IsWalk)
                _horizontalVelocity = _playerInputSystem.GetHorizontalDirection * _playerModel.WalkingSpeed;
            else if (IsRun)
                _horizontalVelocity = _playerInputSystem.GetHorizontalDirection * _playerModel.RunningSpeed;

            _playerModel.GetRigidbody.velocity = new Vector2(_horizontalVelocity, _playerModel.GetRigidbody.velocity.y);
            
        }

        private void HorizontalFlip()
        {
            var scale = _playerModel.gameObject.transform.localScale;
            if (_horizontalVelocity > 0)
            {
                scale.x = 1;
                Debug.Log(1);
            }
            else if (_horizontalVelocity < 0)
            {
                scale.x = -1;
                Debug.Log(-1);
            }
            _playerModel.gameObject.transform.localScale = scale;
        }
    }
}
