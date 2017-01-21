using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(PlayerCharacterController))]
public class PlayerCharacterControllerEditor : Editor {

	const float handleSize = 0.1f;

	void OnSceneGUI () {
		PlayerCharacterController script = (PlayerCharacterController) target;
		Handles.matrix = script.transform.localToWorldMatrix;
		EditorGUI.BeginChangeCheck ();
		Handles.color = Color.blue;
		Vector3 newMoveRangeMin = Handles.FreeMoveHandle(script.moveRange[0] * Vector3.up, Quaternion.identity, HandleUtility.GetHandleSize(script.transform.position) * handleSize, Vector3.zero, Handles.CubeCap);
		Handles.color = Color.yellow;
		Vector3 newMoveRangeMax = Handles.FreeMoveHandle(script.moveRange[1] * Vector3.up, Quaternion.identity, HandleUtility.GetHandleSize(script.transform.position) * handleSize, Vector3.zero, Handles.CubeCap);
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObject(script, "Change Move Range");
			script.moveRange = new Vector2(newMoveRangeMin.y, newMoveRangeMax.y);
		}
		Handles.DrawLine(script.moveRange[0] * Vector3.up, script.moveRange[1] * Vector3.up);
	}
}
