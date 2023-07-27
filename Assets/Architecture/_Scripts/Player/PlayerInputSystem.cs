using Despair.Assets.Architecture._Scripts.Player.Movement;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerInputSystem
    {
        public float GetHorizontalDirection => _horizontalDirection;
        public bool IsButtonJump { get; private set; }
        public bool IsButtonCrouch { get; private set; }
        public bool IsButtonRun { get; private set; }
        public bool IsButtonCrawl { get; private set; }

        private float _horizontalDirection;

        private CheckingObjectsAbove _checkingObjectsAbove;

        public PlayerInputSystem( CheckingObjectsAbove checkingObjectsAbove)
        {
            _checkingObjectsAbove = checkingObjectsAbove;
        }
        public PlayerInputSystem() { }

        public void UpdateInputSystem()
        {
            HorizontalDir();

            #region Run
            if (Input.GetKeyDown(KeyCode.LeftShift) && _checkingObjectsAbove.IsStandUp)
            {
                IsButtonRun = true;
                IsButtonCrouch = false;
                IsButtonCrawl = false;
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift) || IsButtonCrouch || IsButtonCrawl)
            {
                IsButtonRun = false;
            }
            #endregion

            #region Jump
            if (Input.GetKeyDown(KeyCode.Space) && !IsButtonCrawl && !IsButtonCrouch)
                IsButtonJump = true;
            else 
                IsButtonJump = false;
            #endregion

            if (_checkingObjectsAbove.IsStandUp)
            {
                #region Crouch
                if (Input.GetKeyDown(KeyCode.C) && !IsButtonCrouch)
                {
                    IsButtonCrouch = true;
                    IsButtonCrawl = false;
                }
                else if (Input.GetKeyDown(KeyCode.C) && IsButtonCrouch || IsButtonRun)
                {
                    IsButtonCrouch = false;
                }

                #endregion

                #region Crawl
                if (Input.GetKeyDown(KeyCode.Z)  && !IsButtonCrawl )
                {
                    IsButtonCrawl = true;
                }
                else if (Input.GetKeyDown(KeyCode.Z) && IsButtonCrawl || IsButtonRun)
                {
                    IsButtonCrawl = false;
                }
                #endregion
            }
        }

        private void HorizontalDir()
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
        }
    }
}
