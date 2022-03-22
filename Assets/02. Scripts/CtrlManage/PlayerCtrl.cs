using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform firePosition;
    public GameObject bullet;

    public Text stateText;
    public int HP;
    public int score;

    private float cooltime;

    public AudioClip fireSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        cooltime = 0.2f;
        HP = 50;
        score = 0;
        UpdateState();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        cooltime += Time.deltaTime;
        firePosition.rotation = mainCam.rotation;

        if (Input.GetMouseButtonDown(0) && cooltime>=0.2f)
        {
            Fire();
            cooltime = 0f;
        }
    }

    public void UpdateState()
    {
        stateText.text = " Score\n" + score + "\nHP\n" + HP;
    }


    void Fire()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
        audioSource.PlayOneShot(fireSound);
    }
}
