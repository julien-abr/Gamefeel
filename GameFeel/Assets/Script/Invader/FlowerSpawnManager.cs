using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _flowerPrefab;
    [SerializeField, ReadOnly] private List<SpriteRenderer> _flowerRendererList = new List<SpriteRenderer>();

    [SerializeField] private List<Sprite> _flowerSprites = new List<Sprite>();

    [SerializeField] private float animTime = 5f;

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
        if (_flowerRendererList.Count <= 0)
            return;

        int r = Random.Range(0, _flowerRendererList.Count);

        if(_flowerSprites.Count > 0)
        {
            int s = Random.Range(0, _flowerSprites.Count);
            _flowerRendererList[r].sprite = _flowerSprites[s];
        }

        Sequence seq = DOTween.Sequence();

        Tween a = _flowerRendererList[r].transform.DOLocalRotate(new Vector3(0, 0, 120), animTime).SetEase(Ease.Linear);
        Tween b = _flowerRendererList[r].transform.DOLocalRotate(new Vector3(0, 0, 240), animTime).SetEase(Ease.Linear);
        Tween c = _flowerRendererList[r].transform.DOLocalRotate(new Vector3(0, 0, 360), animTime).SetEase(Ease.Linear);
        //Tween d = _flowerRendererList[r].transform.DORotate(new Vector3(0, 0, 0), 0);
        //_flowerRendererList[r].transform.do
        seq.Append(a).Append(b).Append(c).SetLoops(-1);

        Vector3 scale = _flowerRendererList[r].transform.localScale;
        _flowerRendererList[r].transform.localScale = Vector3.zero;
        _flowerRendererList[r].transform.DOScale(scale, 0.5f);
        
        _flowerRendererList[r].enabled = true;
        _flowerRendererList.RemoveAt(r);
    }
}
