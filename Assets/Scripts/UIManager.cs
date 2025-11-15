using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class UIManager : MonoBehaviour
{
   [Header("UI Pages")]
   [SerializeField] private GameObject mainMenue;
   [SerializeField] private GameObject optionMenu;
   [SerializeField] private GameObject browseMenu;
   [SerializeField] private GameObject detailsMenu;
   
   [Header("Main Menu Buttons")]
   public Button browseButton;
   public Button optionButton;
   public Button aboutButton;
   public Button quitButton;

   [Header("Browse Menu Button")] 
   [SerializeField] private Button homelevel;

   [Header("Back Buttons")] [SerializeField]
   private List<Button> backButtons ;
   //[SerializeField] private List<string> homeLevels = new List<string>();

   private string code = "w355JK";
   private void Awake()
   {
      //Hook events
      
      //Main Menu
      browseButton.onClick.AddListener(Browse);
      optionButton.onClick.AddListener(Option);
      aboutButton.onClick.AddListener(Details);
      quitButton.onClick.AddListener(Quit);
      
      //Browse Menu
      
      homelevel.onClick.AddListener(HomeLevelLoad);

      //Back buttons

      foreach (var button in backButtons)
      {
         button.onClick.AddListener(ShowMainmenu);
      }
      ShowMainmenu();
   }

   public void ShowMainmenu()
   {
      mainMenue.SetActive(true);
      browseMenu.SetActive(false);
      optionMenu.SetActive(false);
      detailsMenu.SetActive(false);
   }
   public void Browse()
   {
      mainMenue.SetActive(false);
      browseMenu.SetActive(true);
   }
   public void Option()
   {
      mainMenue.SetActive(false);
      optionMenu.SetActive(true);
   }
   public void Details()
   {
      mainMenue.SetActive(false);
      detailsMenu.SetActive(true);
   }
   public void Quit()
   {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#endif
      Application.Quit();
   }

   public void HomeLevelLoad()
   {
      SceneManager.LoadScene(1);
   }

   public void Login()
   {
      
   }
}
