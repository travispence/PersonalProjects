package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class DeckAdapter extends ArrayAdapter<Flashcard>{
	Context context;
	int layoutResourceID;
	ArrayList<Flashcard> data = null;
	
	public DeckAdapter(Context context, int layoutResourceID, ArrayList<Flashcard> data){
		super(context, layoutResourceID);
		this.layoutResourceID = layoutResourceID;
		this.context = context;
		this.data = data;
		
	}
	
	
	
	/* We will need to implement onClick method to handle the items in the list being clicked.*/
	/* Take a look at DeckListAdapter for how to do it.*/
	@Override
	public View getView(int position, View convertView, ViewGroup parent){
		View row = convertView;
		CardHolder holder = null;
		
		if (row == null)
		{
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			row = inflater.inflate(layoutResourceID, parent, false);
			
			holder = new CardHolder();
			holder.txtTitle = (TextView)row.findViewById(R.id.txtTitle);
			row.setTag(holder);
		}
		else
		{
			holder = (CardHolder)row.getTag();
		}
	
		Flashcard card = data.get(position);
		holder.txtTitle.setText(card.getPalabra());
		return row;
	}
	static class CardHolder
	{
		TextView txtTitle;
	}

}
