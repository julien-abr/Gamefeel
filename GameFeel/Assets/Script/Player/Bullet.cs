using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    [SerializeField] private float speed;
    public System.Action destroyed;

    private int LaserLayer;

    [SerializeField] GameStatsRef _ref;
    ISet<int> RealRef => _ref;

    [SerializeField] private UnityEvent _OnShootEvent;
    public UnityEvent OnShootEvent { get => _OnShootEvent; set => _OnShootEvent = value; }

    private void Awake()
    {
        LaserLayer = LayerMask.NameToLayer("Laser");
    }

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (this.destroyed != null)
        {
            this.destroyed.Invoke();

            if (LaserLayer == gameObject.layer)
            {
                int newScore = 1 + _ref.Instance;
                RealRef.Set(newScore);
            }
        }
        Destroy(this.gameObject);
    }
}
