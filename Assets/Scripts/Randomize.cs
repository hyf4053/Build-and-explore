using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomize{

	public static int GetRandomInt(int min, int max){
		return Random.Range(min,max);
	}

	public static int GetRandomIntBaseFertility(int min, int max, int factor){
		return (int)Random.Range(min,max)*(factor/100);
	}

	public static bool GetRandomGrass(){
		int i = Random.Range(0,1);
		if(i==0){
			return false;
		}else{
			return true;
		}
	}
}
