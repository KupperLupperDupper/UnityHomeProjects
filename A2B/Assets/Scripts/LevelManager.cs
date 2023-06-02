using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask lavaMask;
    public LayerMask finishMask;

    bool inLava;
    bool isFinish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inLava = Physics.CheckSphere(GroundCheck.position, groundDistance, lavaMask);
        isFinish = Physics.CheckSphere(GroundCheck.position, groundDistance, finishMask);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }

        if(inLava)
        {
            ReloadLevel();
        }

        if(isFinish || Input.GetKeyDown(KeyCode.N))
        {
            LoadNextLevel();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(0);
        }

    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
