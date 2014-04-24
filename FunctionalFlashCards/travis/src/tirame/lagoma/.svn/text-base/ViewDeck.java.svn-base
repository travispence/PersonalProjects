package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ListView;
	
public class ViewDeck extends Activity implements OnClickListener{
	private ListView myListView;
	private DeckAdapter adapter;
	private ArrayList<Flashcard> data = new ArrayList<Flashcard>();

	

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.word_list);
		//Handles adding Decks to the List Dynamically.
		adapter = new DeckAdapter (this, R.layout.listview_item_row, data);
		/*Find the ListView ID and set the adapter for it*/
		myListView = (ListView)findViewById(R.id.words);
		myListView.setAdapter(adapter);
		myListView.setItemsCanFocus(true);
		
		//These are here for testing purposes. We need to implement a data storage method
		//that will somehow use the ID of the deck to populate the list.
		Flashcard one = new Flashcard("uno", "one", "numero", "number");
		Flashcard two = new Flashcard("two", "dos", "numero", "number");
		Flashcard three = new Flashcard("three", "tres", "numero", "number");
		
		data.add(one);
		data.add(two);
		data.add(three);
		//Need to call adapter.addAll() in order to update the listview.
		adapter.addAll(data);
		adapter.notifyDataSetChanged();
	}
	
	
	
	//We need to implement the onClick method to display the the current flashCard.
	//Maybe should be an activity that implements gestures.
	public void onClick(View v) {
		// TODO Auto-generated method stub
		
	} 
		
		
		
	}


