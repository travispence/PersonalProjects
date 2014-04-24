package tirame.lagoma;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.content.Context;
import android.util.Log;
import android.widget.ArrayAdapter;

public class WordReferenceJSON extends GenericJSON {
	String[] containsAllParts = new String[6];
	String dict;
	protected String originalTerm;
	protected String originalTermTrans;
	Map<String, String[]> retrievedInformation = new HashMap<String, String[]>();

	public WordReferenceJSON(Context c, String term, ArrayAdapter<String> a, String dict) {
		super(c, term, a);
		this.dict = dict;
		this.urlString = buildURL();
		Log.i("TP", "IN WF CONSTRUCTOR... searchTerm is "+searchTerm);
		// TODO Auto-generated constructor stub
	}

	@Override
	String buildURL() {
		// TODO Auto-generated method stub
		Log.i("TP", "Search term is "+this.searchTerm);
		String temp = "http://api.wordreference.com/0.8/a8ee8/json/"+this.dict+"/"+this.searchTerm;
		Log.i("TP", "temp is "+temp);
		return temp ;
	}

	@Override
	String[] parseResults(JSONObject job) {
		List<String> sendToAdapter = new ArrayList<String>();

		try {
			JSONObject term0 = job.getJSONObject("term0");



			if (term0.has("PrincipalTranslations")){
				JSONObject principalTranslation = term0.getJSONObject("PrincipalTranslations");
				JSONArray principalTranslationArray = principalTranslation.names();
				int length = principalTranslationArray.length();
				for (int i = 0; i < length; i++){
					JSONObject results = principalTranslation.getJSONObject( principalTranslationArray.getString(i));
					JSONObject oTerm = results.getJSONObject("OriginalTerm");
					JSONObject firstTrans = results.getJSONObject("FirstTranslation");
					String retrievedMeaning = oTerm.getString("sense");
					sendToAdapter.add(retrievedMeaning);	
					this.originalTerm = oTerm.getString("term");
					Log.i("TP", "origterm = "+this.originalTerm);
					if(oTerm.has("term")){
						containsAllParts[0] = oTerm.getString("term");
					}
					else{
						containsAllParts[0] = "";
					}
					if(oTerm.has("POS")){
						containsAllParts[1] = oTerm.getString("POS");
					}
					else{
						containsAllParts[1] = "";
					}
					if(oTerm.has("sense")){
						containsAllParts[2] = oTerm.getString("sense");
					}
					else{
						containsAllParts[2] = "";
					}
					
					if(firstTrans.has("term")){
						containsAllParts[3] = firstTrans.getString("term");
					}
					else{
						containsAllParts[3] = "";
					}
					if(firstTrans.has("POS")){
						containsAllParts[4] = firstTrans.getString("POS");
					}
					else{
						containsAllParts[4] = "";
					}
					if(firstTrans.has("sense")){
						containsAllParts[5] =  firstTrans.getString("sense");
					}
					else{
						containsAllParts[5] = "";
					}
					retrievedInformation.put(retrievedMeaning, containsAllParts);
				}
			}
			if(term0.has("AdditionalTranslations")){
				JSONObject additionalTranslation = term0.getJSONObject("AdditionalTranslations");
				JSONArray additionalTranslationArray = additionalTranslation.names();
				int length = additionalTranslationArray.length();
				for (int i = 0; i < length; i++){
					JSONObject results = additionalTranslation.getJSONObject(additionalTranslationArray.getString(i));
					JSONObject oTerm = results.getJSONObject("OriginalTerm");
					JSONObject firstTrans = results.getJSONObject("FirstTranslation");
					String retrievedMeaning = oTerm.getString("sense");
					retrievedMeaning = oTerm.getString("sense");
					sendToAdapter.add(retrievedMeaning);	
					
					if(oTerm.has("term")){
						containsAllParts[0] = oTerm.getString("term");
					}
					else{
						containsAllParts[0] = "";
					}
					if(oTerm.has("POS")){
						containsAllParts[1] = oTerm.getString("POS");
					}
					else{
						containsAllParts[1] = "";
					}
					if(oTerm.has("sense")){
						containsAllParts[2] = oTerm.getString("sense");
					}
					else{
						containsAllParts[2] = "";
					}
					
					if(firstTrans.has("term")){
						containsAllParts[3] = firstTrans.getString("term");
					}
					else{
						containsAllParts[3] = "";
					}
					if(firstTrans.has("POS")){
						containsAllParts[4] = firstTrans.getString("POS");
					}
					else{
						containsAllParts[4] = "";
					}
					if(firstTrans.has("sense")){
						containsAllParts[5] =  firstTrans.getString("sense");
					}
					else{
						containsAllParts[5] = "";
					}
					retrievedInformation.put(retrievedMeaning, containsAllParts);

				}

			}
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		if(sendToAdapter.isEmpty()){
			Log.i("TP", "Set is empty, son");
			sendToAdapter.add(this.originalTerm);
		}
		String[] termAndSense = new String[sendToAdapter.size()];
		Log.i("TP", "SHOULD RETURN this shit "+sendToAdapter.toString());
		return sendToAdapter.toArray(termAndSense);
	}

	public String[] returnPartsOfWord(String s){
		return retrievedInformation.get(s);

	}





}
