using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class CharacterCustomizer : MonoBehaviour
{
    private DynamicCharacterAvatar avatar;
    private Dictionary<string, DnaSetter> DNA;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<DynamicCharacterAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) 
            {

            avatar.SetSlot("Chest", "MaleHoodie_Recipe");
            avatar.BuildCharacter();
            }
        if (Input.GetKeyDown(KeyCode.F2))
            {

            avatar.ClearSlot("Chest");
            avatar.BuildCharacter();
            }

        if (Input.GetKeyDown(KeyCode.F3))
            {

            if (DNA == null) 
                {
                DNA = avatar.GetDNA();

                DNA["headSize"].Set(1f);
                avatar.BuildCharacter();

                }

            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
            avatar.SetColor("Hair", Color.black);
            }
    }

    public void SwitchSex(bool male) 
        {

        if (male && avatar.activeRace.name != "HumanMaleDCS")
            avatar.ChangeRace("HumanMaleDCS");
        if (!male && avatar.activeRace.name != "HumanFemaleDCS")
            avatar.ChangeRace("HumanFemaleDCS");
        
        }
}
