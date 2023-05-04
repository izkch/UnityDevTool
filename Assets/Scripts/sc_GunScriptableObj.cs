using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGravGun", menuName = "ScriptableObjects/GravGun", order = 1)]
public class sc_GunScriptableObj : ScriptableObject
{
    
    private GameObject _weaponTransform;
    [SerializeField] public bool _canBeHeld = true;
    [Tooltip("Set to false for pull")]
    [SerializeField] public bool _push;
    [SerializeField] float _shootDistance = 10f;
    [SerializeField] LayerMask _layersToShoot;
    [SerializeField] float _strength = 200f;
    [SerializeField] float _rate = 0.5f;
    [SerializeField] GameObject _trail;

    [HideInInspector]
    public float _timeLastShot = 0;

    [HideInInspector]
    public MonoBehaviour _mono;

    public void setTransform(GameObject _transform)
    {
        _weaponTransform = _transform;
    }
    public void Shoot()
    {
        if (Time.time - _timeLastShot > _rate) {
            _timeLastShot = Time.time;
            Vector3 rayStartPos = _weaponTransform.transform.position;
            Vector3 rayDirection = _weaponTransform.transform.forward;
            Debug.DrawRay(rayStartPos, rayDirection * _shootDistance, Color.cyan, 1);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayStartPos, rayDirection, out hitInfo, _shootDistance, _layersToShoot)) {
                Rigidbody movableObject = hitInfo.transform.GetComponent<Rigidbody>();
                if (movableObject != null) {
                    if(_trail != null)
                    {
                        _mono.StartCoroutine(PlayTrail(_weaponTransform.transform.position, hitInfo.transform.position));
                    }
                    if (_push) {
                        movableObject.AddForce(rayDirection * _strength); 
                    }else if(!_push) {
                        movableObject.AddForce(rayDirection * -_strength); 
                    }
                }
            }
        }
    }
        private IEnumerator PlayTrail(Vector3 start, Vector3 end){
            if (_trail != null) {
                GameObject instance = Instantiate(_trail);
                instance.transform.position = start;
                yield return null;
                instance.transform.position = end;
            }
       
        }
    }
