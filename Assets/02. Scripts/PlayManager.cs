using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public GameObject enemy_Prefab;
    private Vector3 spawn_Pos;
    private float spawn_Delay;

    public Image fadein_Image;
    private PlayerCtrl pc;

    void Start()
    {
        spawn_Delay = 2f;

        pc = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    void Update()
    {
        spawn_Delay -= Time.deltaTime;
        if (spawn_Delay <= 0)
        {
            spawnEnemy();
            if (Time.realtimeSinceStartup >= 20)
                spawn_Delay = 0.5f;
            else if (Time.realtimeSinceStartup < 10)
                spawn_Delay = 2f;
            else if (Time.realtimeSinceStartup >= 10 && Time.realtimeSinceStartup < 20)
                spawn_Delay = 1f;
        }

        if (pc.HP <= 0)   // Is HP = 0   then   reload Active Scene 
            StartCoroutine(reloadScene());


    }

    void spawnEnemy()
    {
        spawn_Pos = new Vector3(Random.Range(-15f, 16f), Random.Range(-10f, 11f), 40f);
        Instantiate(enemy_Prefab, spawn_Pos, Quaternion.identity);
    }

    IEnumerator reloadScene()
    {
        fadein_Image.color = new Color(0, 0, 0, fadein_Image.color.a + 2f*Time.deltaTime);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
