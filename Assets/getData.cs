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
			 .ValueChanged += HandleValueChanged;
	}
	void HandleValueChanged(object sender, ValueChangedEventArgs args) {
		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}
		// Do something with the data in args.Snapshot
		print(args.Snapshot.GetValue(true));
		string data = "" + args.Snapshot.GetValue(true);
		displayText(data);
	 //  string data = args.Snapshot
	}
	void displayText(string data){
		txt = gameObject.GetComponent<TextMesh>();
		txt.text="DbValue : "+data;
	}

	// Update is called once per frame
	void Update () {

	}
}
