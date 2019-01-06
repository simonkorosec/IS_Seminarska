package myapp.kinoisseminarska.utils;

import android.content.Context;
import android.content.SharedPreferences;

/*
    @author: urban.jagodic
*/
public class ContentStore  {

    private String prefsName = "myprefrences";
    private SharedPreferences myPrefs;
    private SharedPreferences.Editor myEditor;

    public ContentStore(Context context) {
        this.myPrefs = context.getSharedPreferences(prefsName, Context.MODE_PRIVATE);
        this.myEditor = myPrefs.edit();
    }
    public void storeUsername(String value, String key) {
        myEditor.putString(key, value);
        myEditor.commit();
    }
    public void removeUsername(String key) {
        myEditor.remove(key);
        myEditor.commit();
    }

    public String getUsername() {
        return myPrefs.getString("username", "default_value");
    }
}
