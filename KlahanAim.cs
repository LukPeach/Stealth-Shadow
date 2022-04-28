using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script aim character.
public class KlahanAim : MonoBehaviour
{
	public string aimButton = "Aim";
	public Texture2D crosshair;

	public static bool aim;
	public static bool aimProjectile;

	private void Update()
	{
		// Activate/deactivate aim by input.
		if (Input.GetAxisRaw(aimButton) != 0 && !aim)
		{
			aim = true;
			aimProjectile = true;
		}
		else if (aim && Input.GetAxisRaw(aimButton) == 0)
		{
			aim = false;
			aimProjectile = false;
		}
	}

	// Draw the crosshair when aiming.
	/*private void OnGUI()
	{
		if (crosshair)
		{
			if(aim)
				GUI.DrawTexture(new Rect(Screen.width / 2 - (crosshair.width * 0.5f),
										 Screen.height / 2 - (crosshair.height * 0.5f),
										 crosshair.width, crosshair.height), crosshair);
		}
	}*/
}
