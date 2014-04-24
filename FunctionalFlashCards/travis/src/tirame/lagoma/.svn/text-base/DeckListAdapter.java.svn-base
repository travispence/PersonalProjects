package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class DeckListAdapter extends ArrayAdapter<Deck>{
	Context context;
	int layoutResourceID;
	ArrayList<Deck> data = null;

	public DeckListAdapter(Context context, int layoutResourceID, ArrayList<Deck> data){
		super(context, layoutResourceID, data);
		this.layoutResourceID = layoutResourceID;
		this.context = context;
		this.data = data;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent){
		View row = convertView;
		DeckHolder holder = null;
		if (row == null)
		{
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			row = inflater.inflate(layoutResourceID, parent, false);

			holder =  new  DeckHolder();
			holder.txtTitle = (TextView)row.findViewById(R.id.txtTitle);
			row.setTag(holder);
		}
		else
		{
			holder =(DeckHolder)row.getTag();
		}

		Deck deck = data.get(position);
		holder.txtTitle.setText(deck.getTitle());

		//Makes the row clickable. We need to change this logic to start a class with
		//The correct Deck of flashcards.
		row.setClickable(true); 
		row.setFocusable(true);
		row.setOnClickListener(new View.OnClickListener() {
			 public void onClick(View v){  
				context.startActivity(new Intent(context, ViewDeck.class));
			}
		});
		return row;
	}
	static class DeckHolder
	{
		TextView txtTitle;
	}
}
