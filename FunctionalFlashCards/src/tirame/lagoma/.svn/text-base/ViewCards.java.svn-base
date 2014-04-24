package tirame.lagoma;

import java.util.ArrayList;

import tirame.lagoma.SimpleGestureFilter.SimpleGestureListener;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.MotionEvent;
import android.widget.TextView;

public class ViewCards extends Activity implements SimpleGestureListener{
	protected AppPreferences appPrefs;
	
	protected DeckAdapter adapter;
	private SimpleGestureFilter detector; 

	private TextView tv1;
	private TextView tv2;

	//Retrieve List - see viewdeck.java
	private String LIST_KEY;
	private String CARD_KEY;
	private ArrayList<String> flashCardNames = new ArrayList<String>();
	private ArrayList<Flashcard> cards = new ArrayList<Flashcard>();
	private int curFlash;
	private int length;
	public void onCreate(Bundle savedInstanceState){

		super.onCreate(savedInstanceState);
		setContentView(R.layout.flashcard_main);
		appPrefs = new AppPreferences(this);



		//Used to retrieve lists based of of deck name
		curFlash = 0;
		length = 0;
		//Used to retrieve lists based off of deck name

		Intent intent = getIntent();

		this.LIST_KEY = intent.getStringExtra("key");
		Log.i("TP", "LIST_KEY IS "+LIST_KEY);
		

		this.LIST_KEY = intent.getStringExtra("key");

        detector = new SimpleGestureFilter(this,this);

		
		
		if(appPrefs.hasKey(LIST_KEY)){
			Log.i("TP", "HAS KEY");
			ArrayList<String> temp = appPrefs.getStringArray(LIST_KEY);
			Log.i("TP", "temp is "+temp.toString());
			
			
			if(temp.isEmpty()){
				temp.add("List Is empty");
			}
			
			flashCardNames.addAll(temp);
			Log.i("TP", "Flashcardnames "+flashCardNames.toString());
		}



		Log.i("TP", "Right before flashcardNames");

		for(String key : flashCardNames){

			//The name of the card is the key. 
			//See the constructor in flashcard
			cards.add(new Flashcard(key, this));

			Log.i("TP", "Cards"+cards.toString());


			length++;
			
		}
		CARD_KEY = intent.getStringExtra("Card");
		if(flashCardNames.contains(CARD_KEY)){

			for(int i = 0; i < length; i++){
				if(flashCardNames.get(i).equals(CARD_KEY)){
					Log.i("TO", CARD_KEY);
					curFlash = i;

				}
			}


		}
		tv1 = (TextView) findViewById(R.id.engTerm);	
		String temp = new String();
		temp += "Word:\n";
		temp += cards.get(curFlash).getWord();
		temp += "\nDefinition:\n";
		temp += cards.get(curFlash).getEnglishDefintion();
		temp += "\nPart of Speech:\n";
		temp += cards.get(curFlash).getEngPOS();
		tv1.setText(temp);
		tv2 = (TextView) findViewById(R.id.espTerm);	
		temp = new String();
		temp += "Palabra:\n";
		temp += cards.get(curFlash).getPalabra();
		temp += "\nDefinicion:\n";
		temp += cards.get(curFlash).getSpanishDefintion();
		temp += "\nTipo:\n";
		temp += cards.get(curFlash).getSpanPOS();
		tv2.setText(temp);
	    ((TextView)tv2).setVisibility(TextView.INVISIBLE);
		
	}

	public void reset(){
		String temp = new String();
		temp += "Word:\n";
		temp += cards.get(curFlash).getWord();
		temp += "\nDefinition:\n";
		temp += cards.get(curFlash).getEnglishDefintion();
		temp += "\nPart of Speech:\n";
		temp += cards.get(curFlash).getEngPOS();
		tv1.setText(temp);
		tv2 = (TextView) findViewById(R.id.espTerm);	
		temp = new String();
		temp += "Palabra:\n";
		temp += cards.get(curFlash).getPalabra();
		temp += "\nDefinicion:\n";
		temp += cards.get(curFlash).getSpanishDefintion();
		temp += "\nTipo:\n";
		temp += cards.get(curFlash).getSpanPOS();
		tv2.setText(temp);
	    ((TextView)tv2).setVisibility(TextView.INVISIBLE);
	}
	
    @Override 
    public boolean dispatchTouchEvent(MotionEvent me){ 
      this.detector.onTouchEvent(me);
     return super.dispatchTouchEvent(me); 
    }
    
	public void onSwipe(int direction) {
		  
		  switch (direction) {
		  
		  case SimpleGestureFilter.SWIPE_RIGHT :
			curFlash++;
			if(curFlash >=length) curFlash = 0;
			reset();
		    break;
		  case SimpleGestureFilter.SWIPE_LEFT : 
			curFlash--;
			if(curFlash < 0) curFlash = length-1;
			reset();
		    break;
		  case SimpleGestureFilter.SWIPE_DOWN :
		      break;
		  case SimpleGestureFilter.SWIPE_UP :
		       break;
		                                           
		  } 

	}

	public void onDoubleTap() {
		Log.i("TO", "I did somehting!");
	    ((TextView)tv2).setVisibility(TextView.VISIBLE);
		
	}

}


