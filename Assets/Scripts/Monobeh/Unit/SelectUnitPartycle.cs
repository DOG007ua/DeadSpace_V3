using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitPartycle : MonoBehaviour, ISelectUnit
{
    public bool IsSelect
    {
        get => isSelect;
        set
        {
            isSelect = value;
            particle.gameObject.SetActive(value);
        }
    }
    private bool isSelect;
    private ParticleSystem particle;
    
    
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
}
