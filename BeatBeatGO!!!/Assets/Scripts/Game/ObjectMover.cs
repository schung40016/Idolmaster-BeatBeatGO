using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMover : MonoBehaviour
{
    private Transform moveObj;
    [SerializeField] private float newYLoc = 0f;
    [SerializeField] private float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        moveObj = GetComponentInParent<Transform>();
        moveObj.transform.DOLocalMoveX(newYLoc, duration);
    }
}
