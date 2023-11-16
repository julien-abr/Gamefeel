using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Invader : MonoBehaviour
{
    [SerializeField]private Sprite[] animationSprites;

    [SerializeField] float animationTime = 1.0f;
    private SpriteRenderer spriteRenderer;
    private int animationFrame;

    [Inject] private UpdateBehaviour _uB;
    [SerializeField] private InputFX _OnEnemyTransfomationDeath;
    [SerializeField] private InputFX _OnEnemyNewFlowerDeath;
    private Action _OnDeath;
    public Action OnDeath { get => _OnDeath; set => _OnDeath = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animationSprites[0];
    }

    private void Start()
    {
        _OnEnemyTransfomationDeath.SubscribeToUpdate(_uB);
        _OnEnemyNewFlowerDeath.SubscribeToUpdate(_uB);

        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            _OnDeath.Invoke();
            _OnEnemyTransfomationDeath.TriggerEvent();
            _OnEnemyNewFlowerDeath.TriggerEvent();
            Destroy(this.gameObject);
        }
        //else if (other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        //{
        //    GameManager.Instance.OnBoundaryReached();
        //}
    }
}
