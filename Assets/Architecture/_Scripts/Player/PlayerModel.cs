using Despair.Assets.Architecture._Scripts.Player.Movement;
using UnityEngine;

namespace Despair.Assets.Architecture._Scripts.Player
{
    public class PlayerModel : MonoBehaviour
    {
        #region Properties
        public bool IsMove { get; set; } = true;

        public CapsuleCollider2D GetPlayerCollider => _playerCollider;
        public Rigidbody2D GetRigidbody => _rigidbody;
        public Animator GetAnimator => _animator;
        public Vector2 DefaultColliderSize { get { return _defaultColliderSize; } private set { } }
        public Vector2 DefaultColliderOffset { get { return _defaultColliderOffset; } private set { } }
        #endregion


        #region Field
        [Header("Player Data")]
        private Vector2 _defaultColliderSize = new Vector2(0.375f, 1.4f);
        private Vector2 _defaultColliderOffset = new Vector2(0, 1.2f);

        [Header("Movement Data")]
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _jumpForce;
        #endregion

        #region Links
        private Rigidbody2D _rigidbody;
        private CapsuleCollider2D _playerCollider;
        private Animator _animator;

        [SerializeField] private GroundCheck _groundCheck;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerInputSystem _playerInputSystem;
        private PlayerCrouch _playerCrouch;
        private PlayerRoll _playerRoll;
        #endregion

        public void Init()
        {
            _playerCollider = GetComponent<CapsuleCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _playerInputSystem = new PlayerInputSystem();
            _playerJump = new PlayerJump(this);
            _playerMovement = new PlayerMovement(this, _playerInputSystem);
            _playerCrouch = new PlayerCrouch(this);
        }

        private void FixedUpdate()
        {
            if(IsMove)
                _playerMovement.FixedUpdateMovement(_walkingSpeed, _runningSpeed);
        }

        private void Update()
        {
            _playerInputSystem.UpdateInputSystem();


            if(!_groundCheck.IsGround)
                _playerCrouch.Crouch(_playerInputSystem.IsButtonCrouch);

            if (_playerInputSystem.IsButtonJump)
                _playerJump.Jump(_groundCheck, _jumpForce);

            AnimationUpdate();
        }

        private void AnimationUpdate()
        {
            _animator.SetBool("IsRun", _playerInputSystem.IsButtonRun);
            _animator.SetFloat("HorizontalVelocity", Mathf.Abs(_playerMovement.HorizontalVelocity));
            _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
            _animator.SetBool("IsGround", _groundCheck.IsGround);
            _animator.SetBool("IsCrouch", _playerInputSystem.IsButtonCrouch);
        }
    }
}
