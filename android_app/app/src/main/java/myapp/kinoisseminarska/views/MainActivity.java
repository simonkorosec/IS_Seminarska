package myapp.kinoisseminarska.views;

import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;

import myapp.kinoisseminarska.R;

public class MainActivity extends AppCompatActivity implements
        PredstaveFragment.OnFragmentInteractionListener,
        PastOrders.OnFragmentInteractionListener,
        SeatsFragment.OnFragmentInteractionListener {

    private PredstaveFragment predstaveFragment = new PredstaveFragment();
    private PastOrders pastOrders = new PastOrders();

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
}
