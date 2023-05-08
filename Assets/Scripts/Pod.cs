using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Cecil.Cil;

public class Pod : MonoBehaviour
{
    public enum PodState
    {
        ROTATION,//ban dau
        SHOOT,//khi an xuong 
        REWIND,//khi keo len
    }
    private PodState podState = PodState.ROTATION;
    private int _angle;
    private int _slowDown;
    private int _dollar;
    [SerializeField] private int _rotateSpeed = 1;
    [SerializeField] private float _speed;
    private Vector3 _Origin;
    private Transform _Rod;
    private bool _flagRod;
    // public  Text _score;
    public Text txtScore;
    public int score = 0;
    public int muctieu = 30;
    //Time
    public int timePlay;
    public int curTime;
  //  public Text TimeText;
    private Animator _mainAnim;

    public AudioSource _audioSource;
    public AudioClip _audioROTATION;
    public AudioClip _audioSHOOT;
    public AudioClip _audioREWIND;



    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.tag);
        //da cham vao cai gi
        if (_flagRod) return;
        //lay slow down cua doi tuong
        _flagRod = true;
        _Rod = col.transform;
         
       // _Rod.SetParent(transform);
        
        if (_Rod.tag == Config.TAG_BOOM)
        {   
            _Rod.tag = this.tag;
            //boom se no
           // _mainAnim.Play("Boom_no");
            _Rod.GetComponent<Boom>().Bang(_Rod.position);
            print("boom no");
           
          //  Destroy(_Rod.gameObject);
        }
           
       
        _Rod.SetParent(transform);
        //chuyen trang thai
        _slowDown = _Rod.GetComponent<Rod>().slowDown;
        score += _Rod.GetComponent<Rod>().dollar;
        Destroy(_Rod.GetComponent<Rod>());
        podState = PodState.REWIND;
      
       
    }
    private void Awake()
    {
        curTime = timePlay;
        _mainAnim = transform.root.GetComponent<Animator>();//lay render trong lop cha
        _Origin = transform.position;//vi tri ban dau
       
        //_scoreCanvas = Camera.main.GetComponent<Canvas>();
        print(_Origin);
        print(muctieu);

    }
    IEnumerator TimeCountingDown()
    {
        yield return new WaitForSeconds(1);
       

        if (curTime > 0)
        {
            curTime--;

           UIManager.Instance.SetTimeText("00 : 00 " + curTime);
            StartCoroutine(TimeCountingDown());

        }

        else 
        {
           if(score >= muctieu)
            {
               
               UIManager.Instance.dialog2.SetDialogContent("Chiến Thắng " + "\r\nMục Tiêu : " + muctieu + "\r\nThành Tích : " + score);
               UIManager.Instance.dialog2.Show(true);
            }
           else
            {
                
                UIManager.Instance.dialog1.SetDialogContent("Thất Bại " + "\r\nMục Tiêu : " + muctieu + "\r\nThành Tích : " + score);
                UIManager.Instance.dialog1.Show(true);
            }
          
            StopAllCoroutines();
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {

        UIManager.Instance.SetTimeText("00:00 00"+ curTime);

        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
  
        StartCoroutine(TimeCountingDown());
    }
    void Update()
        {
       
        switch (podState)
            {   

                case PodState.ROTATION:
                _mainAnim.Play("Rotation");
               // AudioManager.Instance.PlaySFX("BanDau");


                if (Input.GetKeyDown(KeyCode.Space))
                        podState = PodState.SHOOT;
                    _angle += _rotateSpeed;//Tang goc quay


                    //quay 1 goc tu -70 den 70
                    if (_angle > 60 || _angle < -60)

                        _rotateSpeed *= -1;//doi chieu quay


                    transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
               
                break;


                case PodState.SHOOT:
                _mainAnim.Play("Shoot");

                //neu nhan spase thi nhay sang shoot
                //di xuong theo goc
                AudioManager.Instance.PlaySFX("Tha");
                transform.Translate(Vector3.down * (_speed - _slowDown) * Time.deltaTime);
               
                //di nguoc lai neu va cham hoac di den gioi han
                if (Mathf.Abs(transform.position.x) > 11 || (transform.position.y) < -5)
                    //chuyen trang thai
               
                podState = PodState.REWIND;
                //AudioManager.Instance.PlaySFX("vang");

                AudioManager.Instance.PlaySFX("Keo");


                //

                break;

                case PodState.REWIND:
                _mainAnim.Play("Rewind");
                

                transform.Translate(Vector3.up * (_speed - _slowDown) * Time.deltaTime);
                //den vi tri no do se dung lai
                //Mathf.Floor dung de lam tron so nguyen
               
                if (Mathf.Floor(transform.position.y) == _Origin.y)
                    {
                        if (_Rod != null)
                        {
                            _slowDown = 0;//resest
                            _flagRod = false;
                        //cong diem
                        //setDollar(_dollar);
                        setDollar(_dollar);
                        Debug.Log("Diem" + score);
                       
                            Destroy(_Rod.gameObject);
                        }
                    AudioManager.Instance.PlaySFX("BanDau");
                    transform.position = _Origin;
                        podState = PodState.ROTATION;

                    //CheckScore();  
                }
                    break;

            }
      

    }

   //public void CheckScore()
   // {
   //     if (score > 30)
   //     {


   //         Debug.Log("AAAAAAAAAAAAA");
   //         SceneManager.LoadScene(3);
   //     }
   // }
   //public void PlayGame()
   // {
   //     Time.timeScale = 1;
   // }
   // public void PauseGame()
   // {
   //     Time.timeScale = 0;
   // }
    public void setDollar(int dollar)
    {
      txtScore.text = "$: "+score.ToString();
    }
   
}
