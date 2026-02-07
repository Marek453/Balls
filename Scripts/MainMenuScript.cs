using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public TMPro.TMP_Dropdown BallsDropdown;
    public TMPro.TMP_Dropdown MapsDropdown;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if(PlayerPrefs.GetInt("BallSelect") == null)
        {
            PlayerPrefs.SetInt("BallSelect", 0);
        }
        if(PlayerPrefs.GetInt("MapSelect") == null)
        {
            PlayerPrefs.SetInt("MapSelect", 0);
        }
        MapsDropdown.value = PlayerPrefs.GetInt("MapSelect");
        BallsDropdown.value = PlayerPrefs.GetInt("BallSelect");
    }
    public void Save(int i)
    {
        PlayerPrefs.SetInt("BallSelect", i);
        PlayerPrefs.Save();
    }

     public void MapSave(int i)
    {
        PlayerPrefs.SetInt("MapSelect", i);
        PlayerPrefs.Save();
    }
}
