using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
	public GameObject instructionsScreen;					//Store a reference to the Game Object InstructionsScreen 
	public GameObject controlsScreen;						//Store a reference to the Game Object ControlsScreen 
	public GameObject stageSelectionScreen;					//Store a reference to the Game Object StageSelectionScreen 

	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);
	}

	// Show instructions
	public void ShowInstructionsScreen()
	{
		menuPanel.SetActive (false);
		instructionsScreen.SetActive (true);
	}

	// Switch from instructions to controls
	public void ShowControlsScreen()
	{
		instructionsScreen.SetActive (false);
		controlsScreen.SetActive(true);
	}

	// Switch from main menu or controls to stage selection
	public void ShowStageSelectionScreen()
	{
		if (menuPanel.activeSelf) menuPanel.SetActive (false);
		if (controlsScreen.activeSelf) controlsScreen.SetActive (false);
		stageSelectionScreen.SetActive(true);
	}

	// Switch from stage selection to main menu
	public void BackToMainMenu()
	{
		stageSelectionScreen.SetActive (false);
		menuPanel.SetActive(true);
	}
}
