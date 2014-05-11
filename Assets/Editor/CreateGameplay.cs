using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(GameManager))]
public class CreateGameplay : Editor {

	SerializedObject player;
	SerializedProperty gameStateProp;
	SerializedProperty guiManagerProp;
	SerializedProperty platformEndProp;
	SerializedProperty limiteProp;
	SerializedProperty playerProp;
	SerializedProperty cameraProp;
	SerializedProperty playerSpawn;
	SerializedProperty coins;

	void OnEnable()
	{
		player = new SerializedObject(target);
	}
	
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		gameStateProp = serializedObject.FindProperty("gameState");
		guiManagerProp =  serializedObject.FindProperty("guiManager");
		platformEndProp =  serializedObject.FindProperty("platformEnd");
		limiteProp =  serializedObject.FindProperty("limite");
		playerProp =  serializedObject.FindProperty("player");
		cameraProp =   serializedObject.FindProperty("camera");
		playerSpawn = serializedObject.FindProperty("spawnPlayer");
		coins = serializedObject.FindProperty("numberCoins");

		EditorGUILayout.PropertyField(gameStateProp);
		EditorGUILayout.PropertyField(guiManagerProp);
		EditorGUILayout.PropertyField(platformEndProp);
		EditorGUILayout.PropertyField(limiteProp);
		EditorGUILayout.PropertyField(playerProp);
		EditorGUILayout.PropertyField(cameraProp);
		EditorGUILayout.PropertyField(playerSpawn);
		EditorGUILayout.PropertyField(coins);

		EditorGUILayout.Space();
		EditorGUILayout.Space();

		if (GUI.changed)
			EditorUtility.SetDirty(target);
	}
}
