using UnityEngine;

public class NextQuestions : MonoBehaviour
{
    public GameObject questionsAF;

    public void wouldUtellAnyoneAboutthis()
    {
        questionsAF.SetActive(true);
    }
}
