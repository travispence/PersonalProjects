package tirame.lagoma;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.annotation.TargetApi;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.ArrayAdapter;
import android.widget.ListView;

@TargetApi(3)
public class RetrieveDefinition extends AsyncTask<Object, String, Boolean> {
	public Context context;
	ListView list;

	public RetrieveDefinition(ListView l, Context c){
		this.context = c;
		this.list = l;
	}


	@TargetApi(3)
	@Override
	protected Boolean doInBackground(Object... params) {
		// Ok, vamanos
		HttpURLConnection con = null;

		try {
			URL url = new URL("http://search.twitter.com/search.json?q=Android");
			con = (HttpURLConnection) url.openConnection();
			con.setReadTimeout(10000);
			con.setConnectTimeout(15000);

			con.setRequestMethod("GET");
			con.setDoInput(true);
			con.connect();

			BufferedReader reader = new BufferedReader ( new InputStreamReader(con.getInputStream(), "UTF-8"));
			String payload = "";
			String line = reader.readLine();
			while(line != null){
				payload += line;
				line = reader.readLine();
			}
			reader.close();
			System.out.println("Payload: " + payload);
			//Parse results

			JSONObject jsonObject = new JSONObject(payload);
			JSONArray items = jsonObject.getJSONArray("results");
			int length = items.length();
			String[] definitions = new String[length];

			for (int i = 0; i < length; i++){
				JSONObject definition = items.getJSONObject(i);
				definitions[i] = definition.getString("text");
			}

			publishProgress(definitions);
		} catch (MalformedURLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ProtocolException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (JSONException e) {
			// TODO Auto-generated catch block
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
