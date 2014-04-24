package tirame.lagoma;

import java.util.ArrayList;

import android.content.Context;
import android.view.View;

public class DeckAdapter extends GenericListAdapter{
	public DeckAdapter(Context context, int layoutResourceID, ArrayList<String> data){
		super(context, layoutResourceID, data);

	}

	@Override
	View initializeRows(View row) {
		//Makes the row clickable. We need to change this logic to start a class with
		//The selected flashcard. 
		row.setClickable(true); 
		row.setFocusable(true);
		row.setOnClickListener(new View.OnClickListener() {
			 public void onClick(View v){  
				//context.startActivity(new Intent(context, ViewDeck.class));
			}
		});
		return row;
		
	}


}
