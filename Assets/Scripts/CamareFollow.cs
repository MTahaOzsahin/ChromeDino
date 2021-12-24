using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamareFollow : MonoBehaviour
{
    
        Transform maincharacter;     
        public Vector3 offset;
        
        private void Awake()
        {      
            maincharacter = GameObject.FindGameObjectWithTag("player").transform;
        }
        void cameramovement()
        {
            this.transform.position = new Vector3(maincharacter.position.x + offset.x, maincharacter.position.y + offset.y,
           maincharacter.position.z + offset.z);
        }
        private void FixedUpdate()
        {
            cameramovement();
        }
    
        /*
        Transform maincharacter;
        Transform camerapos;
        public Vector3 offset;
        Vector3 diff;
        private void Awake()
        {
            camerapos = GetComponent<Transform>();
            maincharacter = GameObject.FindGameObjectWithTag("player").transform;
        }
        void cameramovement()
        {
            diff = new Vector3(maincharacter.position.x - camerapos.position.x, maincharacter.position.y - camerapos.position.y,
                maincharacter.position.z - camerapos.position.z);
            if (diff.x <= -8f)
            {
                camerapos.Translate(-6, 0, 0 * Time.deltaTime); 

               // this.transform.position = new Vector3(camerapos.position.x + -offset.x, camerapos.position.y,
              // camerapos.position.z);
            }
            else if (diff.x >= 8f)
            {
                camerapos.Translate(6, 0, 0 * Time.deltaTime);
               // this.transform.position = new Vector3(camerapos.position.x + offset.x, camerapos.position.y,
              // camerapos.position.z);
            }
            else if (diff.y <= -2.5f )
            {
                camerapos.Translate(0, -2, 0 * Time.deltaTime);
            }
            else if (diff.y >= 2.5f)
            {
                camerapos.Translate(0, 2, 0 * Time.deltaTime);
            }
        }
        private void FixedUpdate()
        {
          cameramovement();
        }

        */
}
