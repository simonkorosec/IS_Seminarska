package myapp.kinoisseminarska.views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import myapp.kinoisseminarska.R;

public class RegisterActivity extends AppCompatActivity {

    private LinearLayout registerButton;
    private EditText userName;
    private EditText password;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        registerButton = findViewById(R.id.registerButton);
        userName = findViewById(R.id.usernameRegister);
        password = findViewById(R.id.passwordRegister);

        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (validInput(userName) && validInput(password)) {
                    Intent myIntent = new Intent(getApplicationContext(), LoadingLoginActivity.class);
                    myIntent.putExtra("password", password.getText().toString().trim());
                    myIntent.putExtra("username", userName.getText().toString().trim());
                    myIntent.putExtra("loading_text", "Completing registration");
                    startActivity(myIntent);
                    finish();
                } else {
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
