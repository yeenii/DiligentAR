using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARTrackedImg : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public Button removeInfo; //popup yes 버튼
    public GameObject defaultUI; //디폴트 UI
    public GameObject verifiUI; //이중인증 UI
    public Button verifiBtn; //이중인증 확인 버튼

    private bool verifiChk = false; // 이중인증 체크 변수

    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedObjects;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();  //컴포넌트 받아오기
        spawnedObjects = new Dictionary<string, GameObject>();
        string[] CodeName = new string[50];

        defaultUI.SetActive(true); //디폴트 UI 초기 세팅 값 : true 
        verifiUI.SetActive(false);  //이중인증 UI 초기 세팅 값 : false 

        string str1 = "남그린,01012345678,서울시 강서구 마곡2로 38,김가현,01023456789,인천광역시 중구 제로 269,기념티셔츠";
        string str2 = "정예은,01087654321,서울시 마포구 창전로 28-1,성예원,01098765432,경기도 고양시 일산서구 산현로 28,도서";
        string[] DelInfo1 = str1.Split(new char[] { ',' });
        string[] DelInfo2 = str2.Split(new char[] { ',' });

        int num = trackedImageManager.referenceLibrary.count;
        for (int i = 0; i < num; i++)
        {
            CodeName[i] = (i + 1).ToString("000");
        }

        for (int i = 0; i < num; i++)
        {
            foreach (GameObject obj in placeablePrefabs)
            {
                GameObject newObject = Instantiate(obj); //실체화해서 저장
                newObject.name = CodeName[i];
                newObject.SetActive(false);
                if (newObject.name == "001")
                {
                    newObject.transform.GetChild(1).GetComponent<Text>().text = DelInfo1[0];
                    newObject.transform.GetChild(2).GetComponent<Text>().text = DelInfo1[1];
                    newObject.transform.GetChild(3).GetComponent<Text>().text = DelInfo1[2];

                    newObject.transform.GetChild(4).GetComponent<Text>().text = DelInfo1[3];
                    newObject.transform.GetChild(5).GetComponent<Text>().text = DelInfo1[4];
                    newObject.transform.GetChild(6).GetComponent<Text>().text = DelInfo1[5];
                    newObject.transform.GetChild(7).GetComponent<Text>().text = DelInfo1[6];
                }
                else
                {
                    newObject.transform.GetChild(1).GetComponent<Text>().text = DelInfo2[0];
                    newObject.transform.GetChild(2).GetComponent<Text>().text = DelInfo2[1];
                    newObject.transform.GetChild(3).GetComponent<Text>().text = DelInfo2[2];

                    newObject.transform.GetChild(4).GetComponent<Text>().text = DelInfo2[3];
                    newObject.transform.GetChild(5).GetComponent<Text>().text = DelInfo2[4];
                    newObject.transform.GetChild(6).GetComponent<Text>().text = DelInfo2[5];
                    newObject.transform.GetChild(7).GetComponent<Text>().text = DelInfo2[6];
                }

                spawnedObjects.Add(newObject.name, newObject);
            }
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;

        setVerifi();

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            if (verifiChk) //이중 인증 완료 되었다면 실행
            {
                defaultUI.gameObject.SetActive(false);

                spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
                spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;

                spawnedObjects[referenceImageName].SetActive(true);
            }
            //else setVerifi(); //이중 인증 완료되지 않았다면, 이중 인증 재시도
        }
        else //if tracked image tracking state is limited or none
        {
            spawnedObjects[referenceImageName].SetActive(false);
        }

        removeInfo.onClick.AddListener(() => removeInfomation(referenceImageName));

    }

    void setVerifi()
    {
        if (verifiChk)
        {
            //이중 인증 체크가 완료된 상태
            verifiUI.SetActive(false);
        }
        else
        {
            //이중 인증 체크가 완료되지 않은 상태
            verifiUI.SetActive(true);
            verifiBtn.onClick.AddListener(showPrefabImg);
        }
    }

    void showPrefabImg()
    {
        verifiUI.SetActive(false); //이중 인증 UI 끄기
        verifiChk = true; //체크 상태 true로 변경
    }

    void removeInfomation(string objname)
    {
        spawnedObjects[objname].SetActive(false);
        spawnedObjects[objname] = null;
    }
}