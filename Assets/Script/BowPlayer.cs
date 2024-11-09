using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPlayer : Buki
{
    public GameObject ArrowFireEnterBody;

    bool IsFire = false;

    // Start is called before the first frame update
    public override void Start()
    {
        BodyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        BodyAnimator.SetBool("IsRMouseDown", false);

        if (Input.GetMouseButtonUp(0))
        {
            IsFire = true;
            BodyAnimator.SetBool("IsLMouseDown", false);
            BodyAnimator.SetBool("IsLMouseUp", true);
        }
        else if (Input.GetMouseButton(0))
        {
            BodyAnimator.SetBool("IsLMouseUp", false);
            BodyAnimator.SetBool("IsLMouseDown", true);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            BodyAnimator.SetBool("IsRMouseDown", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsFire)
        {
            IsFire = false;

            GameObject InstArrowBody = Instantiate(HandleThrowBody, ArrowFireEnterBody.transform);

            InstArrowBody.transform.parent = null;
            InstArrowBody.GetComponent<Arrow>().enabled = true;
            InstArrowBody.GetComponent<Arrow>().Fire();
        }
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� ���� �� ����Ͽ�����
    public override void ThrowObjectIsEmpty()
    {

    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� �������� ��
    public override void ChargingThrowObject()
    {

    }

    public override IEnumerator CalcNextClip()
    {
        yield return null;
    }
    public override IEnumerator UpdateAnimator()
    {
        yield return null;
    }
}
