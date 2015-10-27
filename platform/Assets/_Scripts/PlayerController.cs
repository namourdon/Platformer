using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class HeightRange {
    public float HMin, HMax;

    public HeightRange(float HMin, float HMax){
        this.HMin = HMin;
        this.HMax = HMax;
    }
}
public class PlayerController : MonoBehaviour
{
    //public variables
    public float speed = 50f;
    public float jump = 500f;
    public int initialScore = 0;
    public int livesAmount = 5;
    public Text score;
    public Text lives;
    public Text gameOver;
    public Text StartGame;
    public Text levelUp; 


    public HeightRange heightRange = new HeightRange(300f,1000f);
    //Private variables
    private AudioSource[] _audioSource;
    private AudioSource _coinSound;
    private AudioSource _slimeSound;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Animator _animator;
    private float _moving = 0;
    private bool _facingRight = true;
    private bool _ground = true;
    
    // Use this for initialization
    void Start()
    {
        this._animator = gameObject.GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        this._audioSource = gameObject.GetComponents<AudioSource>();
        this._coinSound = this._audioSource[0];
        this._slimeSound = this._audioSource[1];
    }

    void FixedUpdate() {
        float forceX = 0f;
        float forceY = 0f;

        float absVeliX = Mathf.Abs(this._rigidbody2D.velocity.x);
        float absVeliY = Mathf.Abs(this._rigidbody2D.velocity.y);
        this._moving = Input.GetAxis("Horizontal");

        if (this._moving != 0) {
            //ont bouge
            this._animator.SetInteger("AnimState", 1);
            if (this._moving > 0) {
                //droit
                if (absVeliX < this.heightRange.HMax)
                {
                    forceX = this.speed;
                    this._facingRight = true;
                    this._flip();
                }
                
            }
            else if (this._moving < 0) 
                //gauche
            {
                if (absVeliX < this.heightRange.HMax)
                {
                    forceX = -this.speed;
                    this._facingRight = false;
                    this._flip();
                }
            }

        }
        else if (this._moving == 0) 
            // on bouge pas
        {
            this._animator.SetInteger("AnimState", 0);
           
        }
        //pour sauter
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W)) {

            if (this._ground)
            {
                this._animator.SetInteger("AnimState", 2);
                if (absVeliY < this.heightRange.HMax)
                {
                    forceY = this.jump;
                    this._ground = false;

                }
            }
        }

        this._rigidbody2D.AddForce(new Vector2(forceX, forceY));
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("coin"))
        {
            this._coinSound.Play();
            this.initialScore += 10;
        }
        if (otherCollider.gameObject.CompareTag("enemy"))
        {
           // this._slimeSound.Play();
            this.livesAmount--;
            if (this.livesAmount <= 0)
            {
                this._EndGame();
            }


        }
        
        this.FinalScore();
    }
    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("ground"))
        {
            this._ground=true;
        }
    }
    private void _flip() {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1f, 1f);
        }
        else {
            this._transform.localScale = new Vector2(-1f, 1f);
        }
    }
    private void FinalScore()
    {
        this.score.text = "Score:" + this.initialScore;
        this.lives.text = "Lives:" + this.livesAmount;
    }
    private void _EndGame()
    {

        Destroy(gameObject);
        this.score.enabled = false;
        this.lives.enabled = false;
        this.gameOver.enabled = true;
        this.StartGame.enabled = true;
        this.StartGame.text = "Score: " + this.initialScore;
    }
}