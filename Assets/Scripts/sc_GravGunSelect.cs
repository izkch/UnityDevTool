using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class sc_GravGunSelect : MonoBehaviour
{
    [SerializeField] sc_GunScriptableObj _gravgunscript;
    [SerializeField] GameObject _weaponTransform;

    private void Start()
    {
        _gravgunscript.setTransform(_weaponTransform);
    }
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.IsPressed()) {
            _gravgunscript.Shoot();
        }
    }
}
