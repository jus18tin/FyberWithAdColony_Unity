using UnityEngine;
using System.Collections;
using FyberPlugin;

public class buttonScript : MonoBehaviour {

	Ad rewardedVideoAd;

	// Use this for initialization
	void Start () {
		string appId = "33816";
		Settings settings = Fyber.With(appId)
			// optional chaining methods
			//.WithUserId(userId)
			//.WithParameters(dictionary)
			//.WithSecurityToken(securityToken)
			//.WithManualPrecaching()
			.Start();

		RewardedVideoRequester.Create()
		// optional method chaining
		//.AddParameter("key", "value")
		//.AddParameters(dictionary)
		//.WithPlacementId(placementId)
		// changing the GUI notification behaviour when the user finishes viewing the video
		//.NotifyUserOnCompletion(true)
		// you can add a virtual currency requester to a video requester instead of requesting it separately
		//.WithVirtualCurrencyRequester(virtualCurrencyRequester)
		// you don't need to add a callback if you are using delegates
		//.WithCallback(requestCallback)
		// requesting the video
			.Request();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowVideo()
	{
		Debug.Log("==ShowVideo ");
		if (rewardedVideoAd != null)
		{
			rewardedVideoAd.Start();
			rewardedVideoAd = null;
		}       
	}

	void OnEnable()
	{
		// Ad availability
		FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
		FyberCallback.AdAvailable += OnAdAvailable;
		FyberCallback.AdStarted += OnAdStarted;
		FyberCallback.AdFinished += OnAdFinished;  
	}

	void OnDisable()
	{
		// Ad availability
		FyberCallback.NativeError -= OnNativeExceptionReceivedFromSDK;
		FyberCallback.AdAvailable -= OnAdAvailable;
		FyberCallback.AdStarted -= OnAdStarted;
		FyberCallback.AdFinished -= OnAdFinished;  
	}

	public void OnNativeExceptionReceivedFromSDK(string message)
	{
		//handle exception
		Debug.Log("==error " + message);
	}

	private void OnAdAvailable(Ad ad)
	{
		Debug.Log("==OnAdAvailable ");
		switch(ad.AdFormat)
		{
		case AdFormat.REWARDED_VIDEO:
			rewardedVideoAd = ad;
			break;
			//handle other ad formats if needed
		}
	}

	private void OnAdStarted(Ad ad)
	{
		Debug.Log("==OnAdStarted ");
	}

	private void OnAdFinished(AdResult result)
	{
		switch (result.AdFormat)
		{
		case AdFormat.REWARDED_VIDEO:
			UnityEngine.Debug.Log("rewarded video closed with result: " + result.Status +
				"and message: " + result.Message);
			RewardedVideoRequester.Create().Request();
			break;
			//handle other ad formats if needed
		}
	}
}
