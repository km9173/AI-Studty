using UnityEngine;
using System.Collections;

public class MonsterCtrl : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _monsterTransform;

    private double traceRange = 5.0;
    private double attackRange = 2.0;

    private const double _attackrangeDefault = 2.0;
    //private Vector3 _relativeTargetPos;
    private bool targetVisible;
    private IState _myState;
    private readonly bool _isDie = false;

    // Use this for initialization
    void Start () {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _monsterTransform = GetComponent<Transform>();

        attackRange = _attackrangeDefault;
        //_relativeTargetPos = new Vector3(0, 0);
        targetVisible = false;
    }

    // Update is called once per frame
    void Update () {
	
	}

    private IEnumerator Run()
    {
        while(!_isDie)
        {
            _myState.Run(this);
            yield return null;
        }
    }

    // TODO: Detect Player, Update dectect variable and return detect 
    public bool Detect()
    {
        double distance = Vector3.Distance(_playerTransform.position, _monsterTransform.position);
        // if detect true and can see target, then update relative target position
        return distance < traceRange;
    }

    // TODO: Get Distance
    public double GetDistance(Vector3 target)
    {
        return Vector3.Distance(_monsterTransform.position, target);
    }

    // TODO: Find Checkpoint
    public Vector3 GetCheckpoint()
    {
        return new Vector3();
    }

    public bool SetCheckpoint(Vector3 checkpoint)
    {
        // return value is possible to set checkpoint
        return true;
    }

    // TODO: Move
    public void Move()
    {

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
