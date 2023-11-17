using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float shootRate = 1.0f;

    private bool _bulletActive;


    [Inject] private UpdateBehaviour _uB;
    [SerializeField] private InputFX _OnPlayerShoot;
    [SerializeField] private InputSwitchFX onPlayerMovement;
    private void Start()
    {
        _OnPlayerShoot.SubscribeToUpdate(_uB);
        onPlayerMovement.SubscribeToUpdate(_uB);
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

