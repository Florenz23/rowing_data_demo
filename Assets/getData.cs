using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class getData : MonoBehaviour {

	// Use this for initialization
	public TextMesh txt;
	void Start () {
		// Set up the Editor before calling into the realtime database.
	 // Get the root reference location of the database.
	 FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://rowing2323.firebaseio.com/");
	 DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
	 FirebaseDatabase.DefaultInstance
		 .GetReference("message/check/moin")
		 .GetValueAsync().ContinueWith(task => {
			 if (task.IsFaulted) {
				 // Handle the error...
			 }
			 else if (task.IsCompleted) {
				 DataSnapshot snapshot = task.Result;
				 string value = "" + snapshot.GetValue(true);
				 displayText(value);
				 // Do something with snapshot...
			 }
		 });

	}
	void displayText(string data){
		txt = gameObject.GetComponent<TextMesh>();
		txt.text="DbValue : "+data;
	}

	// Update is called once per frame
	void Update () {

	}
}
