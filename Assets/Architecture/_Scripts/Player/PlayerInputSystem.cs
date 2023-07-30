using Despair.Assets.Architecture._Scripts.Player.Movement;
using System.Threading;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerInputSystem
    {
        public float GetHorizontalDirection => _horizontalDirection;

        private bool _isButtonJump;
        private bool _isButtonCrouch;
        private bool _isButtonRun;
        private bool _isButtonCrawl;
        private bool _isButtonAttack;

        public bool _isButtonRoll { get;  set; }

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

            ButtonRun();
            ButtonCrouch();
            ButtonCrawl();

            if (!_checkingObjectsAbove.IsStandUp)
            {
                _isButtonCrawl = true;
                _isButtonRun = false;
            }

        }

        public bool ButtonRun()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _checkingObjectsAbove.IsStandUp)
            {
                _isButtonRun = true;
                _isButtonCrouch = false;
                _isButtonCrawl = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || _isButtonCrouch || _isButtonCrawl)
            {
                _isButtonRun = false;
            }

            return _isButtonRun;
        }

        public bool ButtonJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_isButtonCrawl)
            {
                _isButtonJump = true;
                _isButtonCrouch = false;
            }
            else
            {
                _isButtonJump = false;
            }

            return _isButtonJump;
        }

        public bool ButtonCrouch()
        {
            if (Input.GetKeyDown(KeyCode.C) && !_isButtonCrouch)
            {
                _isButtonCrouch = true;
                _isButtonCrawl = false;
            }
            else if (Input.GetKeyDown(KeyCode.C) && _isButtonCrouch || _isButtonRun)
            {
                if (_checkingObjectsAbove.IsStandUp)
                    _isButtonCrouch = false;
            }

            return _isButtonCrouch;
        }

        public bool ButtonCrawl()
        {
            if (Input.GetKeyDown(KeyCode.Z) && !_isButtonCrawl)
            {
                _isButtonCrawl = true;
            }
            else if (Input.GetKeyDown(KeyCode.Z) && _isButtonCrawl || _isButtonRun)
            {
                if (_checkingObjectsAbove.IsStandUp)
                    _isButtonCrawl = false;
            }

            return _isButtonCrawl;
        }

        public bool ButtonRoll()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && !_isButtonCrawl)
            {
                _isButtonRoll = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                _isButtonRoll = false;
            }

            return _isButtonRoll;
        }

        public bool ButtonAttack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isButtonAttack = true;
            }
            else
            {
                _isButtonAttack = false;
            }

            return _isButtonAttack;
        }

        private void HorizontalDir()
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
        }
    }
}
