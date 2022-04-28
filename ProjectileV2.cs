using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script projectile
public class ProjectileV2 : MonoBehaviour
{
    public KeyCode shoot = KeyCode.Mouse0;

    public Rigidbody GameOBJprefabs;
    public Transform shootPoint;
    public LineRenderer _line;
    public int lineSegment = 10;
    public Vector3 _posPlayer = new Vector3(1.5f, 0.9f, 0.6f);

    [Space]
    public float _Velocity;
    public float _inputMouse;

    private void Start()
    {
        _line.positionCount = lineSegment;
    }

    private void Update()
    {
        UseItem hold = GetComponentInParent(typeof(UseItem)) as UseItem;

        //Check if the player is holding the stick or not.
        if (hold.holdStick)
        {
            Setup();

            //Take input from player and check aim.
            if (Input.GetKeyUp(shoot) && KlahanAim.aimProjectile)
            {
                InstantObj();
            }

            //Check aim and create guide lines.
            if (KlahanAim.aimProjectile)
            {
                _line.enabled = true;
                LaunchProjectile();
            }
            else
            {
                _line.enabled = false;
            }
        }
        else
        {
            _line.enabled = false;
        }
    }

    //Setup.
    void Setup()
    {
        _inputMouse = Input.GetAxis("Mouse1") * 2;
        transform.rotation = KlahanCamera.aimRotation;
    }

    //Function to create a throwing stick.
    void InstantObj()
    {
        Rigidbody obj = Instantiate(GameOBJprefabs, shootPoint.position, Quaternion.identity);
        obj.velocity = CalculateVelocity(transform.forward, shootPoint.position, 1f);

        UseItem hold = GetComponentInParent(typeof(UseItem)) as UseItem;
        hold.holdStick = false;

        AddItemToInventory.removeItemNumber = 5;
        AddItemToInventory.quantityItem = 1;
        AddItemToInventory.checkRemoveitem = true;
    }

    //Create guide lines.
    void Visualize(Vector3 Vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(Vo, i / (float)lineSegment);
            _line.SetPosition(i, pos);
        }
    }

    //Function calculate position in time.
    Vector3 CalculatePosInTime(Vector3 vo , float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 resule = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;

        resule.y = sY;

        return resule;
    }

    //Function launch projectile.
    void LaunchProjectile()
    {
        Vector3 Vo = CalculateVelocity(transform.forward, shootPoint.position, 1f);
        Visualize(Vo);
    }

    //Function calculate velocity.
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target + new Vector3(0f, 0.25f, 0f);
        Vector3 distanceXZ = (_Velocity * _inputMouse) * distance;
        Vector3 result = distanceXZ;

        return result;
    }
}
