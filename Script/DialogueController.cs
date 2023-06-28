using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance;

    public TextMeshProUGUI DialogueText;

    public string[] Sentences;

    private int Index = 0;
    public float DialogueSpeed;
    private bool nextText = true;
    public GameObject TriggerButton;

    public Animator anim;
    //public Animator ChefAnim;

    public bool stage1;
    public bool stage2;
    public bool stage3;

    /////BUAT GANTI GANTI////
    [Header("change sprite")]
    public GameObject anak;
    public GameObject laki;
    public GameObject chef;

    [Header("Change Teks")]
    public GameObject anakTeks;
    public GameObject lakiTeks;
    public GameObject chefTeks;
    ///--------------------///

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("isOpen", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DialogueTrigger()
    {
        if (nextText == true)
        {
           
            NextSentences();
            nextText = false;
            //ChefAnim.SetTrigger("isDia");            
        }
    }

    void NextSentences()
    {
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            //anak.SetActive(false);
            StartCoroutine(WriteSentence());
            if (Index == 1)
            {
                laki.SetActive(true);
                lakiTeks.SetActive(true);
                anakTeks.SetActive(false);
            }
            else if(Index == 2)
            {
                lakiTeks.SetActive(false);
                anak.SetActive(false);
                chefTeks.SetActive(true);
                chef.SetActive(true);
            }
        }

        else
        {
            DialogueText.text = "";
            Index = 0;
            anim.SetBool("isOpen", false);
            TriggerButton.SetActive(false);
            if (stage1 == true)
            {
                SceneManager.LoadScene("Stage1");
            }
            else if (stage2 == true)
            {
                SceneManager.LoadScene("Stage2");
            }
            else if(stage3 == true)
            {
                SceneManager.LoadScene("Stage3");
            }

        }
    }
    
    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
        nextText = true;
    }
}
