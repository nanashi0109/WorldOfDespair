using Despair.Assets.Architecture._Scripts.Player.Movement;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerModel : MonoBehaviour
    {
        #region Properties
        public bool IsMove { get; set; } = true;

        public float SpeedMovement => _speedMovement;
        public float JumpForce => _jumpForce;
        public Rigidbody2D GetRigidbody => _rigidbody;
        #endregion


        #region Field
        [Header("Movement Data")]
        [SerializeField] private float _speedMovement;
        [SerializeField] private float _jumpForce;
        #endregion

        #region Links
        private Rigidbody2D _rigidbody;

        [SerializeField] private GroundCheck _groundCheck;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerInputSystem _playerInputSystem;
        #endregion

        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _playerInputSystem = new PlayerInputSystem();
            _playerJump = new PlayerJump(this);
            _playerMovement = new PlayerMovement(this, _playerInputSystem);
        }

        private void FixedUpdate()
        {
            if (IsMove)
                _playerMovement.Movement(_rigidbody);
        }

        private void Update()
        {
            _playerInputSystem.UpdateInputSystem();

            if (_playerInputSystem.IsJump)
                _playerJump.Jump(_groundCheck);
        }
    }
}
