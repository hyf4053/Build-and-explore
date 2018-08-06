using UnityEngine;

[System.Serializable]
public struct HexTileCollection {

	public GameObject[] prefabs;

	public GameObject Pick(int choice){
		return prefabs[choice];
	}
}
