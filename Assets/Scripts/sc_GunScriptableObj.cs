using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGravGun", menuName = "ScriptableObjects/GravGun", order = 1)]
public class sc_GunScriptableObj : ScriptableObject
{
    [SerializeField] GameObject _weaponTransform;
    [SerializeField] float _shootDistance = 10f;
    [SerializeField] LayerMask _layersToShoot;
    [SerializeField] float _strength = 20f;
    // Start is called before the first frame update
    public void setTransform(GameObject _transform)
    {
        _weaponTransform = _transform;
    }
    public void Shoot()
    {
        //Debug.Log("Shoot!");
        Vector3 rayStartPos = _weaponTransform.transform.position;
        Vector3 rayDirection = _weaponTransform.transform.forward;
        Debug.DrawRay(rayStartPos, rayDirection * _shootDistance, Color.cyan, 1);
        RaycastHit hitInfo;
        if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo, _shootDistance, _layersToShoot)) {
            Rigidbody movableObject = hitInfo.transform.GetComponent<Rigidbody>();
            if (movableObject != null) {
                movableObject.AddForce(rayDirection * _strength);
            }
        }
    }

    }
