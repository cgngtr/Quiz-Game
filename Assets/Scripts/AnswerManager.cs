using System.Collections;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public GameManager _GameManager;
    public Vector3 defaultSpawnPos;
    private int selectedOption;
    public SpriteRenderer aBlock;
    public SpriteRenderer bBlock;
    public SpriteRenderer cBlock;
    public SpriteRenderer dBlock;
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject barrier3;
    public GameObject barrier4;
    public Color red;
    public Color green;
    public Color defaultcolor;


    private void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        defaultSpawnPos = new Vector3(-0.4f,-4.6f,3);
        red = new Color(160f / 255f, 64f / 255f, 50f / 255f);
        green = new Color(0f, 150f / 255f, 50f / 255f);
        defaultcolor = new Color(11f / 255f, 75f / 255f, 75f / 255f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("A"))
        {
            selectedOption = 0;
            StartCoroutine(SelectAnswer());
        }
        if (collision.CompareTag("B"))
        {
            selectedOption = 1;
            StartCoroutine(SelectAnswer());
        }
        if (collision.CompareTag("C"))
        {
            selectedOption = 2;
            StartCoroutine(SelectAnswer());
        }
        if (collision.CompareTag("D"))
        {
            selectedOption = 3;
            StartCoroutine(SelectAnswer());
        }
    }

    IEnumerator SelectAnswer()
    {
        Color correctColor = new Color(0f, 150f / 255f, 50f / 255f);
        Color incorrectColor = new Color(160f / 255f, 64f / 255f, 50f / 255f);

        aBlock.color = (_GameManager.currentQuestion.correctAnswer == 0) ? correctColor : incorrectColor;
        bBlock.color = (_GameManager.currentQuestion.correctAnswer == 1) ? correctColor : incorrectColor;
        cBlock.color = (_GameManager.currentQuestion.correctAnswer == 2) ? correctColor : incorrectColor;
        dBlock.color = (_GameManager.currentQuestion.correctAnswer == 3) ? correctColor : incorrectColor;
        
        yield return new WaitForSeconds(5f);


        _GameManager.SetCurrentQuestion();

        ResetBlockColors();

        this.transform.position = defaultSpawnPos;
        barrier1.SetActive(true);
        barrier2.SetActive(true);
        barrier3.SetActive(true);
        barrier4.SetActive(true);

        yield return null;
    }

    void SetBlockColor(SpriteRenderer block, Color color)
    {
        block.color = color;
    }

    void ResetBlockColors()
    {
        aBlock.color = defaultcolor;
        bBlock.color = defaultcolor;
        cBlock.color = defaultcolor;
        dBlock.color = defaultcolor;
    }

}
