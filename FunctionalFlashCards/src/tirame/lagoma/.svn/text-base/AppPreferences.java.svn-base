package tirame.lagoma;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.util.Log;

public class AppPreferences {
	private static final String APP_SHARED_PREFS = "com.aydabtu.BroadcastSMS_preferences"; //  Name of the file -.xml
	private SharedPreferences appSharedPrefs;
	private Editor prefsEditor;

	public AppPreferences(Context context)
	{
		this.appSharedPrefs = context.getSharedPreferences(APP_SHARED_PREFS, Activity.MODE_PRIVATE);
		this.prefsEditor = appSharedPrefs.edit();
	}
	
	public Editor returnEditor(){
		return prefsEditor;
	}
	public void addString(String key, String value){
		Log.i("TP", "Saved "+value+" with key "+key);
		prefsEditor.putString(key, value);
		prefsEditor.commit();
	}
	
	public String getString(String key){
		return appSharedPrefs.getString(key, "0");
	}
	public void addInt(String key, int value){
		prefsEditor.putInt(key, value);
		prefsEditor.commit();
	}
	
	public int getInt(String key){
		return appSharedPrefs.getInt(key, 0);
	}
	public ArrayList<String> getStringArray(String key) {
		Set<String> temp = appSharedPrefs.getStringSet(key, null);
		
		ArrayList<String> returnList = new ArrayList<String>(temp);
		return returnList;
		
		
	}

	public void saveStringArray(String key, ArrayList<String> text) {
		Set<String> temp = new  HashSet<String>(text);
		
		prefsEditor.putStringSet(key, temp);
		prefsEditor.commit();
	}
	
	public boolean hasKey(String key){
		
		return appSharedPrefs.contains(key);
	}
	
}

