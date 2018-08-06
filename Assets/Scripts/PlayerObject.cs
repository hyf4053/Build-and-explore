using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {
	public HexMapGenerator hexMapGenetator;

	//public GameObject PlayerUnitPrefab;

	// Use this for initialization
	void Start () {

		hexMapGenetator = GameObject.FindObjectOfType<HexMapGenerator>();

		if(isLocalPlayer == false){
			return;
		}
		CmdSpawnMyUnit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/////////////COMMANDS
	//Commands are special functions that ONLY get executed on server.
	[Command]
	void CmdSpawnMyUnit(){
	//	GameObject go = Instantiate(PlayerUnitPrefab);
		//NetworkServer.Spawn(go);
		hexMapGenetator.SetBaseCity();
		//NetworkServer.Spawn();
	}

}
