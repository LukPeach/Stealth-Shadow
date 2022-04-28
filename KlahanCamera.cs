using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script camera character.
public class KlahanCamera : MonoBehaviour
{
	public KeyCode _lookBehind = KeyCode.LeftAlt;
	public Transform player;                                           // Player's reference.
	public GameObject charecter;
	public Vector3 pivotOffset = new Vector3(0.0f, 1.7f, -0.2f);	   // Offset เพื่อปรับตำแหน่งกล้องใหม่
	public Vector3 camOffset = new Vector3(0.0f, 0.0f, -3.0f);         // Offset เพื่อย้ายกล้อง(เกี่ยวข้องกับตำแหน่งผู้เล่น)

	public Vector3 aimPivotOffset = new Vector3(1.1f, 0.9f, -1f);	   // Offset เพื่อปรับตำแหน่งกล้องใหม่(ซูม)
	public Vector3 aimCamOffset = new Vector3(0f, 0.4f, -0.7f);        // Offset เพื่อย้ายกล้อง(เกี่ยวข้องกับตำแหน่งผู้เล่น)(ซูม)

	public float smooth = 10f;                                         // ความเร็วของกล้อง
	public float horizontalAimingSpeed = 3f;                           // ความเร็วในการหมุนแนวนอน
	public float verticalAimingSpeed = 3f;                             // ความเร็วในการหมุนแนวตั้ง
	public float maxVerticalAngle = 30f;                               // Camera max clamp angle. 
	public float minVerticalAngle = -60f;                              // Camera min clamp angle.

	private float angleH = 0;
	private float angleV = 0;
	private Transform cam;
	private Vector3 smoothPivotOffset;                                 // จุดหมุนปัจจุบันของกล้อง
	private Vector3 smoothCamOffset;                                   // จุดปัจจุบันของกล้อง
	private Vector3 targetPivotOffset;
	private Vector3 targetCamOffset;
	private float defaultFOV;                                          // มุมมองกล้องเริ่มต้น
	private float targetFOV;                                           // ขอบเขตการมองเห็นเป้าหมาย
	private float targetMaxVerticalAngle;
	private bool isCustomOffset;                                       // บูลีนเพื่อพิจารณาว่ากำลังใช้ออฟเซ็ตแบบกำหนดเองหรือไม่

	public static Quaternion aimRotation;

	void Awake()
	{
		cam = transform;

		// เซ็ตตำแหน่งเริ่มต้นของกล้อง
		cam.position = player.position + Quaternion.identity * pivotOffset + Quaternion.identity * camOffset;
		cam.rotation = Quaternion.identity;

		// เว็ตการตัวแปรและค่าเริ่มต้น
		smoothPivotOffset = pivotOffset;
		smoothCamOffset = camOffset;
		defaultFOV = cam.GetComponent<Camera>().fieldOfView;
		angleH = player.eulerAngles.y;

		ResetTargetOffsets();
		ResetFOV();
		ResetMaxVerticalAngle();
	}

    void Update()
	{
		if(charecter == null)
        {
			return;
        }

		// ซูม
		bool checkAimcamera = KlahanAim.aim;

		if (checkAimcamera)
			SetTargetOffsets();
		else if (!checkAimcamera)
			ResetTargetOffsets();

		// รับค่าเมาส์ เพื่อ เคลื่อนกล้อง
		angleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1) * horizontalAimingSpeed;
		angleV += Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1) * verticalAimingSpeed;

		// เซ็ตขีดจำกัดการเคลื่อนที่ในแนวตั้ง
		angleV = Mathf.Clamp(angleV, minVerticalAngle, targetMaxVerticalAngle);

		// เซ็ตการหมุนแนวกล้อง
		Quaternion camYRotation = Quaternion.Euler(0, angleH, 0);
		aimRotation = Quaternion.Euler(-angleV, angleH, 0);
		cam.rotation = aimRotation;

		// เซ็ตการหมุน character
		bool freeCam = Input.GetKey(_lookBehind);
		if (!freeCam)
			player.localRotation = Quaternion.Euler(0, angleH, 0);
		else
			player.transform.forward = charecter.transform.forward;

		// Set FOV.
		cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, targetFOV, Time.deltaTime);

		// เทสการชนตามตำแหน่งกล้องปัจจุบัน
		Vector3 baseTempPosition = player.position + camYRotation * targetPivotOffset;
		Vector3 noCollisionOffset = targetCamOffset;
		while (noCollisionOffset.magnitude >= 0.2f)
		{
			if (DoubleViewingPosCheck(baseTempPosition + aimRotation * noCollisionOffset))
				break;
			noCollisionOffset -= noCollisionOffset.normalized * 0.2f;
		}
		if (noCollisionOffset.magnitude < 0.2f)
			noCollisionOffset = Vector3.zero;

		// ไม่มีตำแหน่งกลางแบบกำหนดเอง
		bool customOffsetCollision = isCustomOffset && noCollisionOffset.sqrMagnitude < targetCamOffset.sqrMagnitude;

		// ปรับตำแหน่งกล้องใหม่
		smoothPivotOffset = Vector3.Lerp(smoothPivotOffset, customOffsetCollision ? pivotOffset : targetPivotOffset, smooth * Time.deltaTime);
		smoothCamOffset = Vector3.Lerp(smoothCamOffset, customOffsetCollision ? Vector3.zero : noCollisionOffset, smooth * Time.deltaTime);

		cam.position = player.position + camYRotation * smoothPivotOffset + aimRotation * smoothCamOffset;
	}

    // ตั้งค่ากล้องเป็นค่าที่กำหนดเอง(ซูม)
    public void SetTargetOffsets()
	{
		targetPivotOffset = aimPivotOffset;
		targetCamOffset = aimCamOffset;
		isCustomOffset = true;
	}

	// รีเซ็ตกล้องเป็นค่าเริ่มต้น
	public void ResetTargetOffsets()
	{
		targetPivotOffset = pivotOffset;
		targetCamOffset = camOffset;
		isCustomOffset = false;
	}

	// รีเซ็ตแนวตั้งของกล้อง
	public void ResetYCamOffset()
	{
		targetCamOffset.y = camOffset.y;
	}

	// รีเซ็ต Field of View เป็นค่าเริ่มต้น
	public void ResetFOV()
	{
		this.targetFOV = defaultFOV;
	}

	// รีเซ็ตมุมการหมุนกล้องแนวตั้งสูงสุดเป็นค่าเริ่มต้น
	public void ResetMaxVerticalAngle()
	{
		this.targetMaxVerticalAngle = maxVerticalAngle;
	}

	// ตรวจสอบการชนกัน
	bool DoubleViewingPosCheck(Vector3 checkPos)
	{
		return ViewingPosCheck(checkPos) && ReverseViewingPosCheck(checkPos);
	}

	// ตรวจสอบการชนของกล้องกับผู้เล่น
	bool ViewingPosCheck(Vector3 checkPos)
	{
		// Cast target and direction.
		Vector3 target = player.position + pivotOffset;
		Vector3 direction = target - checkPos;
		// If a raycast from the check position to the player hits something...
		if (Physics.SphereCast(checkPos, 0.2f, direction, out RaycastHit hit, direction.magnitude))
		{
			// ... if it is not the player...
			if (hit.transform != player && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				// This position isn't appropriate.
				return false;
			}
		}
		// If we haven't hit anything or we've hit the player, this is an appropriate position.
		return true;
	}

	// ตรวจสอบการชนกันระหว่างผู้เล่นกับกล้อง
	bool ReverseViewingPosCheck(Vector3 checkPos)
	{
		// Cast origin and direction.
		Vector3 origin = player.position + pivotOffset;
		Vector3 direction = checkPos - origin;
		if (Physics.SphereCast(origin, 0.2f, direction, out RaycastHit hit, direction.magnitude))
		{
			if (hit.transform != player && hit.transform != transform && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				return false;
			}
		}
		return true;
	}
}
