using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	Slider sfx;
	[SerializeField]
	Slider Master;

	FMOD.Studio.EventInstance son1J1;
	FMOD.Studio.EventInstance son2J1;
	FMOD.Studio.EventInstance son3J1;
	FMOD.Studio.EventInstance son1J2;
	FMOD.Studio.EventInstance son2J2;
	FMOD.Studio.EventInstance son3J2;
	FMOD.Studio.EventInstance sonImpact;
	FMOD.Studio.EventInstance beat;
	FMOD.Studio.EventInstance tap;

	FMOD.Studio.ParameterInstance beatVolume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son1J1Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son2J1Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son3J1Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son1J2Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son2J2Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance son3J2Volume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance sonImpactVolume; //Instanciation du paramètre lié au son
	FMOD.Studio.ParameterInstance tapVolume; //Instanciation du paramètre lié au son




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
		tap = FMODUnity.RuntimeManager.CreateInstance ("event:/tapMur"); 



		son1J1.getParameter ("VolumeSfx", out son1J1Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son1J1Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous
		son2J1.getParameter ("VolumeSfx", out son2J1Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son2J1Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous
		son3J1.getParameter ("VolumeSfx", out son3J1Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son3J1Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous

		son1J2.getParameter ("VolumeSfx", out son1J2Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son1J2Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous
		son2J2.getParameter ("VolumeSfx", out son2J2Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son2J2Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous
		son3J2.getParameter ("VolumeSfx", out son3J2Volume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		son3J2Volume.setValue (1.0f); // Modification de la valeur du paramètre Luminous

		sonImpact.getParameter ("VolumeSfx", out sonImpactVolume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		sonImpactVolume.setValue (1.0f); // Modification de la valeur du paramètre Luminous

		beat.getParameter ("Volume", out beatVolume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		beatVolume.setValue (1.0f); // Modification de la valeur du paramètre Luminous

		tap.getParameter ("VolumeSfx", out tapVolume); // Va chercher le paramètre FMOD "Luminosité" et le stocke dans le paramètre "Luminous".
		tapVolume.setValue (1.0f); // Modification de la valeur du paramètre Luminous

		beat.start ();
		tap.start ();
	}
	
	// Update is called once per frame
	void Update () {


			son1J1Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son2J1Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son3J1Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son1J2Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son2J2Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son3J2Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			son2J2Volume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			sonImpactVolume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous

			beatVolume.setValue (Master.value); // Modification de la valeur du paramètre Luminous

			tapVolume.setValue (sfx.value); // Modification de la valeur du paramètre Luminous





		
	}
}
