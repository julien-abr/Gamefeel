using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameStatsRef _ref;
    ISet<int> RealRef => _ref;

    private void Awake()
    {
        RealRef.Set(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

}
