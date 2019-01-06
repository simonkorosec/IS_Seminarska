package myapp.kinoisseminarska.views;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.MenuItem;
import android.widget.Toast;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.utils.ContentStore;

public class MainActivity extends AppCompatActivity implements
        PredstaveFragment.OnFragmentInteractionListener,
        PastOrders.OnFragmentInteractionListener {

    private PredstaveFragment predstaveFragment = new PredstaveFragment();
    private PastOrders pastOrders = new PastOrders();
    private ContentStore cntStore;

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_predstave:
                    setFragment(predstaveFragment);
                    return true;
                case R.id.navigation_ticket:
                    setFragment(pastOrders);
                    return true;
            }
            return false;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);

        cntStore = new ContentStore(getApplicationContext());

        Intent myIntent = getIntent();
        if(myIntent != null) {

            String username = myIntent.getStringExtra("passed_username");
            Log.d("test_is", "logged in as user: " + username);
            cntStore.storeUsername(username, "username");
        }

        getSupportFragmentManager().beginTransaction().
                replace(R.id.mainContainer, predstaveFragment).
                commit();
    }

    @Override
    public void onFragmentInteraction(Uri uri) {
        // nothing
    }

    private void setFragment(Fragment myFragment) {
        getSupportFragmentManager().beginTransaction().
                replace(R.id.mainContainer, myFragment).
                commit();
    }

    @Override
    public void onBackPressed() {
        AlertDialog.Builder myBuilder;
        myBuilder = Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP ?
                new AlertDialog.Builder(this,
                        android.R.style.Theme_Material_Light_Dialog_Alert) : new AlertDialog.Builder(this);

        myBuilder.setTitle("Log out").setMessage("Do you wish to log out?")
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        cntStore.removeUsername("username");
                        Log.d("test_is", "user '" + cntStore.getUsername() + "' logged out!");
                        Toast.makeText(getApplicationContext(), "Logged out!", Toast.LENGTH_SHORT).show();
                        MainActivity.super.onBackPressed();
                    }
                })
                .setNegativeButton("CANCEL", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        // blank
                    }
                })
                .show();
    }
}
