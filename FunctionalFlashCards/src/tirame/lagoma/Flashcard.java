package tirame.lagoma;

import android.content.Context;

public class Flashcard {
	private String palabra;
	private String word;
	private String englishDefintion;
	private String spanishDefintion;
	private String engPOS;
	private String spanPOS;
	protected AppPreferences appPrefs;



	public Flashcard(){
		super();
	}

	public Flashcard(String key, Context c){
		this.appPrefs = new AppPreferences(c);
		this.word = appPrefs.getString(key+"term");
		this.palabra = appPrefs.getString(key+"spanTerm");
		this.englishDefintion = appPrefs.getString(key+"sense");
		this.spanishDefintion = appPrefs.getString(key+"spanSense");
		this.engPOS = appPrefs.getString(key+"pos");
		this.spanPOS = appPrefs.getString(key+"spanPos");



	}

	public String getWord(){	
		return word;	
	}

	public void setWord(String word){
		this.word = word;
	}

	public String getPalabra() {
		return palabra;
	}

	public void setPalabra(String palabra) {
		this.palabra = palabra;
	}

	public String getEnglishDefintion() {
		return englishDefintion;
	}

	public void setEnglishDefintion(String englishDefintion) {
		appPrefs.addString(this.word+"sense", englishDefintion);
		this.englishDefintion = englishDefintion;
	}

	public String getSpanishDefintion() {
		return spanishDefintion;
	}

	public void setSpanishDefintion(String spanishDefintion) {
		appPrefs.addString(this.word+"spanSense", spanishDefintion);
		this.spanishDefintion = spanishDefintion;
	}
	public String getSpanPOS() {
		appPrefs.addString(this.word+"spanSense", spanishDefintion);
		return spanPOS;
	}
	public void setSpanPOS(String spanPOS) {
		this.spanPOS = spanPOS;
	}
	public String getEngPOS() {
		return engPOS;
	}
	public void setEngPOS(String engPOS) {
		this.engPOS = engPOS;
	}


















}
