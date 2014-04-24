package tirame.lagoma;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;

import android.content.Context;
import android.widget.ListView;

public class spanishDictionary extends DatabaseSearch{
	
	
	public spanishDictionary(ListView l, Context c, String t){
		this.context = c;
		this.list = l;
		try {
			this.searchTerm = URLEncoder.encode(t, "UTF-8");
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
		}
		this.endpoint = "http://glosbe.com/gapi/translate?from=es&dest=eng&format=json&phrase="+searchTerm;
		this.term = "text";
		this.databaseURL = endpoint;
	}
	
	
	
}