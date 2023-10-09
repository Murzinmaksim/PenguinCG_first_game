using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hook : MonoBehaviour
{
    private bool _catchingFish;
    private bool _pauseActive;
    [SerializeField] private int _rewardClick;
    [SerializeField] private int _rewardCatch;
    private int _multiplicationMoney;
   [SerializeField] private GameObject _flyMoney;
    private GameObject _fish; 
    private bool _isDraggingLeft = false;
    private float _speedRod;
    private GameObject _pointStart;
    private GameObject _rod;
    private Animator _anim;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private AudioSource _lescSound;
    [SerializeField] private GameObject _CoinManager;
    [SerializeField] private GameObject _GameManager;

    void Start()
    {
       
        _anim = _rod.GetComponent<Animator>();
        gameObject.transform.position = new Vector2(_pointStart.transform.position.x, gameObject.transform.position.y);

        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
        if (Progress.Instance.PlayerInfo.CoinForNewLive != 0)
        {
            _CoinManager.GetComponent<CoinManager>().NewLive();
        }
    }

        void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //   addScore(1000);  
        //}

            Vector3[] positions = new Vector3[2];
        positions[0] = _pointStart.transform.position; 
        positions[1] = transform.position;
        _lineRenderer.positionCount = positions.Length;
        _lineRenderer.SetPositions(positions);

        if (_pauseActive == false) {
            if (_catchingFish)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _anim.SetTrigger("catch");
                    if (Progress.Instance.PlayerInfo.SoundOff != true)
                    {
                        _lescSound.Play();
                    }
                    transform.position += new Vector3(0f, 1f, 0f);
                    addScore(_rewardClick);

                    if (gameObject.transform.position.y > 1.7f)
                    {
                        _catchingFish = false;
                        addScore(_rewardCatch);
                        Destroy(_fish);
                        gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    }

                }
            }
            else
            {
                if (worldPosition.y < 2.7f && worldPosition.y > -4.5f)
                {
                    if (_isDraggingLeft)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + moveHook1(worldPosition), 0);
                    }
                }
            }
        }
    }

    private float moveHook1(Vector2 worldPosition)
    {   
        if (Mathf.Abs(worldPosition.y - transform.position.y) > 0.2f) {
            if (transform.position.y > worldPosition.y)
            {
                return -_speedRod;
            }
            return _speedRod;
        }
        return 0f;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            _isDraggingLeft = true;
            _anim.SetBool("catchB", true);
        }
    }

    void OnMouseUp()
    {
        _isDraggingLeft = false;
        _anim.SetBool("catchB", false);
    }

    public void pauseActive(bool pauseActive)
    {
        _pauseActive = pauseActive;
    }

    public void catchFish(GameObject fish)
    {
        if (fish.GetComponent<Fish>().GetDethIndex() == 0)
        {
            if (!_catchingFish)
            {
                _catchingFish = true;
                _fish = fish;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                _fish.GetComponent<Transform>().Rotate(0f, 0f, 90f);
                _fish.transform.parent = gameObject.transform;

                _fish.GetComponent<Fish>().renameMove(gameObject);
                _fish.GetComponent<Transform>().position = gameObject.transform.position;
            }
        }else
        {  
            _CoinManager.GetComponent<CoinManager>().finalFishing();
            _GameManager.GetComponent<GameManager>().ShowFinishWindow();
        }
    }

    public void addRewardFish(int addRewardClick, int addRewardCatch)
    {
        _rewardClick = addRewardClick;
        _rewardCatch = addRewardCatch;
    }

    public void addRod(GameObject rod, GameObject pointStart, float speedRod)
    {
        _rod = rod;
        _pointStart = pointStart;
        _speedRod = speedRod;
    }

    public void addBoat(int multiplicationMoney)
    {
        _multiplicationMoney = multiplicationMoney;
    }

    public bool SoundOff()
    {
        bool state;
        if (Progress.Instance.PlayerInfo.SoundOff == true)
        {
            state = false;
            Progress.Instance.PlayerInfo.SoundOff = state;
            return state;
        }
        state = true;
        Progress.Instance.PlayerInfo.SoundOff = state;
        return state;
  
    }

    private void addScore(int money)
    {
        int sumMoney = money * _multiplicationMoney;
        _CoinManager.GetComponent<CoinManager>().AddCoins(sumMoney);

        _CoinManager.GetComponent<CoinManager>().updateScore();

        GameObject newInscription = Instantiate(_flyMoney, transform.position, Quaternion.identity);

        TextMeshProUGUI content = newInscription.transform.GetChild(0).GetChild(0).
            gameObject.GetComponent<TextMeshProUGUI>();
        content.text = "+" + sumMoney;

        float xDirection = Random.Range(-1f, 3f);
        float yDirection = Random.Range(-1f, 3f);
        Vector3 randomDirection = new Vector3(xDirection, yDirection, 0f);

        Rigidbody2D inscriptionRigidbody = newInscription.GetComponent<Rigidbody2D>();
        inscriptionRigidbody.AddForce(randomDirection * 100f);
    }
}
