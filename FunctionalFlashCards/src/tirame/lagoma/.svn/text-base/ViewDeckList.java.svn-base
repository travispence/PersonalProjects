package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.app.AlertDialog;
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

public class ViewDeckList extends Activity{ 
	private ListView myListView;
	private DeckListAdapter adapter;
	private ArrayList<String> data = new ArrayList<String>();
	final int CONTEXT_MENU_DELETE_ITEM =1;
	final int CONTEXT_MENU_UPDATE =2;
	String DECK_KEY = "deckList";
	protected AppPreferences appPrefs;

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.deck_list);
		//Handles adding Decks to the List Dynamically.
		adapter = new DeckListAdapter (this, R.layout.listview_item_row, data);
		/*Find the ListView ID and set the adapter for it*/
		myListView = (ListView)findViewById(R.id.decks);
		myListView.setAdapter(adapter);
		myListView.setItemsCanFocus(true);
		//Sets up the listview to handle long clicks
		registerForContextMenu(myListView);
		//Handles a short click. It will open the flashcardActivity.




		appPrefs = new AppPreferences(this);
		if(appPrefs.hasKey(DECK_KEY)){
			Log.i("TP", "HAS KEY");
			ArrayList<String> temp = appPrefs.getStringArray(DECK_KEY);
			if(temp.isEmpty()){
				temp.add("List Is empty");
			}
			data.addAll(temp);
		}
		else{
			Log.i("TP", "Created set");
			appPrefs.saveStringArray(DECK_KEY, data);

		}
		Log.i("TP",	"Data is "+data.toString());

		adapter.notifyDataSetChanged();





		//Handles a short click. It will open the flashcardActivity.
		myListView.setOnItemClickListener(new OnItemClickListener(){
			public void onItemClick(AdapterView<?> arg0, View arg1, int position,
					long id) {
				String keyVal =data.get(position);
				Intent i = (new Intent(ViewDeckList.this, ViewCards.class));
				i.putExtra("key", keyVal);// Will be the Key Value for the flashcard database lookup.
				startActivity(i);
			}
		});
		//Add button to listener.
		Button add_button = (Button) findViewById(R.id.add_list);
		add_button.setOnClickListener(new OnClickListener(){
			public void onClick(View v){
				/*Create the Alert Dialog that prompts the user to name their deck*/
				AlertDialog.Builder alert = new AlertDialog.Builder(ViewDeckList.this);
				final EditText input = new EditText(ViewDeckList.this);
				alert.setView(input);
				new AlertDialog.Builder(ViewDeckList.this)
				.setTitle("Update Status")
				.setMessage("Please enter a name for the Deck")
				.setView(input)
				.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						String d = input.getText().toString();
						data.add(d);
						adapter.notifyDataSetChanged();
						appPrefs.saveStringArray(DECK_KEY, data);
						//adapter.notifyDataSetChanged();
					}
				}).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						// Do nothing.
					}
				}).show();
			}
		});

	}

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
			appPrefs.saveStringArray(DECK_KEY, data);
			return(true);
		case CONTEXT_MENU_UPDATE:
			Intent i = new Intent(this, ViewDeck.class);
			i.putExtra("Deck", data.get(info.position));
			Log.i("TP", "info.pos = "+data.get(info.position));
			startActivity(i); // View Deck. 
			return(true);    
		}
		return(super.onOptionsItemSelected(item));
	}


}