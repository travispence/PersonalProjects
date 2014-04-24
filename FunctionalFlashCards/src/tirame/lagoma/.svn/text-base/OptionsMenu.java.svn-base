package tirame.lagoma;

import java.util.Locale;

import android.app.Activity;
import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

public class OptionsMenu extends Activity{
	protected AppPreferences appPrefs;
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.options); 
		
		
		Button save = (Button) findViewById(R.id.save_button);
		save.setOnClickListener(new OnClickListener(){

			public void onClick(View v) {
				startActivity(new Intent(OptionsMenu.this, MainActivity.class));		
			}
			
		});
		
		
		Spinner spinner =(Spinner) findViewById(R.id.language_spinner);
		ArrayAdapter<CharSequence> adapter =  ArrayAdapter.createFromResource(this, R.array.spinner_items, android.R.layout.simple_spinner_item);
		adapter.setDropDownViewResource( android.R.layout.simple_spinner_dropdown_item );
		appPrefs = new AppPreferences(this);
		spinner.setAdapter(adapter);
		spinner.setSelection(appPrefs.getInt("pos"));
		spinner.setOnItemSelectedListener(new OnItemSelectedListener(){

			public void onItemSelected(AdapterView<?> arg0, View v,
					int position, long arg3) {

				if (position == 0 ){
					setLocale("en");
					appPrefs.addString("Language", "enes");
					appPrefs.addInt("pos", position);	
				}
				else if (position == 1){
					setLocale("es");
					appPrefs.addString("Language", "esen");
					appPrefs.addInt("pos", position);	
				}
				else if (position== 2){
					setLocale("en");
					appPrefs.addString("Language", "enfr");
					appPrefs.addInt("pos", position);	
				}
				else if (position == 3){
					setLocale("fr");
					appPrefs.addString("Language", "fren");
					appPrefs.addInt("pos", position);	
				}

			}

			public void onNothingSelected(AdapterView<?> arg0) {
				Log.i("TP", "Nothing Selected in Languages");

			}

		});
	}





	private void setLocale(String localeCode){
		Locale locale = new Locale(localeCode);
		Locale.setDefault(locale);
		Configuration config = new Configuration();
		config.locale = locale;
		getBaseContext().getResources().updateConfiguration(config, getBaseContext().getResources().getDisplayMetrics());

	}
}



