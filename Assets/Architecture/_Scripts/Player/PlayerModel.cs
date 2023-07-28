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
        public CapsuleCollider2D CrouchCollider => _crouchCollider;
        public CapsuleCollider2D CrawlCollider => _crawlCollider;
        public CapsuleCollider2D RollCollider => _rollCollider;
        #endregion


        #region Field
        [Header("Player Colliders")]
        [SerializeField] private CapsuleCollider2D _crouchCollider;
        [SerializeField] private CapsuleCollider2D _crawlCollider;
        [SerializeField] private CapsuleCollider2D _rollCollider;


        [Header("Movement Data")]
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _runningSpeed;
        [SerializeField] private float _crouchingSpeed;
        [SerializeField] private float _crawlingSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _rollForce;
        [SerializeField] private float _rollCooldown;
        #endregion

        #region Links
        private Rigidbody2D _rigidbody;
        private CapsuleCollider2D _playerCollider;
        private Animator _animator;

        [Header("Links")]
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private CheckingObjectsAbove _checkingObjectsAbove;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerInputSystem _playerInputSystem;
        private PlayerCrouch _playerCrouch;
        private PlayerCrawl _playerCrawl;
        private PlayerRoll _playerRoll;

        #endregion

        public void Init()
        {
            _playerCollider = GetComponent<CapsuleCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _playerInputSystem = new PlayerInputSystem(_checkingObjectsAbove);
            _playerJump = new PlayerJump(this);
            _playerMovement = new PlayerMovement(this, _playerInputSystem);
            _playerCrouch = new PlayerCrouch(this);
            _playerCrawl = new PlayerCrawl(this);
            _playerRoll = new PlayerRoll(this, _playerInputSystem);
        }

        private void FixedUpdate()
        {
            if (_playerRoll.IsRolling) return;

            if (IsMove)
                _playerMovement.FixedUpdateMovement(_walkingSpeed, _runningSpeed, _crawlingSpeed, _crouchingSpeed);
        }

        private void Update()
        {
            AnimationUpdate();
            _playerInputSystem.UpdateInputSystem();

            if (_playerRoll.IsRolling) 
                return;


            if (_groundCheck.IsGround)
            {
                _playerCrouch.Crouch(_playerInputSystem.IsButtonCrouch);
                _playerCrawl.Crawl(_playerInputSystem.IsButtonCrawl);
                StartCoroutine(_playerRoll.RollUpdate(_rollForce, _rollCooldown));
            }
                
            if (_playerInputSystem.IsButtonJump)
            {
                StartCoroutine(_playerJump.Jump(_groundCheck, _jumpForce));
            }
        }

        private void AnimationUpdate()
        {
            _animator.SetBool("IsRun", _playerInputSystem.IsButtonRun);
            _animator.SetFloat("HorizontalVelocity", Mathf.Abs(_playerMovement.HorizontalVelocity));
            _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
            _animator.SetBool("IsGround", _groundCheck.IsGround);
            _animator.SetBool("IsCrouch", _playerInputSystem.IsButtonCrouch);
            _animator.SetBool("IsCrawl", _playerInputSystem.IsButtonCrawl);
        }
    }
}
