using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CSlider : MonoBehaviour {
	public Transform targetplayer;
	public Text playerName;
	public Slider clickSlider;
	public float MaxValor;
	public float MinValor;
	public bool sube;
	public bool iniciaSlider;
	public float SliderSpeed;

    // CPlayer Reference
    [SerializeField]
    CPlayer _player;

	// Update is called once per frame
	void Start(){
		sube = false;
		//iniciaSlider = false;
	}

	void Update () {
		//this.transform.position = this.targetplayer.position + Vector3.up * 3;
			
		if (clickSlider.value == 0)
			sube = true;
		if (clickSlider.value == 6)
			sube = false;
			
		if(sube && iniciaSlider)
			clickSlider.value += SliderSpeed * Time.deltaTime;
		if(!sube && iniciaSlider)
			clickSlider.value -= SliderSpeed * Time.deltaTime;

        if (_player.GetPlayerNumber() == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StopSlider();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                StopSlider();
            }
        }
		
	}

    private void OnEnable()
    {
        float tRandomValue = Random.Range(0, 6f);
        clickSlider.value = tRandomValue;
        iniciaSlider = true;
    }

    public void AssignPlayer(Transform pHuman)
    {
        targetplayer = pHuman;
        transform.position = targetplayer.position + new Vector3(0,0.8f,0);
    }

	void StopSlider(){

		if (!iniciaSlider)
			Debug.Log ("valor del slider " + clickSlider.value);

		if (clickSlider.value > MaxValor)
            _player.Attack(false);

        if (clickSlider.value < MinValor)
            _player.Attack(false);

        if (clickSlider.value > MinValor && clickSlider.value < MaxValor)
            _player.Attack(true);

        gameObject.SetActive(false);
    }
}
