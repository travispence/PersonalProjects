package tirame.lagoma;

import java.util.ArrayList;

import android.content.Context;
import android.view.View;

public class DeckListAdapter extends GenericListAdapter{
	public DeckListAdapter(Context context, int layoutResourceID, ArrayList<String> data){
		super(context, layoutResourceID, data);

	}

	@Override
	View initializeRows(View row) {
		//Makes the row clickable. We need to change this logic to start a class with
		//The correct Deck of flashcards.
		row.setClickable(true); 
		row.setFocusable(true);		

		
		return row;
	}

	
	
	
}
