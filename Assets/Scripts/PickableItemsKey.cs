using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemsKey : PickableItems
{
    public GameObject keyprefab;
    public GameObject clonedkeyprefab;

    public bool isgreendoorunlocked;
    public bool isredfoorunlocked;
    public bool isorangedoorunlocked;

    

    

    public void DestroyAndFollow()
    {
        
        if (IsMainCharacterNear() && CompareTag("redKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y - 0.5f, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
            
          
        }
        else if (IsMainCharacterNear() && CompareTag("greenKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
        }
        else if (IsMainCharacterNear() && CompareTag("orangeKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y + 0.5f, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
        }
       
    }
 
    void ClonedKeyDestoyer()
    {
        isgreendoorunlocked = DoorsGreen.isdoorunlocked;
        if (isgreendoorunlocked)
        {
            Destroy(GameObject.Find("keyGreen(Clone)"));           
        }
        isorangedoorunlocked = DoorsOrange.isdoorunlocked;
        if (isorangedoorunlocked)
        {
            Destroy(GameObject.Find("keyOrange(Clone)"));
        }
        isredfoorunlocked = DoorsRed.isdoorunlocked;
        if (isredfoorunlocked)
        {
            Destroy(GameObject.Find("keyRed(Clone)"));
        }
    }
    

    private void FixedUpdate()
    {
        DestroyAndFollow();
        ClonedKeyDestoyer();
    }





    /*
     * 
     * clonedkeyprefab.transform.position = new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y,
              maincharacter.transform.position.z);
     * class Keys
    {
        private int id;
        private string keyname;

        public int Id { get => id; set => id = value; }
        public string Keyname { get => keyname; set => keyname = value; }

        public  Keys(int id, string name)
        {
            this.id = id;
            this.Keyname = name;
        }
    }

    static void Main(string[] args)
    {
        List<Keys> keywehave = new List<Keys>();
        keywehave.Add(new Keys(0, "greenKey"));
        keywehave.Add(new Keys(1, "redKey"));
        keywehave.Add(new Keys(2, "orangeKey"));
    }
     * 
     * 
     * 
     */
}
