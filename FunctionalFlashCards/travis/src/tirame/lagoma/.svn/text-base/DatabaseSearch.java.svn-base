package tirame.lagoma;

import java.io.BufferedReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.ListView;

abstract class DatabaseSearch extends AsyncTask<Object, String, Boolean> {
	protected Context context;
	protected ProgressDialog progressDialog;
	protected ListView list;
	protected String endpoint;
	protected String searchTerm;
	protected String  databaseURL;
	protected String term;

	
	public DatabaseSearch(){
		
	}
	//Constructor
	public DatabaseSearch(ListView l, Context c, String t){
		this.context = c;
		this.list = l;
		try {
			this.searchTerm = URLEncoder.encode(t, "UTF-8");
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		this.endpoint = "null";
		this.databaseURL = "null";
	}

	
	
	
	/*
	@Override
	protected void onPreExecute() {
		progressDialog = ProgressDialog.show(context, "Retrieving Definition", "Please Wait");
	}

	@Override
	protected void onPostExecute(Boolean result) {
		progressDialog.dismiss();
	}
	*/
	
	
	
	
	@Override
	protected Boolean doInBackground(Object... params) {


		try {
			URL serverAddress = new URL(databaseURL);
			//URL serverAddress = new URL("http://thesaurus.altervista.org/thesaurus/v1");	  
			//URL serverAddress = new URL(endpoint + "?word="+URLEncoder.encode(word, "UTF-8")+"&language="+language+"&key="+key+"&output="+output); 
			HttpURLConnection connection = (HttpURLConnection)serverAddress.openConnection(); 
			connection.connect(); 
			int rc = connection.getResponseCode(); 
			if (rc == 200) { 
				BufferedReader br = new BufferedReader(new java.io.InputStreamReader(connection.getInputStream())); 
				String payload = "";
				String line = br.readLine();
				while (line != null){
					payload += line;
					line = br.readLine();
				}


				br.close();
				System.out.println("Payload:"+payload);
				JSONObject obj = new JSONObject(payload);
				JSONArray items = obj.getJSONArray("phrase");
				String[] returnedItems = new String[items.length()];
				for (int i=0; i < items.length(); i++) { 
					JSONObject returnedItem = items.getJSONObject(i);
					returnedItems[i] = returnedItem.getString("text");
				} 

				publishProgress(returnedItems);
			} else System.out.println("HTTP error:"+rc); 
			connection.disconnect(); 
		} catch (java.net.MalformedURLException e) { 
			e.printStackTrace(); 
		} catch (java.net.ProtocolException e) { 
			e.printStackTrace(); 
		} catch (java.io.IOException e) { 
			e.printStackTrace(); 
		}catch (JSONException e) {
			e.printStackTrace();
		}
		return true;
	}
	@Override
	protected void onProgressUpdate(String... values){
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(context, R.layout.list_item);

		for(String definition: values){
			adapter.add(definition);
		}
		list.setAdapter(adapter);

	}

}


