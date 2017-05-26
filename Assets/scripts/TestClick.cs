using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour {
	private Vector3 offset;
	private Vector3 screenPoint;

	// Appel au clic d'un bouton
	void OnMouseDown () {
		// Clic gauche
		if (Input.GetMouseButton (0)) {
			// Définition d'un point sur l'écran GameObject de la caméra
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);

			// Définition de l'offset entre la camera et l'objet
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}

	// Déplacement du curseur
	void OnMouseDrag() {
		// Position actuelle sur l'écran
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		// Position actuelle in game
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
		// Déplacement de l'objet selon la position in game
		transform.position = currentPosition;
	}
}
