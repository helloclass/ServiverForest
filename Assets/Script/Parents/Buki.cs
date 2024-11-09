using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buki : Object
{
    public GameManager gameManager;

    public Animator BodyAnimator;

    // ���⸦ ������ ���� �񿴴ٸ� HandPlayer�� �����Ѵ�.
    public GameObject HandPlayer;
    // ������ ���� ������Ʈ
    public GameObject HandleThrowBody;
    public ThrowObject throwObject;

    protected bool isAttack1;
    protected bool isAttack2;
    protected bool isAttack3;

    protected float CheckTimeOut;
    protected const float TimeOutLimit = 0.75f;
    protected float TimeOutOfSwing;
    protected float TimeOutOfHit;

    protected bool isAnimationDone1;
    protected bool isAnimationDone2;
    protected bool isAnimationDone3;

    protected bool isHitDone1;
    protected bool isHitDone2;
    protected bool isHitDone3;

    // �Ѿ�, ȭ�� ���� ���� �� �ִ� ���� ����
    protected int NumberOfThrowHandle = 1;
    // �ִ� ���� �� ����
    protected int MaxNumberOfThrowHandle = 1;

    protected bool isThrowAble = false;
    protected bool isThrowHold = false;
    protected bool isThrow = false;

    public virtual void Awake()
    {
        throwObject = HandleThrowBody.GetComponent<ThrowObject>();
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        isThrowAble = true;

        isAttack1 = false;
        isAttack2 = false;
        isAttack3 = false;

        CheckTimeOut = 0.0f;

        TimeOutOfSwing = 0.3f;
        TimeOutOfHit = 0.7f;

    isAnimationDone1 = false;
        isAnimationDone2 = false;
        isAnimationDone3 = false;

        isHitDone1 = false;
        isHitDone2 = false;
        isHitDone3 = false;

        HandleThrowBody.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(UpdateAnimator());
        StartCoroutine(CalcNextClip());
    }

    // BukiPlayer�� Ȱ��ȭ �Ǿ��� �� �ڷ�ƾ�� �ٽ� ���۽�Ų��.
    public virtual void OnEnable()
    {
        // Run Start..?

        StartCoroutine(UpdateAnimator());
        StartCoroutine(CalcNextClip());
    }

    // BukiPalyer�� ��Ȱ��ȭ �Ǿ��� �� �ڷ�ƾ�� ������ �����Ų��.
    public virtual void OnDisable()
    {
        // Run OnDestroy..?

        StopCoroutine(UpdateAnimator());
        StopCoroutine(CalcNextClip());
    }

    public virtual void OnDestroy()
    {
        StopCoroutine(UpdateAnimator());
        StopCoroutine(CalcNextClip());
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� ���� �� ����Ͽ�����
    public abstract void ThrowObjectIsEmpty();
    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� �������� ��
    public abstract void ChargingThrowObject();

    public abstract IEnumerator UpdateAnimator();
    public abstract IEnumerator CalcNextClip();
}
