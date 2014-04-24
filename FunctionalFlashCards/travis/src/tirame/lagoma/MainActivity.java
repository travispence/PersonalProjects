package tirame.lagoma;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity implements OnClickListener {
	View decks, options;
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		Button view_decks_button = (Button) findViewById(R.id.view_decks_button);
		view_decks_button.setOnClickListener(this);
		Button options_button = (Button) findViewById(R.id.options_button);
		options_button.setOnClickListener(this);

	}


	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

	public void onClick(View view) {

		switch (view.getId()){

		case R.id.view_decks_button:
			startActivity(new Intent(this, ViewDeckList.class));
			break;
		case R.id.options_button:
			startActivity(new Intent(this, OptionsMenu.class));
			break;
		}
	}
}

