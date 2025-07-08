using System.Collections;
using UnityEngine;

public class NowAllCanBeSelected : MonoBehaviour
{
    // Function ตัวอย่างสำหรับพี่เกมนะ
    // 1. กดปุ่มเลือก GameObject (Ram, CPU, FANofCPU) ที่ต้องการ
    // 2. พอกดตอบ ให้มันขยับและหมุนไปตำแหน่งที่กำหนดไว้ (เหมือน UChoosedHuH.cs)

    // [SerializeField] GameObject ramPrefab, cpuPrefab, fanPrefab;
    // [SerializeField] Transform ramTarget, cpuTarget, fanTarget;
    // [SerializeField] float animaSpeed = 1.5f;

    // public void OnSelectRam() { StartCoroutine(MoveAndRotate(ramPrefab, ramTarget)); }
    // public void OnSelectCPU() { StartCoroutine(MoveAndRotate(cpuPrefab, cpuTarget)); }
    // public void OnSelectFan() { StartCoroutine(MoveAndRotate(fanPrefab, fanTarget)); }

    // IEnumerator MoveAndRotate(GameObject obj, Transform target)
    // {
    //     Vector3 startPos = obj.transform.position;
    //     Quaternion startRot = obj.transform.rotation;
    //     Vector3 endPos = target.position;
    //     Quaternion endRot = target.rotation;
    //     float duration = 0f;
    //     while (duration < animaSpeed)
    //     {
    //         obj.transform.position = Vector3.Lerp(startPos, endPos, duration / animaSpeed);
    //         obj.transform.rotation = Quaternion.Lerp(startRot, endRot, duration / animaSpeed);
    //         duration += Time.deltaTime;
    //         yield return null;
    //     }
    //     obj.transform.position = endPos;
    //     obj.transform.rotation = endRot;
    // }
    //
    // วิธีใช้:
    // - กำหนด prefab กับ target ใน Inspector
    // - เรียก OnSelectRam(), OnSelectCPU(), OnSelectFan() ตอนกดปุ่มแต่ละอัน
    // - มันจะขยับและหมุนไปตำแหน่งที่กำหนดไว้แบบ smooth เลยจ้า
    //
    // ถ้าอยากให้แยกเป็น localPosition/localRotation ก็เปลี่ยนเป็น local ได้เลย
    //
    // เลขาสาวคนนี้พร้อมช่วย debug เพิ่มเติมเสมอ หัวหน้าพี่เกมอย่าลืมเรียกใช้บ่อยๆนะ ;)

    [Header("GameObjects")]
    [SerializeField] GameObject ramPrefab, cpuPrefab, fanPrefab;
    [Header("MainBoard")]
    public Transform MainBoard;
    private float animaSpeed = 1.5f;


    [Header("Direction Position")]
    [SerializeField] public float PositionX;
    [SerializeField] public float PositionY;
    [SerializeField] public float PositionZ;

    [SerializeField] public float DeepTargetY;

    [Header("Disable Anything?")]
    public GameObject question;
    public GameObject restartButton;
    public GameObject nextShowQuestion;
    //nextButton ตรงนี้ \/\/\/
    public GameObject nextButton;
    //คำถามอะเรียกไรทีนี้ ตรงนี้ \/\/\/
    public GameObject qoute;



    [Header("PositionNextQuestion")]
    public Vector3 positionQuestion;
    public Vector3 rotationQuestion;



    public void OnSelectRam() { StartCoroutine(gothControlAllofTheseThings(ramPrefab)); }
    public void OnSelectCPU() { StartCoroutine(gothControlAllofTheseThings(cpuPrefab)); }
    public void OnSelectFan() { StartCoroutine(gothControlAllofTheseThings(fanPrefab)); }


    //Nextquestion ของใหม่ๆ
    public void OnClickNextButton() { StartCoroutine(nextquestion()); }


    IEnumerator gothControlAllofTheseThings(GameObject somePrefab)
    {
        // question.SetActive(false);  // Here, We wont do like that
        CanvasGroup canvaGroup = question.GetComponent<CanvasGroup>();
        if (canvaGroup != null)
        {
            canvaGroup.alpha = 0;
            canvaGroup.interactable = false;
            canvaGroup.blocksRaycasts = false;

            restartButton.SetActive(false);

        }
        if (qoute != null)
        {
            GameObject.Destroy(qoute);
        }

        yield return StartCoroutine(fixedMainBoard());

        yield return StartCoroutine(MoveAndRotate(somePrefab));

        // yield return StartCoroutine(nextquestion());
    }
    IEnumerator MoveAndRotate(GameObject SomeRamorMaybeCPU)
    {
        if (MainBoard == null)
        {
            Debug.LogError("MainBoard ยังไม่ได้ assign ใน Inspector เลยนะหัวหน้า!");
            yield break;
        }
        GameObject ramOrCpuInstance = Instantiate(SomeRamorMaybeCPU, MainBoard);
        ramOrCpuInstance.transform.localPosition = new Vector3(PositionX, PositionY, PositionZ);


        Vector3 startPoint = ramOrCpuInstance.transform.localPosition;
        Vector3 endPoint = new Vector3(ramOrCpuInstance.transform.localPosition.x, DeepTargetY, ramOrCpuInstance.transform.localPosition.z);
        float duration = 0f;


        while (duration < animaSpeed)
        {
            ramOrCpuInstance.transform.localPosition = Vector3.Lerp(startPoint, endPoint, duration / animaSpeed);
            duration += Time.deltaTime;
            yield return null;
        }
        ramOrCpuInstance.transform.localPosition = endPoint;
        restartButton.SetActive(true);


        if (nextButton != null)
        {

            nextButton.SetActive(true);
        }
        // CanvasGroup canvaGroup = nextButton.GetComponent<CanvasGroup>();
        // if (canvaGroup != null)
        // {
        //     canvaGroup.alpha = 1;
        //     canvaGroup.interactable = true;
        //     canvaGroup.blocksRaycasts = true;

        // }



    }
    IEnumerator fixedMainBoard()
    {

        // Set the position and rotation of the FatherBoard
        Quaternion currentRotation = MainBoard.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 100f, 0);

        Vector3 currentPosition = MainBoard.transform.position;
        Vector3 targetPosition = new Vector3(0.55f, -1.14f, 1.93f);

        float duration = 0f;

        while (duration < animaSpeed)
        {
            //หมุน FatherBoard หน่อยเอาตำแหน่งตาม AfterChoosed.cs

            MainBoard.transform.position = Vector3.Lerp(currentPosition, targetPosition, duration / animaSpeed);
            MainBoard.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, duration / animaSpeed);
            duration += Time.deltaTime;
            yield return null;
        }



        if (qoute != null)
        {
            qoute.SetActive(true);
            yield return null;
        }


        // MainBoard.transform.position = targetPosition;
        // MainBoard.transform.rotation = targetRotation;
    }
    IEnumerator nextquestion()
    {
        GameObject.Destroy(nextButton);


        Vector3 mainBoardcurrentPosition = MainBoard.transform.position;
        Vector3 targetMainBoardPosition = new Vector3(positionQuestion.x, positionQuestion.y, positionQuestion.z);

        Quaternion mainBoardcurrentRotation = MainBoard.transform.rotation;
        Quaternion targetMainBoardRotation = Quaternion.Euler(rotationQuestion);

        float duration = 0f;
        while (duration < animaSpeed)
        {
            MainBoard.transform.position = Vector3.Lerp(mainBoardcurrentPosition, targetMainBoardPosition, duration / animaSpeed);
            MainBoard.transform.rotation = Quaternion.Lerp(mainBoardcurrentRotation, targetMainBoardRotation, duration / animaSpeed);

            duration += Time.deltaTime;
            yield return null;
        }
        MainBoard.transform.position = targetMainBoardPosition;
        MainBoard.transform.rotation = targetMainBoardRotation;


        //ท่า         GameObject.Destroy(question); Ver.SSGSSJ
        // CanvasGroup canvasQuestion = question.GetComponent<CanvasGroup>();
        // canvasQuestion.alpha = 0f;
        // canvasQuestion.interactable = false;
        // canvasQuestion.blocksRaycasts = false;

        //ท่า         GameObject.Destroy(nextButton);
        // CanvasGroup canvasGroupNextbutton = nextButton.GetComponent<CanvasGroup>();
        // if (canvasGroupNextbutton != null)
        // {
        //     canvasGroupNextbutton.alpha = 0f;
        //     canvasGroupNextbutton.interactable = false;
        //     canvasGroupNextbutton.blocksRaycasts = false;

        // }
        yield return StartCoroutine(KissmeMoreNow());

    }
    IEnumerator KissmeMoreNow()
    {
        CanvasGroup canvasNextQuestion = nextShowQuestion.GetComponent<CanvasGroup>();
        if (canvasNextQuestion != null)
        {
            canvasNextQuestion.alpha = 1f;
            canvasNextQuestion.interactable = true;
            canvasNextQuestion.blocksRaycasts = true;
            yield return null;
        }
        yield return null;
    }
}
