using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    [SerializeField]private string _tag;//loai
    [SerializeField]public int slowDown;//can nang
    [SerializeField] public int dollar;//tien

    private void Awake()
    {
        this.tag = _tag;
    }

}
