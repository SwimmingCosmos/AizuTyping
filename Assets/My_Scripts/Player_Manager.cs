using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using My_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private int speed = 20;
    [SerializeField] private Animator _animator;
    public Image[] items = new Image[4]; // アイテムをゲットするためのやつ
    public int[] itemnumber = new int[4] ;
    public  TextMeshProUGUI goodtext;
    public int goodPoint = 0;
    public bool[] projectnumbers = {false,true,false};//統括
    public float movespeed = 0.5f;
    public TextMeshProUGUI texts;
    public TextMeshProUGUI whotext;
    public Music_Manager mm;
    public bool[] hai = new bool[19];
    private Rigidbody rb;
    [SerializeField] private bool b;
    //a
    //[SerializeField] private Animator[] anime = new Animator[3];
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized*movespeed;
        //_animator.SetBool("walk",false);
        _animator.SetBool("moonwalk",input.z> 0);
        if (input.z == 0 && input.x != 0)
        {
            //Vector3 scale = this.transform.localScale;
            _animator.SetBool("walk",true);
            if (input.x < 0)
            {
                this.transform.localScale = new Vector3(2, 2, 1);
                
            }
            else
            {
                this.transform.localScale = new Vector3(-2, 2, 1);
                //scale.x = 2;
            }
        }
        else
        {
            _animator.SetBool("walk",false);
        }

        if (input.z == 0 && input.x == 0)
        {
            _animator.speed = 0;
        }
        else
        {
            _animator.speed = 1;
        }
        
        //player.position += input;
        rb.velocity = input*speed;
        //camera.position += input;
        camera.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.75f,
            player.transform.position.z - 10);
       if (transform.position.x < -250 || transform.position.x > 250 || transform.position.z < -250 ||
           transform.position.z > 250)
       {
           if (b)
           {
               transform.position = new Vector3(7, 1.13f, -7);
               camera.position = new Vector3(7, 4.88f, -17.1f);
           }
       }
    }

    public void Getitem()
    {
        
    }

    /*private void OnCollisionEnter(Collision other)
    {
        f (other.gameObject.tag == "wall")
        {
            input
        }
    }*/
}
