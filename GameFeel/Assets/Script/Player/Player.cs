using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float speed = 5.0f;

    [SerializeField] private float shootRate = 1.0f;

    private bool _bulletActive;

    [Inject] private UpdateBehaviour _uB;
    [SerializeField] private InputFX _OnPlayerShoot;
    private void Start() => _OnPlayerShoot.SubscribeToUpdate(_uB);

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
    }
    private void Shoot()
    {
        if (!_bulletActive)
        {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
            bullet.destroyed += BulletDestoyed;
            _bulletActive = true;

            if (_OnPlayerShoot.TriggerEvent())
                bullet.OnShootEvent.Invoke();
        }
    }

    private void BulletDestoyed()
    {
        _bulletActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Invader") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    public void StartShoot()
    {
        InvokeRepeating(nameof(Shoot), 0, shootRate);
    }
}

