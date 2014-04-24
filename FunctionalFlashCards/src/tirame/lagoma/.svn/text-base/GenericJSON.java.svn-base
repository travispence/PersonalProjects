package tirame.lagoma;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

import org.json.JSONException;
import org.json.JSONObject;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.ArrayAdapter;


abstract class GenericJSON extends AsyncTask<Object, String, Boolean> {
	
	protected Context context;
	protected ProgressDialog progressDialog;
	protected String urlString = "";
	protected String searchTerm;
	protected String msg;
	protected ArrayAdapter<String> adapter;
	
	
	public GenericJSON(Context c, String term, ArrayAdapter<String> a){
		this.context = c;
		this.searchTerm = term;
		this.adapter = a;
		this.urlString = buildURL();	
		
	}
	
	//Needs to be implemented by child classes.
	abstract String buildURL();
	abstract String[] parseResults(JSONObject job);

	protected final void onPreExecute() {
		progressDialog = ProgressDialog.show(context, context.getString(tirame.lagoma.R.string.searching)+searchTerm, context.getString(tirame.lagoma.R.string.downloading), true, true);
	}
	
	protected final void onPostExecute(Boolean result) {
		progressDialog.dismiss();
	}

	protected Boolean doInBackground(Object... params) {
		HttpURLConnection con = null;
		try {
			Log.i("TP", "In try block");
			URL url = new URL(urlString);
			
			con = (HttpURLConnection) url.openConnection();
			con.setReadTimeout(10000);
			con.setConnectTimeout(15000);
			con.setRequestMethod("GET" );
			con.setDoInput(true);
			con.connect();
			BufferedReader reader = new BufferedReader( new InputStreamReader(con.getInputStream(), "UTF-8"));
			String payload = "";
			String line = reader.readLine();
			while (line != null) {
				payload += line;
				line = reader.readLine();
			}
			reader.close();
			System.out.println("Payload: " + payload);
			JSONObject job = new JSONObject(payload);
			String[] results = parseResults(job);
			Log.i("TP", "GJSON results[] are "+results.toString()); 
			publishProgress(results);
		} catch (MalformedURLException e) {
			// TODO Auto-generated catch block
			Log.i("TP", "Malformed URL");
			e.printStackTrace();
		} catch (IOException e) {
			Log.i("TP", "IOException");
			e.printStackTrace();
		} catch (JSONException e) {
			Log.i("TP", "JSONException");
			e.printStackTrace();
		}
		return true;
	}
	
    @Override
    protected void onProgressUpdate(String... values) {
       for (String meaning : values) {
        	adapter.add(meaning);
        	adapter.notifyDataSetChanged();
        }

        
    }
	
	
	
	
	

}
