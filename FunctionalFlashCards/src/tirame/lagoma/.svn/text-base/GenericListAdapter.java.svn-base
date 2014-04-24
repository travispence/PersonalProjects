package tirame.lagoma;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

abstract class GenericListAdapter extends ArrayAdapter<String> {
	Context context;
	int layoutResourceID;
	ArrayList<String> data = new ArrayList<String>();


	public GenericListAdapter(Context context, int layoutResourceID, ArrayList<String> data){
		super(context, layoutResourceID, data);
		this.context = context;
		this.layoutResourceID = layoutResourceID;
		this.data = data;
	}
	

	
	@Override
	public View getView(int position, View convertView, ViewGroup parent){
		View row = convertView;
		Holder holder = null;
		if (row == null)
		{
			LayoutInflater inflater = ((Activity)context).getLayoutInflater();
			row = inflater.inflate(layoutResourceID, parent, false);

			holder =  new  Holder();
			holder.txtTitle = (TextView)row.findViewById(R.id.txtTitle);
			row.setTag(holder);
		}
		else
		{
			holder =(Holder)row.getTag();
		}


		holder.txtTitle.setText(data.get(position));

		//Initialize row.
		//row = initializeRows(row);

		return row;
	}
	
	
	
	static class Holder
	{
		TextView txtTitle;
	}

	abstract View initializeRows(View row);
	


}

