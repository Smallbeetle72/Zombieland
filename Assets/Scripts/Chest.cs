using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;

    public GameObject m_revealNumberGO;


    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        //Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;

        
        StartCoroutine(RevealNumber());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }

    IEnumerator RevealNumber()
    {
        if (m_revealNumberGO != null)
        {
            Image img = m_revealNumberGO.GetComponent<Image>();
            Color c = Color.black;
            while(img.color.a > 0f)
            {
                c.a -= Time.deltaTime;
                img.color = c;
                yield return null;
            }
        }

    }
}
