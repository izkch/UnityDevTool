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
        _gravgunscript._timeLastShot = 0;
        _gravgunscript._mono = this;
        _gravgunscript.setTransform(_weaponTransform);
    }
    // Update is called once per frame
    void Update()
    {
        if (_gravgunscript._canBeHeld && Mouse.current.leftButton.IsPressed()) {
            _gravgunscript.Shoot();
        }else if (!_gravgunscript._canBeHeld && Mouse.current.leftButton.wasPressedThisFrame)
        {
            _gravgunscript.Shoot();
        }
    }
}
