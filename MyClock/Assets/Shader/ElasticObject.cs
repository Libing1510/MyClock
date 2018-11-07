using System.Collections;using System.Collections.Generic;using UnityEngine;

interface IElastic{    void OnElastic(RaycastHit hit);}[RequireComponent(typeof(MeshRenderer))]public class ElasticObject : MonoBehaviour, IElastic{    public Transform rayOg;    private static int s_pos, s_nor, s_time;    static ElasticObject()    {        s_pos = Shader.PropertyToID("_Position");        s_nor = Shader.PropertyToID("_Normal");        s_time = Shader.PropertyToID("_PointTime");    }    private MeshRenderer mesh;    private void Start()    {        mesh = GetComponent<MeshRenderer>();
    }
    //调用该方法
    public void OnElastic(RaycastHit hit)    {
        //反弹的坐标
        Vector4 v = transform.InverseTransformPoint(hit.point);
        //受影响顶点范围的半径
        v.w = 0.6f;        mesh.material.SetVector(s_pos, v);
        //法线方向，该值为顶点偏移方向，可自己根据需求传。
        v = transform.InverseTransformDirection(hit.normal.normalized);
        //反弹力度
        v.w = 0.2f;        mesh.material.SetVector(s_nor, v);
        //重置时间
        mesh.material.SetFloat(s_time, Time.time);        Debug.Log(s_pos+"*"+ s_nor+"*"+ s_time);    }    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = new Ray(rayOg.position, rayOg.forward);
            Debug.DrawRay(ray.origin, ray.direction,Color.red);
           
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider!=null)
            {
                OnElastic(hit);
                Debug.Log(hit.point);
            }


        }
    }}