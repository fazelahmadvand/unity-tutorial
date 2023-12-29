using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class VFXSample : MonoBehaviour
{

    [SerializeField] private VisualEffect vfx;
    [SerializeField] private AudioSource vfxSound;
    [SerializeField] private float duration = .9f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vfxSound.DOFade(0, duration);
            vfx.Stop();
        }
    }


}
