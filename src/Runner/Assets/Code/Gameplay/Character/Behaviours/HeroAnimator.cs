using UnityEngine;

namespace Code.Infrastructure.Installers
{
  public class HeroAnimator : MonoBehaviour
  {
    [SerializeField] private Animator _animator;

    private readonly int _isMoving = Animator.StringToHash("isMoving");

    public void StartIdling() => _animator.SetBool(_isMoving, false);
    public void StartMoving() => _animator.SetBool(_isMoving, true);
  }
}