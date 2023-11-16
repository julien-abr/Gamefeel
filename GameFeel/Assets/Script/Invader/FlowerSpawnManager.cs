using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _flowerPrefab;
    [SerializeField, ReadOnly] private List<SpriteRenderer> _flowerRendererList = new List<SpriteRenderer>();

    [SerializeField] private List<Sprite> _flowerSprites = new List<Sprite>();

    [Button]
    public void CreateNewFlowerSlot()
    {
        RemoveObjectNullFromList(_flowerRendererList);
        _flowerRendererList.Add(Instantiate(_flowerPrefab, Vector3.zero, Quaternion.identity).GetComponent<SpriteRenderer>());
    }
    private void RemoveObjectNullFromList(List<SpriteRenderer> list)
    {
        for (int i = 0; i < list.Count;)
        {
            if (!list[i])
            {
                list.Remove(list[i]);
                continue;
            }

            i++;
        }
    }

    private void Awake()
    {
        foreach (SpriteRenderer flower in _flowerRendererList)
            flower.enabled = false;
    }

    public void RevealNewFlower()
    {
        int r = Random.Range(0, _flowerRendererList.Count);

        if(_flowerSprites.Count > 0)
        {
            int s = Random.Range(0, _flowerSprites.Count);
            _flowerRendererList[r].sprite = _flowerSprites[s];
        }
        _flowerRendererList[r].enabled = true;
        _flowerRendererList.RemoveAt(r);
    }
}
