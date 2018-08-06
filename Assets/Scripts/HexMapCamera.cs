﻿using UnityEngine;

public class HexMapCamera : MonoBehaviour {

	Transform swivel, stick;
	float zoom = 1f;
	public float stickMinZoom, stickMaxZoom;
	public float swivelMinZoom, swivelMaxZoom;
	public float moveSpeedMinZoom, moveSpeedMaxZoom;
	public HexGrid grid;

	static HexMapCamera instance;

	public static bool Locked{
		set{
			instance.enabled = !value;
		}
	}

	public static void ValidatePostion(){
		instance.AdjustPosition(0f,0f);
	}

	void Awake () {
		instance = this;
		ValidatePostion();
		swivel = transform.GetChild(0);
		stick = swivel.GetChild(0);
	}

	void Update () {
		float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
		if (zoomDelta != 0f) {
			AdjustZoom(zoomDelta);
		}

		float xDelta = Input.GetAxis("Horizontal");
		float zDelta = Input.GetAxis("Vertical");
		if (xDelta != 0f || zDelta != 0f) {
			AdjustPosition(xDelta, zDelta);
		}
	}
	
	public void AdjustPosition (float xDelta, float zDelta) {
		Vector3 direction = new Vector3(xDelta, 0f, zDelta).normalized;
		float damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(zDelta));
		float distance = Mathf.Lerp(moveSpeedMinZoom, moveSpeedMaxZoom, zoom) * damping* Time.deltaTime;

		Vector3 position = transform.localPosition;
		position += direction * distance;
		transform.localPosition = ClampPosition(position);
	}

	public void AdjustPosition(Vector3 position){
		this.transform.localPosition = position;
	}

	Vector3 ClampPosition(Vector3 position){

		float xMax = 
			(grid.chunkCountX*HexMetrics.chunkSizeZ-0.5f)*
			(2f*HexMetrics.innerRadius);
		position.x = Mathf.Clamp(position.x,0f,xMax);

		float zMax =
			(grid.chunkCountZ * HexMetrics.chunkSizeZ-1) *
			(1.5f * HexMetrics.outerRadius);
		position.z = Mathf.Clamp(position.z, 0f, zMax);

		return position;

	}

	void AdjustZoom (float delta) {
		zoom = Mathf.Clamp01(zoom + delta);

		float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
		stick.localPosition = new Vector3(0f, 0f, distance);

		float angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
		swivel.localRotation = Quaternion.Euler(angle, 0f, 0f);
	}


}