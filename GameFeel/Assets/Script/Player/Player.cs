using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float speed = 5.0f;

    private bool _bulletActive;
    private bool _canShoot;

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

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(_canShoot)
            {
                Shoot();
            }      
        }

    }
    private void Shoot()
    {
        if (!_bulletActive)
        {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
            bullet.destroyed += BulletDestoyed;
            _bulletActive = true;

            _OnPlayerShoot.TriggerEvent();
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
    public void CanShoot(bool result)
    {
        _canShoot = result;
    }
}

