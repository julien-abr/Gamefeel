using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Invader : MonoBehaviour
{
    [SerializeField]private Sprite[] animationSprites;

    [SerializeField] float animationTime = 1.0f;
    private SpriteRenderer spriteRenderer;
    private int animationFrame;

    private Action _OnDeath;
    [SerializeField] private UnityEvent _OnEnemyTransfomationDeath;
    [SerializeField] private UnityEvent _OnEnemyNewFlowerDeath;
    public Action OnDeath { get => _OnDeath; set => _OnDeath = value; }
    public UnityEvent OnEnemyTransfomationDeath { get => _OnEnemyTransfomationDeath; set => _OnEnemyTransfomationDeath = value; }
    public UnityEvent OnEnemyNewFlowerDeath { get => _OnEnemyNewFlowerDeath; set => _OnEnemyNewFlowerDeath = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animationSprites[0];
    }

    private void Start()
    {
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
            _OnEnemyTransfomationDeath.Invoke();
            _OnEnemyNewFlowerDeath.Invoke();
            Destroy(this.gameObject);
        }
        //else if (other.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        //{
        //    GameManager.Instance.OnBoundaryReached();
        //}
    }
}
