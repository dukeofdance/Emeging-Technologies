using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;
using UnityEngine.UI;
using TMPro;

public class CharacterCustomizer : MonoBehaviour
	{
	public DynamicCharacterAvatar avatar;
	private Dictionary<string, DnaSetter> DNA;
	public TextMeshProUGUI text;

	private int currentHair;
	public List<string> hairModels = new List<string>();


	//Body Sliders
	public Slider heightSlider;
	public Slider bellySlider;

	public void OnEnable()
		{
		avatar.CharacterUpdated.AddListener(Updated);

		}
	public void OnDisable()
		{
		avatar.CharacterUpdated.RemoveListener(Updated);
		}
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
				}
			DNA["headSize"].Set(1f);
			avatar.BuildCharacter();

			}

		if (Input.GetKeyDown(KeyCode.F4))
			{
			avatar.SetColor("Hair", Color.black);
			}
		}

	public void SwitchSex(bool male)
		{

		if (male && avatar.activeRace.name != "HumanMaleHighPoly")
			avatar.ChangeRace("HumanMaleHighPoly");
		if (!male && avatar.activeRace.name != "HumanFemaleHighPoly")
			avatar.ChangeRace("HumanFemaleHighPoly");
		}

	void Updated(UMAData data)
		{
		DNA = avatar.GetDNA();
		//heightSlider.value = DNA["headSize"].Get();
		//bellySlider.value = DNA["belly"].Get();
		}

	public void HeightChange(float val)
		{
		DNA["headSize"].Set(val);
		avatar.BuildCharacter();
		}
	public void BellyChange(float val)
		{
		DNA["belly"].Set(val);
		avatar.BuildCharacter();
		}
	public void ChangeSkinColor(Color col) 
		{
		avatar.SetColor("Skin", col);
		avatar.UpdateColors(true);
		
		}
	public void ChangeHair(bool plus) 
		{
		if (plus)
			currentHair++;
		else
			currentHair--;

		currentHair = Mathf.Clamp(currentHair, 0, hairModels.Count - 1);

		if (hairModels[currentHair] == "None")
			avatar.ClearSlot("Hair");
		else
			avatar.SetSlot("Hair", hairModels[currentHair]);

		text.text = hairModels[currentHair];

		avatar.BuildCharacter();

		Debug.Log(avatar.GetWardrobeItemName("Hair"));
		}

	}
