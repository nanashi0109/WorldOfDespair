using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerInputSystem
    {
        public float GetHorizontalDirection => _horizontalDirection;
        public bool IsJump => _isJump;

        private float _horizontalDirection;
        private bool _isJump;

        public void UpdateInputSystem()
        {
            _horizontalDirection = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                _isJump = true;
            else
                _isJump = false;
        }
    }
}
