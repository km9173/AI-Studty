using UnityEngine;
using System.Collections;

public class MonsterCtrl : MonoBehaviour
{
    private Animator animator;
    private Transform _playerTransform;
    private Transform _monsterTransform;
    private Vector3 _checkPoint = Vector3.zero;

    private double traceRange = 5.0f;
    private double attackRange = 0;
    public float speed = 0.1f;

    private const double _attackrangeDefault = 0;
    private bool targetVisible;
    private IState _myState;
    private readonly bool _bDie = false;

    // Use this for initialization
    void Start () {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _monsterTransform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        attackRange = _attackrangeDefault;
        targetVisible = true;
        ChangeState(StateManager.GetIState(StateManager.State.Patrol));
        StartCoroutine(Run());
    }

    // Update is called once per frame
    void Update () {
	
	}

    private IEnumerator Run()
    {
        while(!_bDie)
        {
            _myState.Run(this);
            yield return null;
        }
    }

    // TODO: Detect Player, Update dectect variable and return detect 
    public bool Detect()
    {
        float distance = GetDistance(_playerTransform.position);
        // if detect true and can see target, then update relative target position
        if (GetTargetVisible() && distance < traceRange)
        {
            this._checkPoint = _playerTransform.position;
            return true;
        }
                
        return false;
    }

    // TODO: Get Distance
    public float GetDistance(Vector3 target)
    {
        return Vector3.Distance(_monsterTransform.position, target);
    }

    // TODO: Find Checkpoint
    public Vector3 GetCheckpoint()
    {
        return _checkPoint;
    }

    public bool SetCheckpoint(Vector3 checkpoint)
    {
        this._checkPoint = checkpoint;
        // return value is possible to set checkpoint
        return true;
    }

    // TODO: Move
    public void Move()
    {
        Vector3 direction = _monsterTransform.position - this._checkPoint;
        if (direction.magnitude > 0.5f)
        {
            animator.SetBool("bWalk", true);
            direction /= direction.magnitude;
            _monsterTransform.Translate(Time.smoothDeltaTime * direction * speed, Space.Self);
        }
        else
        {
            animator.SetBool("bWalk", false);
            _checkPoint = Vector3.zero;
        }
    }

    //
    public void PaceAround()
    {

    }

    public bool GetTargetVisible()
    {
        return targetVisible;
    }

    public void ChangeState(IState state)
    {
        _myState = state;
    }

    public bool IsAttackable()
    {
        if (GetDistance(_playerTransform.position) <= attackRange)
            return true;
        return false;
    }

    public void Attack()
    {

    }
}
