using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void Start_OnClick()
	{
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
	}
}
