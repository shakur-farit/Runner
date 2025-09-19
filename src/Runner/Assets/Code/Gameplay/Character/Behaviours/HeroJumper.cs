using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Factory;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Character.Behaviours
{
  public class HeroJumper : MonoBehaviour
  {
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Hero _hero;

    private IInputService _input;
    private ISoundEffectFactory _soundEffectFactory;

    [Inject]
    public void Construct(IInputService input, ISoundEffectFactory soundEffectFactory)
    {
      _input = input;
      _soundEffectFactory = soundEffectFactory;
    }

    private void Update()
    {
      CheckGround();

      if (_input.GetJumpButtonDown() && _hero.IsGrounded) 
        Jump();
    }

    private void Jump()
    {
      _rigidbody.AddForce(Vector3.up * _hero.JumpForce, ForceMode.Impulse);

      CreateJumpSoundEffect();
    }

    private void CheckGround() => 
	    _hero.IsGrounded = Physics.CheckSphere(groundCheck.position, _hero.GroundCheckRadius, groundLayer);

    private void CreateJumpSoundEffect() => 
      _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Jump, gameObject.transform.position);
  }
}