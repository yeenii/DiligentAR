using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARTrackedImg : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public Button removeInfo;

    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedObjects;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();  //������Ʈ �޾ƿ���
        spawnedObjects = new Dictionary<string, GameObject>();
        string[] CodeName = new string[50];
        string str1 = "���׸�,01012345678,����� ������ ����2�� 38,�谡��,01023456789,��õ������ �߱� ���� 269,���Ƽ����";
        string str2 = "������,01087654321,����� ������ â���� 28-1,������,01098765432,��⵵ ���� �ϻ꼭�� ������ 28,����";
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
                GameObject newObject = Instantiate(obj); //��üȭ�ؼ� ����
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

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
            spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;

            spawnedObjects[referenceImageName].SetActive(true);
        }
        else //if tracked image tracking state is limited or none
        {
            spawnedObjects[referenceImageName].SetActive(false);
        }

        removeInfo.onClick.AddListener(() => removeInfomation(referenceImageName));

    }

    void removeInfomation(string objname)
    {
        spawnedObjects[objname].SetActive(false);
        spawnedObjects[objname] = null;
    }
}