using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerMovement
    {
        private PlayerModel _playerModel;
        private PlayerInputSystem _playerInputSystem;

        private float _horizontalVelocity;

        public float HorizontalVelocity => _horizontalVelocity;

        public PlayerMovement(PlayerModel playerModel, PlayerInputSystem playerInputSystem)
        {
            _playerModel = playerModel;
            _playerInputSystem = playerInputSystem;
        }
        public void FixedUpdateMovement(float walkSpeed, float runSpeed, float crawlSpeed, float crouchSpeed)
        {
            Movement(walkSpeed, runSpeed, crawlSpeed, crouchSpeed );
            HorizontalFlip();        
        }
        private void Movement(float walkSpeed, float runSpeed, float crawlSpeed, float crouchSpeed)
        {
            float speed = 0;

            if (_playerInputSystem.ButtonRun())
                speed = runSpeed;
            else if (_playerInputSystem.ButtonCrawl())
                speed = crawlSpeed;
            else if ( _playerInputSystem.ButtonCrouch())
                speed = crouchSpeed;
            else
                speed = walkSpeed;

            _horizontalVelocity = _playerInputSystem.GetHorizontalDirection * speed;

            _playerModel.GetRigidbody.velocity = new Vector2(_horizontalVelocity, _playerModel.GetRigidbody.velocity.y);
            
        }

        private void HorizontalFlip()
        {
            var scale = _playerModel.gameObject.transform.localScale;
            if (_horizontalVelocity > 0)
                scale.x = 1;
            else if (_horizontalVelocity < 0)
                scale.x = -1;

            _playerModel.gameObject.transform.localScale = scale;
        }
    }
}
