﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		RenderSettings.skybox.SetFloat ("_Rotation", Time.time * 1.5f);
	}
}
