using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {
    public GameObject loading_screen_obj;
    public Slider slider;
    public static int level_to_load=100;

    AsyncOperation async;
    void Start()
    {
        if (level_to_load != 100)
            LoadScreenExample(level_to_load);
        else
            LoadScreenExample(1);
    }
    public void LoadScreenExample(int LVL)
    {
        StartCoroutine(LoadingScreen(LVL));
    }
    IEnumerator LoadingScreen(int lvl)
    {
        loading_screen_obj.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
	
}
