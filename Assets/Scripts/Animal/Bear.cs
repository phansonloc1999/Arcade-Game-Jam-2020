using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bear : MonoBehaviour
{
    [SerializeField] private Transform _treeTransform;


    [SerializeField] private bool _startRevealing;

    private static CapsuleGunMagazine _capsuleGunMagazine = null;

    private static float _revealingDuration = 1.5f;

    private static int _damageToPlayer = 4;

    private static float? _middleScreenX = null;

    private static float _preventReloadingDuration = 2.0f;

    private static SpriteRenderer _spriteRenderer;

    private static SpriteRenderer _treeSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _treeTransform = transform.parent.GetComponent<Transform>();

        if (_middleScreenX == null)
        {
            _middleScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _treeSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

        if (_capsuleGunMagazine == null)
        {
            _capsuleGunMagazine = GameObject.Find("Capsule Gun").GetComponent<CapsuleGunMagazine>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startRevealing)
        {
            if (TreeIsAtMiddleScreen())
            {
                // Move left to reveal right half of the bear's sprite behind the tree
                transform.DOLocalMoveX(_spriteRenderer.bounds.size.x / 2 + _treeSpriteRenderer.bounds.size.x / 2, _revealingDuration)
                .OnComplete(
                    () =>
                    {
                        StartCoroutine(Routine());
                    }
                );

                _startRevealing = true;
            }
        }
    }

    bool TreeIsAtMiddleScreen()
    {
        return Mathf.Floor(_treeTransform.position.x) == Mathf.Floor(_middleScreenX.Value);
    }

    IEnumerator Routine()
    {
        GetComponent<Animator>().SetTrigger("isAttacking");

        PlayerHealth.TakeDamage(_damageToPlayer);

        _capsuleGunMagazine.enabled = false;

        yield return new WaitForSeconds(_preventReloadingDuration);

        _capsuleGunMagazine.enabled = true;

        yield break;
    }
}
