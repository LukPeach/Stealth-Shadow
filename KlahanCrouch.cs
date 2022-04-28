using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script crouch character.
public class KlahanCrouch : MonoBehaviour
{
    public KeyCode key = KeyCode.LeftControl;

    [Header("Slow Movement")]
    public KlahanMovement movement;
    //Movement speed when crouched
    public float movementSpeed = 2;

    //Collider to lower when crouched
    public CapsuleCollider colliderToLower;
    [HideInInspector]
    public float? defaultColliderHeight;

    public bool IsCrouched { get; private set; }
    public event System.Action CrouchStart, CrouchEnd;


    void Reset()
    {
        movement = GetComponentInParent<KlahanMovement>();
        colliderToLower = movement.GetComponentInChildren<CapsuleCollider>();
    }

    void LateUpdate()
    {
        //Get input from the player.
        if (Input.GetKey(key))
        {

            if (colliderToLower)
            {
                if (!defaultColliderHeight.HasValue)
                {
                    defaultColliderHeight = colliderToLower.height;
                }

                float loweringAmount;
                loweringAmount = defaultColliderHeight.Value * 0.5f;

                colliderToLower.height = Mathf.Max(defaultColliderHeight.Value - loweringAmount, 0);
                colliderToLower.center = Vector3.up * colliderToLower.height * 0.5f;
            }

            if (!IsCrouched)
            {
                IsCrouched = true;
                SetSpeedOverrideActive(true);
                CrouchStart?.Invoke();
            }
        }
        else
        {
            if (IsCrouched)
            {

                if (colliderToLower)
                {
                    colliderToLower.height = defaultColliderHeight.Value;
                    colliderToLower.center = Vector3.up * colliderToLower.height * .5f;
                }

                IsCrouched = false;
                SetSpeedOverrideActive(false);
                CrouchEnd?.Invoke();
            }
        }
    }

    //Set speed override when the player presses crouch
    void SetSpeedOverrideActive(bool state)
    {
        if (!movement)
        {
            return;
        }

        if (state)
        {
            if (!movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Add(SpeedOverride);
            }
        }
        else
        {
            if (movement.speedOverrides.Contains(SpeedOverride))
            {
                movement.speedOverrides.Remove(SpeedOverride);
            }
        }
    }

    float SpeedOverride() => movementSpeed;
}
