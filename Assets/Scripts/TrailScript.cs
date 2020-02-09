using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class TrailScript : MonoBehaviour
{
	//public GameObject gameObject;
	public Material trailMaterial;
	public GameObject colorPickerHolderButton;
	public GameObject camera;
	public float spawnDistance = 2;
	public GameObject brushIndicatorPrefab;
	public List<GameObject> Points = new List<GameObject>();

	private bool drawing;

	private float brushSize;

	private GameObject brushIndicator;

	// Use this for initialization
	void Start()
	{
		drawing = false;
		brushSize = 0.1f;
		Vector3 camPos = camera.transform.position;
		Vector3 camDirection = camera.transform.forward;
		Quaternion camRotation = camera.transform.rotation;
		Vector3 spawnPos = camPos + (camDirection * spawnDistance);
		brushIndicator = (GameObject) Instantiate(brushIndicatorPrefab, spawnPos, camRotation);
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 camPos = camera.transform.position;
		Vector3 camDirection = camera.transform.forward;
		Quaternion camRotation = camera.transform.rotation;
		Vector3 spawnPos = camPos + (camDirection * spawnDistance);
		brushIndicator.transform.position = spawnPos;
		brushIndicator.transform.rotation = camRotation;
		brushIndicator.GetComponent<MeshRenderer>().material.color = colorPickerHolderButton.GetComponent<Image>().color;
		if (drawing)
		{
			GameObject sphereBrush = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphereBrush.transform.localScale = Vector3.one * brushSize;
			sphereBrush.transform.position = spawnPos;
			sphereBrush.transform.rotation = camRotation;
			sphereBrush.GetComponent<MeshRenderer>().material = trailMaterial;
			sphereBrush.GetComponent<MeshRenderer>().material.color = colorPickerHolderButton.GetComponent<Image>().color;
			sphereBrush.transform.SetParent(this.transform);
		}
	}

	public void ToggleDrawing()
	{
		if (!drawing)
			drawing = true;
		else
			drawing = false;
	}

	public void BrushSizeController(float newValue)
	{
		brushSize = newValue;
		brushIndicator.transform.localScale = Vector3.one * newValue;
	}
}