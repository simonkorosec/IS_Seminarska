package myapp.kinoisseminarska.views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import myapp.kinoisseminarska.R;

public class LoginActivity extends AppCompatActivity {


    private TextView registerButton;
    private LinearLayout loginButton;
    private EditText userName;
    private EditText password;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        registerButton = findViewById(R.id.registerLoginButton);
        loginButton = findViewById(R.id.loginButton);
        userName = findViewById(R.id.usernameLogin);
        password = findViewById(R.id.passwordLogin);

        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent myIntent = new Intent(getApplicationContext(), RegisterActivity.class);
                startActivity(myIntent);
            }
        });
        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(validInput(userName) && validInput(password)) {
                    Intent myIntent = new Intent(getApplicationContext(), LoadingLoginActivity.class);
                    myIntent.putExtra("password", password.getText().toString().trim());
                    myIntent.putExtra("username", userName.getText().toString().trim());
                    myIntent.putExtra("loading_text", "Logging in");
                    startActivity(myIntent);
                }
                else {
                    Toast.makeText(getApplicationContext(),
                            "Password or username shouldn't be blank!", Toast.LENGTH_SHORT).show();
                }
            }
        });

    }

    private boolean validInput(EditText myInput) {
        return myInput.getText().toString().length() != 0;
    }
}
