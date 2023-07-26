using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerInputSystem
    {
        public float GetHorizontalDirection => _horizontalDirection;
        public bool IsButtonJump { get; private set; }
        public bool IsButtonCrouch { get; private set; }
        public bool IsButtonRun { get; private set; }

        private float _horizontalDirection;

        public void UpdateInputSystem()
        {
            HorizontalDir();

            #region Run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsButtonRun = true;
                IsButtonCrouch = false;
            }
            else
            {
                IsButtonRun = false;
            }
            #endregion

            #region Jump
            if (Input.GetKeyDown(KeyCode.Space))
                IsButtonJump = true;
            else
                IsButtonJump = false;
            #endregion

            #region Crouch
            if (Input.GetKeyDown(KeyCode.C) && !IsButtonRun)
                IsButtonCrouch = true;
            else if (Input.GetKeyUp(KeyCode.C))
                IsButtonCrouch = false;
            #endregion
        }

        private void HorizontalDir()
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
        }
    }
}
