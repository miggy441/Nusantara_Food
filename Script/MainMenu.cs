using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject HTPPanel;
    public GameObject SettingPanel;
    public GameObject RecipePanel;
    public GameObject StageSelectPanel;
    public GameObject ShopPanel;

    [Header("Stage Selection")]
    public GameObject FirstTimeIntro;
    //public GameObject Stage1Panel;
    public GameObject Stage1Dialog;
    public GameObject stage2Dia;
    public GameObject stage3Dia;

    [Header("Resep Makanan")]
    public GameObject resep1Panel;
    public GameObject resep2Panel;
    public GameObject resep3Panel;
    

    // Start is called before the first frame update

    public void StartButton()
    {
        MenuPanel.SetActive(false);
        StageSelectPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void BackStageSelection()
    {
        StageSelectPanel.SetActive(false);
        MenuPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void FirstTime()
    {
        StageSelectPanel.SetActive(false);
        FirstTimeIntro.SetActive(true);
        DialogueController.instance.stage1 = true;
        DialogueController.instance.stage2 = false;
        DialogueController.instance.stage3 = false;
        SFXManager.instance.UIClick();
    }

    public void Stage2Dialog()
    {
        StageSelectPanel.SetActive(false);
        stage2Dia.SetActive(true);
        SFXManager.instance.UIClick();
        DialogueController.instance.stage1 = false;
        DialogueController.instance.stage2 = true;
        DialogueController.instance.stage3 = false;
    }

    public void Stage3Dialog()
    {
        StageSelectPanel.SetActive(false);
        stage3Dia.SetActive(true);
        SFXManager.instance.UIClick();
        DialogueController.instance.stage1 = false;
        DialogueController.instance.stage2 = false;
        DialogueController.instance.stage3 = true;
    }

    public void Shop()
    {
        StageSelectPanel.SetActive(false);
        ShopPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void ShopBack()
    {
        StageSelectPanel.SetActive(true);
        ShopPanel.SetActive(false);
        SFXManager.instance.UIClick();
    }


    public void Setting()
    {
        MenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void CloseOption()
    {
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void Recipe()
    {
        RecipePanel.SetActive(true);
        MenuPanel.SetActive(false);
        SFXManager.instance.UIClick();
    }

    public void BackRecipeMenu()
    {
        RecipePanel.SetActive(false);
        MenuPanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void resep1()
    {
        RecipePanel.SetActive(false);
        resep1Panel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void resep1Back()
    {
        resep1Panel.SetActive(false);
        RecipePanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void resep2()
    {
        RecipePanel.SetActive(false);
        resep2Panel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void resep2Back()
    {
        resep2Panel.SetActive(false);
        RecipePanel.SetActive(true);
        SFXManager.instance.UIClick();
    }    
    
    public void resep3()
    {
        RecipePanel.SetActive(false);
        resep3Panel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void resep3Back()
    {
        resep3Panel.SetActive(false);
        RecipePanel.SetActive(true);
        SFXManager.instance.UIClick();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
}
