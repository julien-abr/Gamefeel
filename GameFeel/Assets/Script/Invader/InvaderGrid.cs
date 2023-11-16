using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class InvaderGrid : MonoBehaviour
{
    [SerializeField] private Invader[] prefab;

    [SerializeField] private int rows = 5;

    [SerializeField] int columns = 11;

    [SerializeField] private AnimationCurve speed;

    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float missileAttackRate = 1.0f;

    [SerializeField] private float spawnRate = 0.1f;

    [SerializeField] private Player player;

    public int amountKilled { get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    private bool _IsInitialized;

    private Vector3 _direction = Vector2.right;

    [Inject] private UpdateBehaviour _uB;
    [SerializeField] private InputFX _OnInvaderSpawn;

    private IEnumerator Start()
    {
        _OnInvaderSpawn.SubscribeToUpdate(_uB);

        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2 (-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefab[row], this.transform);
                invader.OnDeath += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;

                yield return new WaitForSeconds(spawnRate);
            }
        }

        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
        _IsInitialized = true;
        player.CanShoot(true);
    }

    private void Update()
    {
        if (!_IsInitialized) { return; }

        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if(_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                _direction.x *= -1.0f;
            }
            else if(_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                _direction.x *= -1.0f;
            }
        }
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if(UnityEngine.Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.bulletPrefab, invader.position, Quaternion.identity);
                break;
            }
        }

    }

    private void InvaderKilled()
    {
        this.amountKilled++;

        if(this.amountKilled >= this.totalInvaders)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
