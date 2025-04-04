using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Transform _canvasTrans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _startButton.onClick.AddListener(OnClickStartButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);

        Debug.Log("OnClickStartButton");

        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
        Debug.Log("ResGo : " + resGO);

        GameObject sceneGO = Instantiate(resGO, _canvasTrans, false);
        ModeUI uiComp = sceneGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);

        
    }
    private void OnClickTimeAttackMode()
    {
        Debug.Log("OnClickTimeAttackMode");

        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);

        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        Instantiate(resGO);
    }
    private void OnClickStageMode()
    {

    }
}
