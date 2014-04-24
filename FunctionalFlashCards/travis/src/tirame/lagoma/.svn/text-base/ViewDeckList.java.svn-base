package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

public class ViewDeckList extends Activity implements OnClickListener{ 
	private ListView myListView;
	private DeckListAdapter adapter;
	private ArrayList<Deck> data = new ArrayList<Deck>();

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.deck_list);

		
		//Handles adding Decks to the List Dynamically.
		adapter = new DeckListAdapter (this, R.layout.listview_item_row, data);
		/*Find the ListView ID and set the adapter for it*/
		myListView = (ListView)findViewById(R.id.decks);
		myListView.setAdapter(adapter);
		myListView.setItemsCanFocus(true);
		
		
		//This is to have a deck already in the list when we start up.
		Deck testDeck = new Deck("Test");
		data.add(testDeck);
		adapter.notifyDataSetChanged();
		
		
		
		
		//Add button to listener.
		Button add_button = (Button) findViewById(R.id.add_list);
		add_button.setOnClickListener(this);
	}
	
	
	public void onClick(View v) {
		switch (v.getId()){
		case R.id.add_list:
			/*Create the Alert Dialog that prompts the user to name their deck*/
			AlertDialog.Builder alert = new AlertDialog.Builder(this);
			final EditText input = new EditText(this);
			alert.setView(input);
			new AlertDialog.Builder(ViewDeckList.this)
			.setTitle("Update Status")
			.setMessage("Please enter a name for the Deck")
			.setView(input)
			.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int whichButton) {
					Deck d = new Deck(input.getText().toString());
					data.add(d);
					adapter.notifyDataSetChanged();
				}
			}).setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dialog, int whichButton) {
					// Do nothing.
				}
			}).show();
			break;
		default:
			startActivity(new Intent(this, ViewDeck.class));
			break;
		}
	}
}