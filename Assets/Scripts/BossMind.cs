using System.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;

public class BossMind : MonoBehaviour
{
    [Header("近距离技能蓄力时间")] public float CloseSkill1ChargeTime = 1.0f;


    /// <summary>
    /// 近距离技能
    /// </summary>
    public GameObject CloseSkill;

    /// <summary>
    /// 中距离技能
    /// </summary>
    public GameObject MiddleSkill;




    
    /// <summary>
    /// 近距离技能诞生点
    /// </summary>
    public Transform CloseSpwanPos;

    private BulletGenerator _generator;


    // Start is called before the first frame update
    void Start()
    {
        _generator = GetComponent<BulletGenerator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CastChargeSkill((int) (CloseSkill1ChargeTime * 1000), CloseSkill, CloseSpwanPos.position);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CastChargeSkill((int) (CloseSkill1ChargeTime * 1000), MiddleSkill, CloseSpwanPos.position);
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            // _generator.GenerateBullet();
            _generator.GenerateRandomBullet();
        }
        
        //旋转朝向
        // this.transform.Rotate(Vector3.forward,0.1f);

    }


    //1s后释放近距离技能
    private async void CastChargeSkill(int chargeTime, GameObject skill, Vector3 spawnPos)
    {
        await Task.Delay(chargeTime);
       
        Instantiate(skill, spawnPos, this.transform.rotation);
        
    }



}