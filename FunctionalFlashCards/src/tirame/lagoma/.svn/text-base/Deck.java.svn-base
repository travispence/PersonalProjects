package tirame.lagoma;

import java.util.ArrayList;

public class Deck {
	private String title;
	private int length;
	ArrayList<Flashcard> cards;

	public Deck(){
		super();
	}
	public Deck (String title){
		super();
		this.setTitle(title);
		//setDeck();
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	
	public void setDeck(){

	}
	public ArrayList<String> getCards(){
		ArrayList<String> words = new ArrayList<String>();
		for(Flashcard card: cards){
			words.add(card.getPalabra());
			words.add(card.getWord());
			words.add(card.getSpanishDefintion());
			words.add(card.getEnglishDefintion());

		}
		return words;
	}
	public int getLength(){
		return length;
	}
	
		
}
