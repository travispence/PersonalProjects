package tirame.lagoma;

import android.content.Context;
import android.widget.ArrayAdapter;

public class Interface {
	protected String currentLanguage;
	protected Context context;
	protected AppPreferences appPrefs;

	public Interface(Context c){
		appPrefs = new AppPreferences(c);		
		this.currentLanguage = appPrefs.getString("Language");
		this.context = c;		

	}


	public GenericJSON LookupWord(String term, ArrayAdapter<String> a){
		WordReferenceJSON job = null;
		job = new WordReferenceJSON(context ,term, a, this.currentLanguage);
		return job;
	}





}
