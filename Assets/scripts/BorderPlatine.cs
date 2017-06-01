using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlatine : MonoBehaviour {
	private const int number_of_cubes = 64;
	private const float translation_scale = 0.499f;

	void Start () {
		for (int i = 0; i < number_of_cubes; ++i) {
			float angle = i * 2 * Mathf.PI / number_of_cubes;

			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.Translate (new Vector3 (Mathf.Cos(angle) * translation_scale, 0.0f, Mathf.Sin(angle) * translation_scale));
			cube.transform.Rotate (new Vector3(0.0f, -1 * angle * 180.0f / Mathf.PI, 45.0f));

			cube.transform.localScale = new Vector3(0.14f, 0.14f, 0.14f);
			cube.transform.parent = gameObject.transform;
		}
	}
}
