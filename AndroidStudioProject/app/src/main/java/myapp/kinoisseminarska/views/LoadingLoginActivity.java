package myapp.kinoisseminarska.views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.User;
import myapp.kinoisseminarska.webservices.RestManagment;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoadingLoginActivity extends AppCompatActivity {

    private TextView loadingText;
    private String username;
    private String password;
    private String loadingTextString;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_loading_login);


        loadingText = findViewById(R.id.loadingText);
        Intent myIntent = getIntent();
        if(myIntent != null) {

            loadingTextString = myIntent.getStringExtra("loading_text");

            loadingText.setText(loadingTextString);
            password = myIntent.getStringExtra("password");
            username = myIntent.getStringExtra("username");

            User user = new User();
            user.setPassword(password);
            user.setUsername(username);

            if(loadingTextString.equals("Logging in"))
                loginUserAPICall(user);
            else if (loadingTextString.equals("Completing registration"))
                registerUserAPICall(user);
            else
                Log.d("test_is", "loading login failed");
        }
    }

    private void loginUserAPICall(final User user) {
        RestManagment.loginUser(user).enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                if (response.code() == 200) {
                    Log.d("test_is", "login succesful!");
                    Toast.makeText(getApplicationContext(),
                            "Logged in!", Toast.LENGTH_SHORT).show();
                    Intent myIntent = new Intent(getApplicationContext(), MainActivity.class);
                    myIntent.putExtra("passed_username", user.getUsername());
                    startActivity(myIntent);
                    finish();
                }
                else {
                    Toast.makeText(getApplicationContext(),
                            "Invalid password or username!", Toast.LENGTH_SHORT).show();
                    Log.d("test_is", "invalid password or username!");
                    finish();
                }
            }
            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Log.d("test_is", "api 'UporabnikApi/login' failed");
                loginUserAPICall(user);
            }
        });
    }

    private void registerUserAPICall(final User user) {
        RestManagment.registerUser(user).enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                if (response.code() == 200) {
                    Log.d("test_is", "register succesful!");
                    Toast.makeText(getApplicationContext(),
                            "Successfully registered!", Toast.LENGTH_SHORT).show();
                    Intent myIntent = new Intent(getApplicationContext(), MainActivity.class);
                    myIntent.putExtra("passed_username", user.getUsername());
                    startActivity(myIntent);
                    finish();
                }
                else {
                    Toast.makeText(getApplicationContext(),
                            "Username is already taken!", Toast.LENGTH_SHORT).show();
                    Log.d("test_is", "username already taken!");
                    finish();
                }
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Log.d("test_is", "api 'UporabnikApi/register' failed");
                registerUserAPICall(user);
            }
        });
    }
}
