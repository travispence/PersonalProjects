package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

public class ViewDeck extends Activity{
	//Context Menu
	final int CONTEXT_MENU_DELETE_ITEM =1;
	final int CONTEXT_MENU_UPDATE =2;
	//List View
	private ListView myListView;
	//Dictionary resource and adapter
	private WordReferenceJSON get_JSON_task;
	protected DeckAdapter adapter;
	//Used to maintain lists in view
	private ArrayList<String> data = new ArrayList<String>();
	private ArrayList<String> oldData = new ArrayList<String>();
	//Not sure
	private Context context;
	//True means that the meanings are being shown in the list
	//False means the list of words is being shown.
	private boolean mode = false;

	//Used to retrieve/save data
	protected AppPreferences appPrefs;
	private String LIST_KEY;

	//Used to change title of list
	protected TextView tv;




	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		this.context = this;
		setContentView(R.layout.word_list);


		//Used to retrieve lists based of of deck name
		Intent intent = getIntent();
		this.LIST_KEY = intent.getStringExtra("Deck");
		Log.i("TP", "LIST_KEY IS "+LIST_KEY);

		//Get List title
		this.tv =  (TextView) findViewById(R.id.textView1);

		//Handles adding Decks to the List Dynamically.
		adapter = new DeckAdapter (this, R.layout.listview_item_row, data);
		/*Find the ListView ID and set the adapter for it*/
		myListView = (ListView)findViewById(R.id.words);
		myListView.setAdapter(adapter);
		myListView.setItemsCanFocus(true);
		registerForContextMenu(myListView);

		//Handles creating list from retrieved information
		appPrefs = new AppPreferences(this);
		if(appPrefs.hasKey(LIST_KEY)){
			Log.i("TP", "HAS KEY");
			ArrayList<String> temp = appPrefs.getStringArray(LIST_KEY);
			
			if(temp.isEmpty()){
				temp.add("List Is empty");
			}
			data.addAll(temp);
			
		}
		else{
			Log.i("TP", "Created set");	appPrefs.saveStringArray(LIST_KEY, data);

		}
		Log.i("TP",	"Data is "+data.toString());

		adapter.notifyDataSetChanged();
		//Logic for short click on object in list
		myListView.setOnItemClickListener(new OnItemClickListener(){
			public void onItemClick(AdapterView<?> arg0, View arg1, int position,
					long id) {
				String keyVal =data.get(position);				
				if(mode == true){
					Log.i("TP", "keyVal = "+keyVal +"newVal = "+get_JSON_task.returnPartsOfWord(keyVal)[0]);
					oldData.add(get_JSON_task.returnPartsOfWord(keyVal)[0]);
					
					String[] pow = get_JSON_task.returnPartsOfWord(keyVal);
					String k = get_JSON_task.returnPartsOfWord(keyVal)[0];
					String term = "term";
					String pos = "pos";
					String sense ="sense";
					String spanT = "spanTerm";
					String spanPos ="spanPos";
					String spanSense="spanSense";					
					appPrefs.addString(k+term, pow[0]);
					appPrefs.addString(k+pos, pow[1]);
					appPrefs.addString(k+sense, pow[2]);
					appPrefs.addString(k+spanT, pow[3]);
					appPrefs.addString(k+spanPos, pow[4]);
					appPrefs.addString(k+spanSense, pow[5]);
					adapter.clear();
					data.clear();
					data.addAll(oldData);
					oldData.clear();
					
					
					tv.setText(context.getString(tirame.lagoma.R.string.word_list_title));		
					adapter.notifyDataSetChanged();
					Log.i("TP", "made it here before results keyVal is "+keyVal);
					mode = false;
					appPrefs.saveStringArray(LIST_KEY, data);
				}
				
				
				
				else{
					Intent i = (new Intent(ViewDeck.this, ViewCards.class));
					i.putExtra("key", LIST_KEY);
					i.putExtra("Card", keyVal);
					Log.i("TP", "CARD is "+ keyVal);
					Log.i("TP", "Deck is "+ LIST_KEY);
					startActivity(i);
					
				}

			}
		});

		//Logic for search
		Button search_button = (Button) findViewById(R.id.search_word);
		search_button.setOnClickListener(new OnClickListener(){
			public void onClick(View v) {
				/*Create the Alert Dialog that prompts the user to name their deck*/
				AlertDialog.Builder alert = new AlertDialog.Builder(ViewDeck.this);
				//ArrayList<String> alertList = new ArrayList<String>();
				final EditText input = new EditText(ViewDeck.this);
				alert.setView(input);
				new AlertDialog.Builder(ViewDeck.this)
				.setTitle("Enter Search Term")
				.setMessage("Please enter an english word")
				.setView(input)
				.setPositiveButton("Search", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						data.remove("List Is empty");
						oldData.addAll(data);
						
						data.clear();
						Log.i("TP", "after init olddata is "+oldData.toString());
						//Change title
						tv.setText(tirame.lagoma.R.string.make_selection_title);						
						Log.i("TP", "after clear olddata is "+oldData.toString());
						Interface i = new Interface(context);
						get_JSON_task =  (WordReferenceJSON) i.LookupWord(input.getText().toString(), adapter);
						get_JSON_task.execute();
						adapter.notifyDataSetChanged();
						mode = true;
					}
				}).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						// Do nothing.
					}
				}).show();
			}
		});
	}


	//Handles Context menu
	@Override
	public void onCreateContextMenu(ContextMenu menu, View v,ContextMenu.ContextMenuInfo menuInfo) {

		menu.add(Menu.NONE, CONTEXT_MENU_DELETE_ITEM, Menu.NONE, tirame.lagoma.R.string.delete);
		menu.add(Menu.NONE, CONTEXT_MENU_UPDATE, Menu.NONE, tirame.lagoma.R.string.update);
	}

	@Override
	public boolean onContextItemSelected(MenuItem item) {

		AdapterView.AdapterContextMenuInfo info= (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();


		switch (item.getItemId()) {
		case CONTEXT_MENU_DELETE_ITEM:
			data.remove(info.position);
			adapter.notifyDataSetChanged();
			appPrefs.saveStringArray(LIST_KEY, data);
			return(true);
		case CONTEXT_MENU_UPDATE:
			return(true);    
		}
		return(super.onOptionsItemSelected(item));
	}


} 






