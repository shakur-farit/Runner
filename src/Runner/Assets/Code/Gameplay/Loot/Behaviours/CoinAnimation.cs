using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Gameplay.Loot.Behaviours
{
  public class CoinAnimation : MonoBehaviour
  {
    [SerializeField] private Loot _loot;

    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float jumpDuration = 0.5f;

    private void OnEnable() =>
      _loot.Pickedup += AnimatePickedup;

    private void OnDisable()
    {
      _loot.Pickedup -= AnimatePickedup;

      transform.DOKill();
    }


    private void Start() =>
      SpinCoin();

    private void SpinCoin()
    {
      transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear);
    }

    private async void AnimatePickedup()
    {
      Vector3 startPos = transform.position;

      Sequence pickupSequence = DOTween.Sequence();

      await pickupSequence.Append(transform.DOMoveY(startPos.y + jumpHeight,
        jumpDuration).SetEase(Ease.OutQuad)).AsyncWaitForCompletion();

      if (gameObject != null)
        Destroy(gameObject);
    }
  }
}