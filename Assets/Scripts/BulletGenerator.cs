using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BulletGenerator : MonoBehaviour
    {
        [Header("子弹生成间隔")]
        public float FireInternal = 0.5f;

        [Header("单次生成子弹最小数量")]
        public int MinBulletCount = 3;
        
        [Header("单次生成子弹最大数量")]
        public int MaxBulletCount = 6;
        
        
        // private float _currentTime;
        public GameObject Bullet;

        public Transform PlayerTrans;
        private float _nextFireTime;
        

        private void Start()
        {
            // throw new NotImplementedException();
        }

        private void Update()
        {
            
        }

       
        // /// <summary>
        // /// 生成子弹
        // /// </summary>
        // /// <returns>是否生成成功</returns>
        // public bool GenerateBullet()
        // {
        //     if (Time.time < _nextFireTime)
        //     {
        //         Debug.LogWarning("frequency too high");
        //         return false;
        //     }
        //     _nextFireTime = Time.time + FireInternal;
        //     var instantiate = Instantiate(Bullet, this.transform.position, this.transform.rotation);
        //     var bullet = instantiate.GetComponent<Bullet>();
        //     bullet.SetRotate((PlayerTrans.position - this.transform.position).normalized);
        //     return true;
        // }

        /// <summary>
        /// 生成伞状子弹
        /// </summary>
        /// <returns></returns>
        public bool GenerateRandomBullet()
        {
            if (Time.time < _nextFireTime)
            {
                Debug.LogWarning("frequency too high");
                return false;
            }
            _nextFireTime = Time.time + FireInternal;
            
            var count = Random.Range(MinBulletCount, MaxBulletCount + 1);
            //保证子弹为奇数个
            if ((count & 1) == 0)
            {
                count += 1;
            }

            int middle = count / 2;
            
            // float angle = 15f / 180f * Mathf.PI;
            float angleNum = 15;    
            
            for (int i = 0; i < count; i++)
            {
                var baseAngleNum = -middle * angleNum;
                var rotationAngle  = baseAngleNum + angleNum * i;
                rotationAngle = rotationAngle / 180f * Mathf.PI;
                GameObject tempBullet=Instantiate(Bullet);
                tempBullet.transform.position = this.transform.position;
                Bullet bullet = tempBullet.GetComponent<Bullet>();
                var old = (PlayerTrans.position - this.transform.position).normalized;
                var newRotate = new Vector3(old.x * Mathf.Cos(rotationAngle) - old.y * Mathf.Sin(rotationAngle),
                    old.x * Mathf.Sin(rotationAngle) + old.y * Mathf.Cos(rotationAngle));
                Debug.Log(newRotate);
            
                bullet.SetRotate(newRotate);


            }
           

            return true;
        }
        
    }
}