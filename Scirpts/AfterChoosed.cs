using System.Collections;
using UnityEngine;

public class AfterChoosed : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField]
    Transform mainBoard;
    float allSpeed = 1.2f;
    [SerializeField]
    Transform ram;

    [Header("SetButton")]
    [SerializeField]
    GameObject buttonRestart;


    public void ChooseMemore()
    {
        StartCoroutine(ImaControlTheseAllMySelf());
    }

    IEnumerator ImaControlTheseAllMySelf()
    {
        Vector3 currentMainBoardPosition = mainBoard.position;
        Vector3 MainBoardTarget = new Vector3(0, mainBoard.position.y, 4.31f);

        float MecanstartWhileLoop = 0;
        while (MecanstartWhileLoop < allSpeed)
        {
            mainBoard.position = Vector3.Lerp(currentMainBoardPosition, MainBoardTarget, MecanstartWhileLoop / allSpeed);
            MecanstartWhileLoop += Time.deltaTime;
            yield return null;
        }
        mainBoard.position = MainBoardTarget;

        StartCoroutine(nowRotationHuh());

    }

    IEnumerator nowRotationHuh()
    {
        Quaternion currentMainBoardRotation = mainBoard.rotation;
        Quaternion MainBoardTarget = Quaternion.Euler(0, 100f, 0);

        float MeAgain = 0f;
        while (MeAgain < allSpeed)
        {
            mainBoard.rotation = Quaternion.Lerp(currentMainBoardRotation, MainBoardTarget, MeAgain / allSpeed);
            MeAgain += Time.deltaTime;

            yield return null;
        }
        mainBoard.rotation = MainBoardTarget;
        StartCoroutine(SlideRam());

    }

    IEnumerator SlideRam()
    {
        Vector3 currentRamPosition = ram.position;
        Vector3 RamTarget = new Vector3(-0.52f, 0.78f, 5.9f);

        Vector3 hero = new Vector3(0.75f, 1f, 1f);
        ram.localScale = hero;

        float MeRamMyBro = 0.65f;
        while (MeRamMyBro < allSpeed)
        {
            ram.position = Vector3.Lerp(currentRamPosition, RamTarget, MeRamMyBro / allSpeed);

            MeRamMyBro += Time.deltaTime;
            yield return null;
        }
        ram.position = RamTarget;
        StartCoroutine(InTimeRight());
    }

    IEnumerator InTimeRight()
    {
        Quaternion currentRamRotation = ram.rotation;
        Quaternion RamTargetRotation = Quaternion.Euler(90f, 10f, 0f);


        float MeRamAgain = 0f;
        while (MeRamAgain < allSpeed)
        {
            ram.rotation = Quaternion.Lerp(currentRamRotation, RamTargetRotation, MeRamAgain / allSpeed);

            MeRamAgain += Time.deltaTime;
            yield return null;
        }
        ram.rotation = RamTargetRotation;
        StartCoroutine(InSocket());


    }
    IEnumerator InSocket()
    {
        Vector3 currentRamPosition = ram.position;
        Vector3 RamTargetDownasf = new Vector3(ram.position.x, -0.53f, ram.position.z);

        float MeRamAgain = 0f;
        while (MeRamAgain < allSpeed)
        {
            ram.position = Vector3.Lerp(currentRamPosition, RamTargetDownasf, MeRamAgain / allSpeed);
            MeRamAgain += Time.deltaTime;
            yield return null;
        }
        ram.position = RamTargetDownasf;
        buttonRestart.SetActive(true);
    }
}
