using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	FMOD.Studio.EventInstance son1J1;
	FMOD.Studio.EventInstance son2J1;
	FMOD.Studio.EventInstance son3J1;
	FMOD.Studio.EventInstance son1J2;
	FMOD.Studio.EventInstance son2J2;
	FMOD.Studio.EventInstance son3J2;
	FMOD.Studio.EventInstance sonImpact;
	FMOD.Studio.EventInstance beat;
	FMOD.Studio.EventInstance tap;



	// Use this for initialization
	void Start () {

		son1J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona1"); 
		son2J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona2"); 
		son3J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona3"); 
		son1J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria1"); 
		son2J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria2"); 
		son3J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria3"); 
		sonImpact = FMODUnity.RuntimeManager.CreateInstance ("event:/Impact"); 
		beat = FMODUnity.RuntimeManager.CreateInstance ("event:/Beat"); 
		sonImpact = FMODUnity.RuntimeManager.CreateInstance ("event:/tapMur"); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
