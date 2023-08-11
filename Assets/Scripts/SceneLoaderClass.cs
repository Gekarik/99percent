using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderClass : MonoBehaviour
{
    [SerializeField] private RectTransform rect;

    [Header("Prefab Settings")]
    [SerializeField] private GameObject activeDragNDropBar;
    [SerializeField] private GameObject clickPointerBar;
    [SerializeField] private GameObject movePointerBar;
    [SerializeField] private GameObject passiveDragNDropBar;
    [SerializeField] private GameObject rotationBar;
    [SerializeField] private GameObject sliderZoneBar;

    [SerializeField] private PrefabList choosedPrefab = PrefabList.ActiveDragNDropBar;

    [SerializeField] private SceneList choosedScene = SceneList.MainMenu;

    [Space]
    private bool isloaded;

    private int counterLoadedScenes = 0;

    string[] scenesNames = {"Level1","Level2","Level3","Level4","Level5","FinalBoss"};

    private enum PrefabList
    {
        ActiveDragNDropBar,
        ClcikPointerBar,
        MovePointerBar,
        PassiveDragNDropBar,
        RotationBar,
        SliderZoneBar
    }

    private enum SceneList
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    private void LoadPrefab(GameObject prefabObj)
    {
        GameObject prefab = Instantiate(prefabObj, rect);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            LoadScene();
        if(Input.GetKeyDown(KeyCode.K))
            UnloadScene();
        if (Input.GetKeyDown(KeyCode.C))
            Debug.Log(SceneManager.GetActiveScene());       

    }

    private void LoadScene()
    {
        if (!isloaded)
        {
            SceneManager.LoadSceneAsync(scenesNames[counterLoadedScenes], LoadSceneMode.Additive);
            isloaded = true;
        }
        
    }


    private void UnloadScene()
    {
        if (isloaded)
        {
            SceneManager.UnloadSceneAsync(scenesNames[counterLoadedScenes]);
            isloaded = false;
            if(counterLoadedScenes<5)
                counterLoadedScenes++;
        }

    }

    [ContextMenu("Test")]
    private void Test()
    {
        //LoadPrefab(activeDragNDropBar);
        //SceneManager.MergeScenes(SceneManager.GetSceneByName("Level1"),SceneManager.GetActiveScene());
    }
}
